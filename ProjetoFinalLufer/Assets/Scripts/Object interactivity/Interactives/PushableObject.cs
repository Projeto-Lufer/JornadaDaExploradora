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

    public void Grab(Transform grabber)
    {
        float disx = transform.position.x - grabber.parent.transform.position.x;
        float disz = transform.position.z - grabber.parent.transform.position.z;

        SetColliderAndGravityEnabled(false);

        if(Mathf.Abs(disx) > Mathf.Abs(disz))
        {
            if(Mathf.Sign(disx) == -1)
            {
                SetGrabberPositionAndRotation(2, grabber);
            }
            else
            {
                SetGrabberPositionAndRotation(3, grabber);
            }
        }
        else
        {
            if (Mathf.Sign(disz) == -1)
            {
                SetGrabberPositionAndRotation(0, grabber);
            }
            else
            {
                SetGrabberPositionAndRotation(1, grabber);
            }
        }

        transform.parent = grabber;
    }

    private void SetGrabberPositionAndRotation(int positionIndex, Transform grabber)
    {
        Transform currGrabPosition = grabPositions[positionIndex];

        Vector3 posDiscardingtY = new Vector3(currGrabPosition.position.x, grabber.position.y, currGrabPosition.position.z);

        grabber.parent.transform.SetPositionAndRotation(posDiscardingtY, grabPositions[positionIndex].rotation);
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
