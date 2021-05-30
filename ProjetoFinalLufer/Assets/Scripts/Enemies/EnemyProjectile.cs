using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Header("External references")]
    [SerializeField] private Rigidbody rb;

    [Header("Gameplay tweeking fields")]
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float maxDistance;

    private float distanceTravelled;
    private bool reflected = false;
    void FixedUpdate()
    {
        float distanceToMove = speed * Time.deltaTime;
        distanceTravelled += distanceToMove;
        rb.MovePosition(transform.position + (transform.forward * distanceToMove));    

        if(distanceTravelled >= maxDistance)
        {
            DestructionProcess();
        }
    }

    public void SetStartingPosition(Vector3 position, Quaternion rotation)
    {
        transform.SetPositionAndRotation(position, rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player") && !reflected)
        {
            collision.collider.GetComponent<HealthPoints>().ReduceHealth((int)damage);
            DestructionProcess();
        }
        else if(collision.collider.CompareTag("Shield") && !reflected)
        {
            transform.forward = collision.transform.parent.forward;
            reflected = true;
        }
        else if(collision.gameObject.layer == 3 && reflected)
        {
            collision.collider.GetComponent<HealthPoints>().ReduceHealth((int)damage);
            DestructionProcess();
        }
    }

    private void DestructionProcess()
    {
        // TODO:
        // Play destruction VFX/animation & sound
        distanceTravelled = 0;
        reflected = false;
        gameObject.SetActive(false);
    }
}
