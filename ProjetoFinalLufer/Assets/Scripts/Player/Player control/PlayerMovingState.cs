using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform playerRoot;

    [Header("Gameplay tweeking fields")]
    [SerializeField] private float speed;
    [SerializeField] private float turnSmoothTime = 0.1f;

    // Internal attributes
    private float horizontalInput, verticalInput;
    private Vector3 direction;
    private float currSpeed;
    private float turnSmoothVelocity;

    [SerializeField] PlayerChargingState pcs;

    public override void Enter()
    {
        HandleInput();
    }

    public override void HandleInput()
    { 
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    public override void PhysicsUpdate()
    {
        direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        State otherSMState = stateMachine.GetOtherStateMachineCurrentState();

        if (direction.magnitude >= 0.1f && otherSMState.GetType() != typeof(PlayerDraggingState) && pcs.canTurn == true)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(playerRoot.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            playerRoot.rotation = Quaternion.Euler(0f, angle, 0f);

            if(otherSMState.GetType() == typeof(PlayerChargingState))
            {
                currSpeed = speed / 2;
            }
            else
            {
                currSpeed = speed;
            }

            controller.Move(direction * currSpeed * Time.deltaTime);
        }
        else if(otherSMState.GetType() == typeof(PlayerDraggingState))
        {
            currSpeed = speed / 2;
            controller.Move(direction * currSpeed * Time.deltaTime);
        }
        else
        {
            base.stateMachine.ChangeState(typeof(PlayerIdleState));
        }
    }
}
