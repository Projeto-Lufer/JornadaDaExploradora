using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State[] allStates;

    [SerializeField] State startingState;
    private State currentState;
    public bool canChangeStates = true;

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

    private void ExitAndUpdateCurrentState(System.Type newState)
    {
        currentState.Exit();
        if(statesDictionary.ContainsKey(newState))
        {
            currentState = statesDictionary[newState];
        }
        else
        {
            Debug.Log(newState);
        }

    }

    public void ChangeState(System.Type newState)
    {
        if(canChangeStates)
        {
            ExitAndUpdateCurrentState(newState);
            currentState.Enter();
        }
    }

    public void ChangeState(System.Type newState, GameObject gameObjectForNewState)
    {
        if(canChangeStates)
        {
            ExitAndUpdateCurrentState(newState);
            currentState.Enter(gameObjectForNewState);
        }
    }

    public void ChangeState(System.Type newState, float floatForNewState)
    {
        if(canChangeStates)
        {
            ExitAndUpdateCurrentState(newState);
            currentState.Enter(floatForNewState);
        }
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
