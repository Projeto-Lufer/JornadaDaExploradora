using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcurrentStateMachine : StateMachine
{
    [SerializeField] private StateMachine otherStateMachine;

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
