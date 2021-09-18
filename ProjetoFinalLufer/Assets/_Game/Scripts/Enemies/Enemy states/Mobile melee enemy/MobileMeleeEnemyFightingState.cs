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
    [SerializeField] private float attackCooldownTime;
    [SerializeField] private ComboElement attackStats;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float chaseDelay;

    private WaitForSeconds attackTotalTimeWFS;
    private WaitForSeconds attackWindUpTimeWFS;
    private WaitForSeconds chaseDelayWFS;
    private float turnSmoothVelocity;

    private bool targetInRange;

    private void Start()
    {
        attackTotalTimeWFS = new WaitForSeconds(attackStats.totalTime);
        chaseDelayWFS = new WaitForSeconds(chaseDelay);
        attackWindUpTimeWFS = new WaitForSeconds(attackStats.windUp);
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
            for (float i = 0; i < attackStats.cooldown; i += Time.deltaTime)
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

                stateMachine.canChangeStates = false;
                PlayAnimationTrigger("Attacking");
                yield return attackWindUpTimeWFS;
                meleeAttack.Sweep(attackStats);
                yield return attackTotalTimeWFS;
                stateMachine.canChangeStates = true;
            }

            yield return null;
        }
    }

    IEnumerator CheckIfStillInFightingRange()
    {
        yield return null;
        targetInRange = true;
        Collider[] hits = fightAreaDetector.GetCollisionsInArea();

        while (true)
        {
            if (hits.Length > 0 && fightAreaDetector.GetHasLineOfSight(hits[0].transform))
            {
                hits = fightAreaDetector.GetCollisionsInArea();
            }
            else
            {
                targetInRange = false;
                yield return chaseDelayWFS;
                ChangeToChasing();
            }
            yield return null;
        }
    }

    // ==== State trasitions

    private void ChangeToChasing()
    {
        stateMachine.ChangeState(typeof(MobileMeleeEnemyChasingState));
    }
}
