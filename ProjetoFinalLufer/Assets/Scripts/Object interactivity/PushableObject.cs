using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : Interactive
{

    [SerializeField] private Collider collider;
    [SerializeField] private Rigidbody rigidbody;

    public GameObject Interact(GameObject interactor)
    {
        return gameObject;
    }

    public void Grab(Transform grabPosition)
    {
        SetColliderAndGravityEnabled(false);
        transform.SetPositionAndRotation(grabPosition.position, grabPosition.rotation);
        transform.parent = grabPosition;
    }

    public void Release()
    {
        SetColliderAndGravityEnabled(true);
        transform.parent = null;
    }
    private void SetColliderAndGravityEnabled(bool enabled)
    {
        rigidbody.useGravity = enabled;
    }
}
