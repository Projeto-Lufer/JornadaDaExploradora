using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobileMeleeEnemyChasingState : SimpleAnimatableState
{
    [Header("External references")]
    [SerializeField] private AreaDetector chaseAreaDetector;
    [SerializeField] private AreaDetector fightAreaDetector;
    [SerializeField] private NavMeshAgent agent;


    private void Start()
    {
        chaseAreaDetector.triggerExitCallback = ChangeToPatrolling;
        fightAreaDetector.triggerEnterCallback = ChangeToFighting;
    }

    public override void Enter(GameObject target)
    {
        agent.isStopped = false;
        base.PlayAnimationTrigger("Walking");
        StartCoroutine(Chase(target.transform));
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

    // ==== State trasitions

    private void ChangeToPatrolling(GameObject _)
    {
        stateMachine.ChangeState(typeof(MobileMeleeEnemyPatrollingState));
    }

    private void ChangeToFighting(GameObject target)
    {
        agent.isStopped = true;
        stateMachine.ChangeState(typeof(MobileMeleeEnemyFightingState), target);
    }

}
