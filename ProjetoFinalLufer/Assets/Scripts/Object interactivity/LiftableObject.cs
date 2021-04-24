using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftableObject : MonoBehaviour, Interactive
{
    [SerializeField] private Collider collider;
    [SerializeField] private Rigidbody rigidbody;

    [SerializeField] private float throwingVelocity;

    public GameObject Interact(GameObject interactor)
    {
        return gameObject;
    }

    public void Lift(Transform liftedPosition)
    {
        SetColliderAndGravityEnabled(false);
        GoToLiftedPosition(liftedPosition);
    }

    public void Release()
    { 
        transform.parent = null;
        SetColliderAndGravityEnabled(true);
    }

    public void PutDown(Vector3 droppingPosition)
    {
        Release();
        transform.position = droppingPosition;
    }

    public void Throw(Vector3 throwingDirection)
    {
        Release();
        rigidbody.velocity = throwingDirection * throwingVelocity;
    }

    private void SetColliderAndGravityEnabled(bool enabled)
    {
        collider.enabled = enabled;
        rigidbody.useGravity = enabled;
    }

    private void GoToLiftedPosition(Transform liftedPosition)
    {
        //transform.position = liftedPosition.position;
        transform.SetPositionAndRotation(liftedPosition.position, liftedPosition.rotation);
        transform.parent = liftedPosition;
    }
}
