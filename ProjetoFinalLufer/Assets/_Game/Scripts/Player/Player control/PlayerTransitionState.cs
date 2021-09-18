using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerTransitionState : ConcurrentState
{
    private Vector2 direction = Vector2.zero;
    CinemachineBrain brain;

    public override void Enter()
    {
        brain = CinemachineCore.Instance.GetActiveBrain(0);
    }
    public override void LogicUpdate()
    {
        if(!brain.IsBlending)
        {
            //WIP
        }
    }
    // public override void HandleInput()
    // {
    //     direction = base.stateMachine.inputManager.actionMove.ReadValue<Vector2>();

    //     State otherSMState = stateMachine.GetOtherStateMachineCurrentState();

    //     canMove = otherSMState.GetType() != typeof(PlayerLiftingState) &&
    //                 otherSMState.GetType() != typeof(PlayerAttackingState) &&
    //                 otherSMState.GetType() != typeof(PlayerDialogueState);

    //     if (canMove && direction != Vector2.zero)
    //     {
    //         base.stateMachine.ChangeState(typeof(PlayerMovingState));
    //     }
    // }
}
