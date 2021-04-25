using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobileMeleeEnemyPatrollingState : SimpleAnimatableState
{
    [Header("External references")]
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private AreaDetector chaseAreaDetector;
    [SerializeField] private NavMeshAgent agent;

    // Internal variables
    private int nextPatrolPointIndex;

    private void Start()
    {
        chaseAreaDetector.triggerEnterCallback = StartChasing;
        nextPatrolPointIndex = 0;
    }

    public override void Enter()
    {
        agent.isStopped = false;
        base.PlayAnimationTrigger("Walking");
        StartCoroutine(Patrol());
    }

    public override void Exit()
    {
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

    // ==== State trasitions

    private void StartChasing(GameObject target)
    {
        stateMachine.ChangeState(typeof(MobileMeleeEnemyChasingState), target);
    }
}
