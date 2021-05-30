using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlinchingState : SimpleAnimatableState
{
    [SerializeField] private float flinchingTime;
    [SerializeField] private State stateToReturnTo;

    private WaitForSeconds flinchingTimeWFS;

    private void Start()
    {
        flinchingTimeWFS = new WaitForSeconds(flinchingTime);
    }

    public override void Enter()
    {
        StartCoroutine(Flinching());
        //base.PlayAnimationTrigger("Flinch");
        Debug.Log("Started Flinching");
    }

    IEnumerator Flinching()
    {
        yield return flinchingTimeWFS;
        Debug.Log("Stoped Flinching");
        stateMachine.ChangeState(stateToReturnTo.GetType());
    }
}
