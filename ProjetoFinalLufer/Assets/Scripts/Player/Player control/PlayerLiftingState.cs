using UnityEngine;
using System.Collections;

public class PlayerLiftingState : ConcurrentState
{
    [Header("Gameplay tweeking fields")]
    [SerializeField] private float liftingDuration;

    private WaitForSeconds liftingDurationWFS;

    private void Start()
    {
        liftingDurationWFS = new WaitForSeconds(liftingDuration);
    }

    public override void Enter()
    {
        StartCoroutine(LiftingDurationTimer());
    }

    private IEnumerator LiftingDurationTimer()
    {
        stateMachine.ChangeOtherStateMachineState(typeof(PlayerIdleState));
        yield return liftingDurationWFS;
        stateMachine.ChangeState(typeof(PlayerHoldingState));
    }

    public override void Exit()
    {
        StopAllCoroutines();
    }
}
