using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour, Interactive
{

    [SerializeField] private Collider collider;
    [SerializeField] private Rigidbody rigidbody;

    public GameObject Interact(GameObject interactor)
    {
        return gameObject;
    }

    public void Grab(Transform grabPosition)
    {
        transform.SetPositionAndRotation(grabPosition.position, grabPosition.rotation);
        transform.parent = grabPosition;
    }

    public void Release()
    {
        transform.parent = null;
    }

}
