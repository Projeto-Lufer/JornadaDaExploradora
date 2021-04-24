using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : ConcurrentState
{
    private float horizontalInput, verticalInput;
    private bool canMove;

    public override void Enter()
    {
        Debug.Log("Entrou no Idle");
    }

    public override void HandleInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //Debug.Log("Tipo do estado: " + stateMachine.GetOtherStateMachineCurrentState().GetType());
        canMove = stateMachine.GetOtherStateMachineCurrentState().GetType() != typeof(PlayerLiftingState);
        //Debug.Log("CanMove: " + canMove);
        if (canMove && (horizontalInput != 0 || verticalInput != 0))
        {
            base.stateMachine.ChangeState(typeof(PlayerMovingState));
        }
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}
