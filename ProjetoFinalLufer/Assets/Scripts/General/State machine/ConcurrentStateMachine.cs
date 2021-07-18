using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConcurrentStateMachine : StateMachine
{
    [SerializeField] private StateMachine otherStateMachine;

    public PlayerInputManager inputManager;

    public State GetOtherStateMachineCurrentState()
    {
        return otherStateMachine.GetCurrentState();
    }

    public void ChangeOtherStateMachineState(System.Type newState)
    {
        otherStateMachine.ChangeState(newState);
    }

    public void ChangeOtherStateMachineState(System.Type newState, GameObject gameObject)
    {
        otherStateMachine.ChangeState(newState, gameObject);
    }
}
