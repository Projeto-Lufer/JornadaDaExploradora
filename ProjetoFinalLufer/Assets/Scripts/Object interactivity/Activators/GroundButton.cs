using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButton : Activator
{
    private bool isActivated = false;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        if (other.gameObject.tag == "Push" || other.gameObject.tag == "Player")
        {
            Interact();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Push" || other.gameObject.tag == "Player")
        {
            Interact();
        }
    }

    public override void Interact()
    {
        if (!isActivated)
        {
            isActivated = true;

            base.Interact();
        }
        else
        {
            isActivated = false;
            base.meshRenderer.material = base.deactivatedMaterial;
            objectToActivate.Deactivate();
            objectToActivate.Deactivate(gameObject);
        }
    }
}
