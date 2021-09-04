using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableActivator : DeactivateableActivator
{
    public override void Interact()
    {
        if (!base.isActive)
        {
            base.isActive = true;

            base.Interact();
        }
        else
        {
            base.Deactivate();
        }
    }
}
