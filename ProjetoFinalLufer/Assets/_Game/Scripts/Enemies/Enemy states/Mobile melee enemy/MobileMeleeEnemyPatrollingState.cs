using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobileMeleeEnemyPatrollingState : SimpleAnimatableState
{
    [Header("External references")]
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private RangeDetector chaseAreaDetector;
    [SerializeField] private NavMeshAgent agent;

    // Internal variables
    private int nextPatrolPointIndex;

    private void Start()
    {
        nextPatrolPointIndex = 0;
    }

    public override void Enter()
    {
        agent.isStopped = false;
        base.SetAnimationBool("Walking", true);
        StartCoroutine(Patrol());

        StartCoroutine(CheckIfInChasingRange());
    }

    public override void Exit()
    {
        base.SetAnimationBool("Walking", false);

        StopAllCoroutines();
    }
    
    IEnumerator Patrol()
    {
        agent.destination = patrolPoints[nextPatrolPointIndex].position;

        while (true)
        {
            if (Vector3.Distance(patrolPoints[nextPatrolPointIndex].position, transform.position) <= 1.2)
            {
                if (++nextPatrolPointIndex >= patrolPoints.Length)
                    nextPatrolPointIndex = 0;

                agent.destination = patrolPoints[nextPatrolPointIndex].position;
            }
            yield return null; // Maybe make it wait for some seconds so it's not so performance intensive
        }
    }

    IEnumerator CheckIfInChasingRange()
    {
        yield return null;
        Collider[] hits = chaseAreaDetector.GetCollisionsInArea();
        while (true)
        {
            if(hits.Length == 0) // player not in range
            {
                hits = chaseAreaDetector.GetCollisionsInArea();
            }
            else if(chaseAreaDetector.GetHasLineOfSight(hits[0].transform))
            {
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
