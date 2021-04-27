using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDraggingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private ObjectManipulator objectManipulator;

    public override void HandleInput()
    {
        if (Input.GetButtonDown("Interact") || Input.GetButtonDown("Cancel"))
        {
            objectManipulator.ReleaseObject();
            base.stateMachine.ChangeState(typeof(PlayerNotActingState));
        }
    }
}
