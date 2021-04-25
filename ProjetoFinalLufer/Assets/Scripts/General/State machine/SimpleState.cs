using UnityEngine;
using System.Collections;

public class SimpleState : State
{
    protected StateMachine stateMachine;

    private void OnValidate()
    {
        stateMachine = GetComponent<StateMachine>();
    }
}
