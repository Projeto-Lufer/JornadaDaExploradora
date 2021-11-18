using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDraggingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private ObjectManipulator objectManipulator;
    [SerializeField] private Animator animator;

    public override void Enter()
    {
        animator.SetBool("Pushing", true);
    }

    public override void Exit()
    {
        animator.SetBool("Pushing", false);
    }

    public override void HandleInput()
    {
        if (stateMachine.inputManager.actionInteract.triggered || stateMachine.inputManager.actionCancel.triggered)
        {
            objectManipulator.ReleaseObject();
            base.stateMachine.ChangeState(typeof(PlayerNotActingState));
        }
    }
}