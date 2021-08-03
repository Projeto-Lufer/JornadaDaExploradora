using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private PlayerInputManager inputManager;

    [SerializeField] private GameObject PlayerActionStates;
    private float directionY;

    void Update()
    {
        Vector3 direction = Vector3.zero;

        State currentState = PlayerActionStates.GetComponent<ConcurrentStateMachine>().GetCurrentState();

        if (currentState.GetType() == typeof(PlayerNotActingState))
        {
            if (controller.isGrounded && inputManager.actionJump.triggered)
            {
                directionY = jumpHeight;
            }

            directionY += Physics.gravity.y * Time.deltaTime;

            direction.y = directionY;

            controller.Move(direction * jumpSpeed * Time.deltaTime);
        }
    }
}
