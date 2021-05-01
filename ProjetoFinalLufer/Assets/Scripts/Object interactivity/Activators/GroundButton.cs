using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButton : Activator
{
    private bool isActivated = false;

   /* private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Push"))
        {
            Interact();
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Push")
        {
            Interact();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interact();
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
