using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobileMeleeEnemyChasingState : SimpleAnimatableState
{
    [Header("External references")]
    [SerializeField] private RangeDetector chaseAreaDetector;
    [SerializeField] private RangeDetector fightAreaDetector;
    [SerializeField] private NavMeshAgent agent;

    public override void Enter()
    {
        agent.isStopped = false;
        base.PlayAnimationTrigger("Walking");

        Collider[] hits = chaseAreaDetector.GetCollisionsInArea();
        if (hits.Length > 0)
        {
            GameObject target = hits[0].gameObject;
            PlayAnimationTrigger("Fighting");
            StartCoroutine(Chase(target.transform));
            StartCoroutine(CheckIfStillInChasingRange(target.transform));
            StartCoroutine(CheckIfInFightingRange());
        }
        else
        {
            ChangeToPatrolling();
        }
    }

    public override void Exit()
    {
        StopAllCoroutines();
    }

    IEnumerator Chase(Transform target)
    {
        while (true)
        {
            agent.destination = target.position;
            yield return null;
        }
    }

    IEnumerator CheckIfStillInChasingRange(Transform target)
    {
        yield return null;
        Collider[] hits = chaseAreaDetector.GetCollisionsInArea();
        while (hits.Length > 0)
        {
            hits = chaseAreaDetector.GetCollisionsInArea();
            yield return null;
        }
        ChangeToPatrolling();
    }

    IEnumerator CheckIfInFightingRange()
    {
        Collider[] hits = fightAreaDetector.GetCollisionsInArea();
        while (hits.Length == 0)
        {
            hits = fightAreaDetector.GetCollisionsInArea();
            yield return null;
        }
        ChangeToFighting();
    }

    // ==== State trasitions

    private void ChangeToPatrolling()
    {
        stateMachine.ChangeState(typeof(MobileMeleeEnemyPatrollingState));
    }

    private void ChangeToFighting()
    {
        Debug.Log("Change to fighting");
        agent.isStopped = true;
        stateMachine.ChangeState(typeof(MobileMeleeEnemyFightingState));
    }
}
