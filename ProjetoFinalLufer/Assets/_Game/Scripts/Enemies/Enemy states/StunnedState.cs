using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnedState : SimpleAnimatableState
{
    [SerializeField] private float stunTime;
    [SerializeField] private State stateToReturnTo;

    private WaitForSeconds stunTimeWFS;

    private void Start()
    {
        stunTimeWFS = new WaitForSeconds(stunTime);
    }

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(StunnedTimer());
    }

    private IEnumerator StunnedTimer()
    {
        yield return stunTimeWFS;
        stateMachine.ChangeState(stateToReturnTo.GetType());
    }
}
