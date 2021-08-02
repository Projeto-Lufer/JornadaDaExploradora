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
    [SerializeField] private float chaseDelay;

    private WaitForSeconds attackDurationWFS;
    private WaitForSeconds chaseDelayWFS;
    private float turnSmoothVelocity;

    private bool targetInRange;

    private void Start()
    {
        attackDurationWFS = new WaitForSeconds(attackStats.duration);
        chaseDelayWFS = new WaitForSeconds(chaseDelay);
    }

    public override void Enter()
    {
        Collider[] hits = fightAreaDetector.GetCollisionsInArea();
        if (hits.Length > 0)
        {
            GameObject target = hits[0].gameObject;
            base.SetAnimationBool("Fighting", true);
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
        base.SetAnimationBool("Fighting", false);

        StopAllCoroutines();
    }

    IEnumerator Fight(Transform target)
    {
        while (true)
        {
            base.SetAnimationBool("Fighting", true);
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

            if (targetInRange)
            {
                base.SetAnimationBool("Fighting", false);

                PlayAnimationTrigger("Attacking");
                meleeAttack.Sweep(attackStats);
                yield return attackDurationWFS;
            }

            yield return null;
        }
    }

    IEnumerator CheckIfStillInFightingRange()
    {
        yield return null;
        targetInRange = true;

        while (fightAreaDetector.GetCollisionsInArea().Length > 0)
        {
            yield return null;
        }

        targetInRange = false;
        yield return chaseDelayWFS;
        ChangeToChasing();
    }

    // ==== State trasitions

    private void ChangeToChasing()
    {
        stateMachine.ChangeState(typeof(MobileMeleeEnemyChasingState));
    }
}
