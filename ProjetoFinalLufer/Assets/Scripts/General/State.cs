using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    private void OnValidate()
    {
        stateMachine = GetComponent<StateMachine>();
    }

    protected StateMachine stateMachine;

    public abstract void Enter();

    public abstract void HandleInput();

    public abstract void PhysicsUpdate();

    public abstract void LogicUpdate();

    public abstract void Exit();
}
