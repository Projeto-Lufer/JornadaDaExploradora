using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleUseActivator : Activator
{
    private bool hasBeenActivated;

    public override void Interact()
    {
        if (!hasBeenActivated)
        {
            hasBeenActivated = true;
            base.Interact();
        }
    }
}
