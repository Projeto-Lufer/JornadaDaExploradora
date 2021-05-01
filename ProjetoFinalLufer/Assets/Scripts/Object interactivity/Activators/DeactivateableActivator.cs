using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateableActivator : Activator
{
    protected bool isActive;
    
    public virtual void Deactivate()
    {
        base.meshRenderer.material = base.deactivatedMaterial;
        isActive = false;
        base.objectToActivate.Deactivate();
        base.objectToActivate.Deactivate(gameObject);
    }
}
