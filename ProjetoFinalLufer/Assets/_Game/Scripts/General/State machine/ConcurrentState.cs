using UnityEngine;
using System.Collections;

public class ConcurrentState : State
{
    protected ConcurrentStateMachine stateMachine;

    protected virtual void Start()
    {
        stateMachine = GetComponent<ConcurrentStateMachine>();
    }
}
