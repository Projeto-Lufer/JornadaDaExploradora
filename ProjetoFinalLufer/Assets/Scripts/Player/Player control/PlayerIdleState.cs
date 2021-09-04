using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : ConcurrentState
{
    private bool canMove;
    private Vector2 direction = Vector2.zero;


    public override void HandleInput()
    {
        direction = base.stateMachine.inputManager.actionMove.ReadValue<Vector2>();

        State otherSMState = stateMachine.GetOtherStateMachineCurrentState();

        canMove = otherSMState.GetType() != typeof(PlayerLiftingState) &&
                    otherSMState.GetType() != typeof(PlayerAttackingState) &&
                    otherSMState.GetType() != typeof(PlayerDialogueState);

        if (canMove && direction != Vector2.zero)
        {
            base.stateMachine.ChangeState(typeof(PlayerMovingState));
        }
    }
}
