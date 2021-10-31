using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobileMeleeEnemyPatrollingState : SimpleAnimatableState
{
    [Header("External references")]
    [SerializeField] private RangeDetector chaseAreaDetector;
    [SerializeField] private NavMeshAgent agent;
    public PatrolRoute patrolRoute;

    [SerializeField] private float distanceToPointToGoToNextPoint;

    // Internal variables
    private int nextPatrolPointIndex;

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
        patrolRoute.StartPatrolRoute();
        agent.SetDestination(patrolRoute.GetNextPatrolPointPosition());

        while (true)
        {
            if (Vector3.Distance(patrolRoute.GetNextPatrolPointPosition(), transform.position) <= distanceToPointToGoToNextPoint)
            {
                patrolRoute.GoToNextPatrolPoint();

                agent.destination = patrolRoute.GetNextPatrolPointPosition();
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
