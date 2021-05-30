using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float jumpSpeed;

    private GameObject PlayerActionStates;
    private float directionY;

    // Start is called before the first frame update
    void Start()
    {
        PlayerActionStates = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        State currentState = PlayerActionStates.GetComponent<ConcurrentStateMachine>().GetCurrentState();

        if(currentState.GetType() == typeof(PlayerNotActingState))
        {
            if (controller.isGrounded && Input.GetButtonDown("Jump"))
            {
                directionY = jumpHeight;
            }

            directionY += Physics.gravity.y * Time.deltaTime;

            direction.y = directionY;

            controller.Move(direction * jumpSpeed * Time.deltaTime);
        }
    }
}
