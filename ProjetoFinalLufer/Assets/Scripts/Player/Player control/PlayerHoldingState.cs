using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private ObjectManipulator objectManipulator;

    // !!!! Relevant inherited attributes !!!!
    // stateMachine -> from State
    public override void Enter()
    {
        Debug.Log("Entrou no Holding");
    }

    public override void HandleInput()
    { 
        if (Input.GetButtonDown("Interact"))
        {
            objectManipulator.ThrowObject();
            stateMachine.ChangeState(typeof(PlayerNotActingState));
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            objectManipulator.ReleaseObject();
            stateMachine.ChangeState(typeof(PlayerNotActingState));
        }
    }
}
