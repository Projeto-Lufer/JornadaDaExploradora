using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : Interactive
{

    [SerializeField] private Collider collider;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform[] grabPositions;

    public GameObject Interact(GameObject interactor)
    {
        return gameObject;
    }

    public void Grab(Transform grabPosition)
    {
        float disx = transform.position.x - grabPosition.parent.transform.position.x;
        float disz = transform.position.z - grabPosition.parent.transform.position.z;

        SetColliderAndGravityEnabled(false);

        if(Mathf.Abs(disx) > Mathf.Abs(disz))
        {
            if(Mathf.Sign(disx) == -1)
            {
                grabPosition.parent.transform.SetPositionAndRotation(grabPositions[2].position, grabPositions[2].rotation);
            }
            else
            {
                grabPosition.parent.transform.SetPositionAndRotation(grabPositions[3].position, grabPositions[3].rotation);
            }
        }
        else
        {
            if (Mathf.Sign(disz) == -1)
            {
                grabPosition.parent.transform.SetPositionAndRotation(grabPositions[0].position, grabPositions[0].rotation);
            }
            else
            {
                grabPosition.parent.transform.SetPositionAndRotation(grabPositions[1].position, grabPositions[1].rotation);
            }
        }

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
