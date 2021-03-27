using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManipulator : MonoBehaviour
{
    [SerializeField] private Transform holdingPosition;

    private GameObject currentObject;
    private LiftableObject currLiftableObjectScript;

    public void LiftObject(GameObject liftedObject)
    {
        currentObject = liftedObject;
        currLiftableObjectScript = currentObject.GetComponent<LiftableObject>();

        currLiftableObjectScript.Lift(holdingPosition);
    }

    public void DropObject()
    {
        Vector3 droppingPosition = transform.position + (transform.forward * 1.5f);
        currLiftableObjectScript.Drop(droppingPosition);
        currLiftableObjectScript = null;
    }

    public void ThrowObject()
    {
        Vector3 throwingDirection = transform.forward;
        currLiftableObjectScript.Throw(throwingDirection);
    }
}
