using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbPlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;

    public float speed = 0.0f;
    public float maxSpeed = 10.0f;
    public float acc = 2.5f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public bool addforce = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(addforce == true)
        {
            direction = new Vector3(h, 0, v);

            rb.AddForce(direction * speed);
        }
        else
        {
            if (h != 0 || v != 0)
            {
                if(speed < maxSpeed)
                {
                    speed += acc * Time.deltaTime;
                }
                rb.velocity = new Vector3(h, rb.velocity.y, v) * speed;
            }
            else
            {
                if(speed > 0)
                {
                    speed -= acc * Time.deltaTime;
                }
                rb.velocity = transform.forward * speed;
            }
        }

        if (rb.velocity.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}



