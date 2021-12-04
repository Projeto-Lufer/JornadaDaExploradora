using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReceivingItemState : ConcurrentState
{
    [SerializeField] private ItemDescriptionPopup popup;
    public override void Enter()
    {
        base.stateMachine.ChangeOtherStateMachineState(typeof(PlayerIdleState));
    }

    public override void HandleInput()
    {
        if (popup.canClosePopup && stateMachine.inputManager.input.actions["Interact"].triggered)
        {
            popup.HidePopup();
            stateMachine.ChangeState(typeof(PlayerNotActingState));
        }
    }
}