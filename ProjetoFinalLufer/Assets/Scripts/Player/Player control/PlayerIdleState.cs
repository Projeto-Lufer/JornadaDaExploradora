using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State
{
    
    [SerializeField] private PlayerMovingState movingState;

    /*
    [SerializeField] private PlayerAttackingState attackingState;
    [SerializeField] private PlayerDraggingState draggingState;
    [SerializeField] private PlayerLiftingState liftingState;
    */


    private float horizontalInput, verticalInput;

    public override void HandleInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            base.stateMachine.ChangeState(movingState);
        }
    }

    public override void Enter() { }

    public override void PhysicsUpdate() { }

    public override void LogicUpdate() { }

    public override void Exit() { }
}
