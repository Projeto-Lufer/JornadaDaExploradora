using System.Collections;
using UnityEngine;

public class FlinchingState : SimpleAnimatableState
{
    [SerializeField] private State stateToReturnTo;

    private WaitForSeconds flinchingTimeWFS;

    public override void Enter(float flinchingTime)
    {
        flinchingTimeWFS = new WaitForSeconds(flinchingTime);
        base.PlayAnimationTrigger("Damaged");
        StartCoroutine(Flinching());
        //base.PlayAnimationTrigger("Flinch");
    }

    IEnumerator Flinching()
    {
        yield return flinchingTimeWFS;
        stateMachine.ChangeState(stateToReturnTo.GetType());
    }
}
