using UnityEngine;
using System.Collections;

public class SimpleState : State
{
    protected StateMachine stateMachine;

    protected virtual void OnValidate()
    {
        stateMachine = GetComponent<StateMachine>();
    }
}
