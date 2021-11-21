using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform playerRoot;
    [SerializeField] private Animator animator;

    [Header("Gameplay tweeking fields")]
    [SerializeField] private float speed;
    [SerializeField] private float turnSmoothTime = 0.1f;

    // Internal attributes
    private float horizontalInput, verticalInput;
    private Vector3 direction;
    private Vector3 relativeDirection;
    private float currSpeed;
    private float turnSmoothVelocity;
    private Transform camTransform;

    [Header("Estados")]
    [SerializeField] PlayerChargingState pcs;
    [SerializeField] PlayerDefendingState pds;

    public override void Enter()
    {
        animator.SetBool("Running", true);
        HandleInput();
        var rt = transform.parent.GetComponent<RoomTransition>();
        var camScript = rt.currCam;
        camTransform = camScript.transform;
    }

    public override void Exit()
    {
        Debug.Log("");
        animator.SetBool("Running", false);
        animator.SetBool("PushingForward", false);
        animator.SetBool("PushingBackwards", false);
    }


    public override void HandleInput()
    {
        direction = base.stateMachine.inputManager.actionMove.ReadValue<Vector2>();
    }

    public override void PhysicsUpdate()
    {
        Vector3 camF = camTransform.forward;
        Vector3 camR = camTransform.right;

        camF.y = 0;
        camR.y = 0;

        camF = camF.normalized;
        camR = camR.normalized;

        relativeDirection = new Vector3(direction.x, 0f, direction.y).normalized;
        direction = (camF * relativeDirection.z + camR * relativeDirection.x).normalized;

        State otherSMState = stateMachine.GetOtherStateMachineCurrentState();

        if (direction.magnitude >= 0.1f && otherSMState.GetType() != typeof(PlayerDraggingState) && pcs.canTurn)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(playerRoot.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            playerRoot.rotation = Quaternion.Euler(0f, angle, 0f);

            if(otherSMState.GetType() == typeof(PlayerChargingState))
            {
                currSpeed = speed / 2;
            }
            else if(otherSMState.GetType() == typeof(PlayerDefendingState))
            {
                currSpeed = pds.defendingSpeed;
            }
            else
            {
                currSpeed = speed;
            }

            controller.Move(direction * currSpeed * Time.deltaTime);
        }
        else if(otherSMState.GetType() == typeof(PlayerDraggingState))
        {
            Vector2 directionInR2 = new Vector2(direction.x, direction.z);
            Vector2 forwardInR2 = new Vector2(transform.forward.x, transform.forward.z);

            bool movingForward = (Vector2.Dot(directionInR2, forwardInR2) > 0);
            bool isMoving = directionInR2.magnitude > 0.1f;

            animator.SetBool("PushingForward", movingForward && isMoving);
            animator.SetBool("PushingBackwards", !movingForward && isMoving);
            animator.SetFloat("MoveAmount", directionInR2.magnitude);

            currSpeed = speed / 2;

            // if(Math.Abs(transform.forward.x) > Math.Abs(transform.forward.z))
            // {
            //     direction.z = 0f;
            // }
            // else
            // {
            //     direction.x = 0f;
            // }

            controller.Move(direction * currSpeed * Time.deltaTime);
        }
        else
        {
            base.stateMachine.ChangeState(typeof(PlayerIdleState));
        }
    }
}