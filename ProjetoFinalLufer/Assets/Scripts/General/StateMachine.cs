using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] State startingState;
    private State currentState;

    private void Start()
    {
        currentState = startingState;
        currentState.Enter();
    }

    private void Update()
    {
        currentState.HandleInput();
        currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        currentState.PhysicsUpdate();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }
}
