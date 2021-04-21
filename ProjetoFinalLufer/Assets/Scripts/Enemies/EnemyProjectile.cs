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
            Debug.Log("Went too far");
            DestructionProcess();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
        // TODO
        // 1. Deal damage to what it hit
        if(collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<HealthPoints>().ReduceHealth((int)damage);
        }
        // 2. Play destruction VFX/animation
        // 3. Self destruct
        DestructionProcess();
    }

    private void DestructionProcess()
    {
        Debug.Log("Will destroy");
        Destroy(gameObject);
    }
}
