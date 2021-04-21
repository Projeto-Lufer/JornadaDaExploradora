using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float dashSpeed;
    public float dashTime;

    private float horizontal;
    private float vertical;
    private Vector3 direction;
    private float currSpeed;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    public void UpdateDirection(float horizontal, float vertical)
    {
        this.horizontal = horizontal;
        this.vertical = vertical;
    }

    void FixedUpdate()
    {
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            if(playerInput.GetState() != PlayerInput.playerState.dragging)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                currSpeed = speed;
            }
            else
            {
                currSpeed = speed / 2;
            }

            controller.Move(direction * currSpeed * Time.deltaTime);
        }
    }

    public void Dash()
    {
        StartCoroutine(DashAction(direction));
    }

    IEnumerator DashAction(Vector3 dashDirection)
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            controller.Move(dashDirection * speed * Time.deltaTime);
            yield return null;
        }

    }
}
