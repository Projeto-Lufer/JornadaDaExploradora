using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private ObjectManipulator objectManipulator;

    public override void HandleInput()
    { 
        if (Input.GetButtonDown("Interact"))
        {
            objectManipulator.ThrowObject();
            base.stateMachine.ChangeState(typeof(PlayerNotActingState));
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            objectManipulator.ReleaseObject();
            base.stateMachine.ChangeState(typeof(PlayerNotActingState));
        }
    }
}
