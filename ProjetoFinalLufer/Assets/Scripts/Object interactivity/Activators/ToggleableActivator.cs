using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableActivator : Activator
{
    private bool isActivated = false;

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
