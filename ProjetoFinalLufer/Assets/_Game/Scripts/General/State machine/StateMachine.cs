using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State[] allStates;

    [SerializeField] State startingState;
    private State currentState;

    private Dictionary<System.Type, State> statesDictionary;

    private void Start()
    {
        InitializeDictionary();
        allStates = null; // discarded to spare memory
        currentState = startingState;
        currentState.Enter();
    }

    public State GetCurrentState()
    {
        return currentState;
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

    public void ChangeState(System.Type newState)
    {
        currentState.Exit();

        currentState = statesDictionary[newState];
        currentState.Enter();
    }

    public void ChangeState(System.Type newState, GameObject gameObject)
    {
        currentState.Exit();

        currentState = statesDictionary[newState];
        currentState.Enter(gameObject);
    }

    private void InitializeDictionary()
    {
        statesDictionary = new Dictionary<System.Type, State>();

        foreach(State state in allStates)
        {
            statesDictionary[state.GetType()] = state;
        }
    }
}
