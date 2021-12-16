using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateableActivator : Activator
{
    protected bool isActive;

    public virtual void Deactivate()
    {
        if(base.meshRenderer != null)
        {
            Material[] auxMaterials = base.meshRenderer.materials;
            auxMaterials[materialIndexToChange] = base.deactivatedMaterial;
            base.meshRenderer.materials = auxMaterials;
        }
        isActive = false;
        base.objectToActivate.Deactivate();
        base.objectToActivate.Deactivate(gameObject);
        base.VFX?.SetActive(false);
    }

    public bool GetIsActive()
    {
        return isActive;
    }
}