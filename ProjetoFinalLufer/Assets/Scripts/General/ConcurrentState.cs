using UnityEngine;
using System.Collections;

public class ConcurrentState : State
{
    protected ConcurrentStateMachine stateMachine;

    private void OnValidate()
    {
        stateMachine = GetComponent<ConcurrentStateMachine>();
    }
}
