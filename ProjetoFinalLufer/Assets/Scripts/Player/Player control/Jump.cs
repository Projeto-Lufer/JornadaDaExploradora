using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float jumpSpeed;


    private float directionY;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            directionY = jumpHeight;
        }

        directionY += Physics.gravity.y * Time.deltaTime;

        direction.y = directionY;

        controller.Move(direction * jumpSpeed * Time.deltaTime);
    }
}
