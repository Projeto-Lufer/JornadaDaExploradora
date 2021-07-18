using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDraggingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private ObjectManipulator objectManipulator;

    public override void HandleInput()
    {
        if (stateMachine.inputManager.actionInteract.triggered || stateMachine.inputManager.actionCancel.triggered)
        {
            objectManipulator.ReleaseObject();
            base.stateMachine.ChangeState(typeof(PlayerNotActingState));
        }
    }
}
