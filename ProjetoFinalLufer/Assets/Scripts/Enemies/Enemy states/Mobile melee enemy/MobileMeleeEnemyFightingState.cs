using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMeleeEnemyFightingState : SimpleAnimatableState
{
    [Header("External references")]
    [SerializeField] private AreaDetector fightAreaDetector;
    [SerializeField] private Transform parentToRotate;
    [SerializeField] private MeleeAttacks meleeAttack;

    [Header("Gameplay tweeking fields")]
    [SerializeField] private float attackPlayerDelay;
    [SerializeField] private float attackDuration;
    [SerializeField] private float turnSmoothTime = 0.1f;

    private WaitForSeconds attackDurationWFS;
    private float turnSmoothVelocity;

    private void Start()
    {
        attackDurationWFS = new WaitForSeconds(attackDuration);
        fightAreaDetector.triggerExitCallback = ChangeToChasing;
    }

    public override void Enter(GameObject target)
    {
        PlayAnimationTrigger("Fighting");
        StartCoroutine(Fight(target.transform));
    }

    public override void Exit()
    {
        StopAllCoroutines();
    }

    IEnumerator Fight(Transform target)
    {
        while (true)
        {
            PlayAnimationTrigger("Fighting");
            for (float i = 0; i < attackPlayerDelay; i += Time.deltaTime)
            {
                Vector3 direction = new Vector3(target.position.x - parentToRotate.position.x, 
                                                transform.position.y,
                                                target.position.z - parentToRotate.position.z);
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(parentToRotate.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                parentToRotate.rotation = Quaternion.Euler(0f, angle, 0f);

                yield return null;
            }
            PlayAnimationTrigger("Attacking");
            meleeAttack.Sweep();

            yield return attackDurationWFS;
        }
    }

    // ==== State trasitions

    private void ChangeToChasing(GameObject target)
    {
        stateMachine.ChangeState(typeof(MobileMeleeEnemyChasingState), target);
    }
}
