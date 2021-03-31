using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float maxDistance;

    private float distanceTravelled;

    void Update()
    {
        float distanceToMove = speed * Time.deltaTime;
        distanceTravelled += distanceToMove;
        rb.MovePosition(transform.position + (transform.forward * distanceToMove));    

        if(distanceTravelled >= maxDistance)
        {
            DestructionProcess();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // TODO
        // 1. Deal damage to what it hit
        // 2. Play destruction VFX/animation
        // 3. Self destruct
        DestructionProcess();
    }

    private void DestructionProcess()
    {
        Destroy(gameObject);
    }
}
