using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMeleeEnemyFightingState : SimpleAnimatableState
{
    [Header("External references")]
    [SerializeField] private RangeDetector fightAreaDetector;
    [SerializeField] private Transform parentToRotate;
    [SerializeField] private MeleeAttacks meleeAttack;

    [Header("Gameplay tweeking fields")]
    [SerializeField] private float attackPlayerDelay;
    [SerializeField] private ComboElement attackStats;
    [SerializeField] private float turnSmoothTime = 0.1f;

    private WaitForSeconds attackDurationWFS;
    private float turnSmoothVelocity;

    private void Start()
    {
        attackDurationWFS = new WaitForSeconds(attackStats.duration);
    }

    public override void Enter()
    {
        Collider[] hits = fightAreaDetector.GetCollisionsInArea();
        if (hits.Length > 0)
        {
            GameObject target = hits[0].gameObject;
            PlayAnimationTrigger("Fighting");
            StartCoroutine(Fight(target.transform));
            StartCoroutine(CheckIfStillInFightingRange());
        }
        else
        {
            ChangeToChasing();
        }
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
            meleeAttack.Sweep(attackStats);

            yield return attackDurationWFS;
        }
    }

    IEnumerator CheckIfStillInFightingRange()
    {
        yield return null;
        Collider[] hits = fightAreaDetector.GetCollisionsInArea();
        while (hits.Length > 0)
        {
            hits = fightAreaDetector.GetCollisionsInArea();
            yield return null;
        }
        ChangeToChasing();
    }

    // ==== State trasitions

    private void ChangeToChasing()
    {
        stateMachine.ChangeState(typeof(MobileMeleeEnemyChasingState));
    }
}
