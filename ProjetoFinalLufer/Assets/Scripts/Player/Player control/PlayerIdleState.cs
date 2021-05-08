using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : ConcurrentState
{
    private float horizontalInput, verticalInput;
    private bool canMove;

    public override void HandleInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        State otherSMState = stateMachine.GetOtherStateMachineCurrentState();

        canMove = otherSMState.GetType() != typeof(PlayerLiftingState) &&
                    otherSMState.GetType() != typeof(PlayerAttackingState);

        if (canMove && (horizontalInput != 0 || verticalInput != 0))
        {
            base.stateMachine.ChangeState(typeof(PlayerMovingState));
        }
    }
}
