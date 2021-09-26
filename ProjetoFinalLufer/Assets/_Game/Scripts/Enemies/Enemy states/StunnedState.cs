using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnedState : SimpleAnimatableState
{
    [SerializeField] private float stunTime;
    [SerializeField] private State stateToReturnTo;
    [SerializeField] private EnemyHealthPointsView HPView;

    private WaitForSeconds stunTimeWFS;

    private void Start()
    {
        stunTimeWFS = new WaitForSeconds(stunTime);
    }

    public override void Enter()
    {
        base.Enter();
        base.PlayAnimationTrigger("Damaged");
        base.stateMachine.canChangeStates = false;
        StartCoroutine(StunnedTimer());
    }

    public override void Exit()
    {
        HPView.SetStunnedVFXEnabled(false);
    }

    private IEnumerator StunnedTimer()
    {
        yield return stunTimeWFS;
        base.PlayAnimationTrigger("StopStun");
        base.stateMachine.canChangeStates = true;
        stateMachine.ChangeState(stateToReturnTo.GetType());
    }
}
