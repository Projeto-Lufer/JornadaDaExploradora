using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private ObjectManipulator objectManipulator;

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string grassSteps;

    public override void HandleInput()
    { 
        if (stateMachine.inputManager.actionInteract.triggered)
        {
            objectManipulator.ThrowObject();
            base.stateMachine.ChangeState(typeof(PlayerNotActingState));
        }
        else if (stateMachine.inputManager.actionCancel.triggered)
        {
            objectManipulator.PutDownObject();
            base.stateMachine.ChangeState(typeof(PlayerNotActingState));
        }
    }
}
