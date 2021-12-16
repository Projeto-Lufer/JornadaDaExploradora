using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activator : Interactive
{
    [SerializeField] protected Activateable objectToActivate;
    [SerializeField] protected Material activatedMaterial;

    [SerializeField] private bool changeMaterialWhenActivated = true;
    protected Material deactivatedMaterial;
    [SerializeField] protected MeshRenderer meshRenderer;
    [SerializeField] protected int materialIndexToChange = 0;
    [SerializeField] protected GameObject VFX;

    protected virtual void Start()
    {
        if(changeMaterialWhenActivated)
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            if(renderer != null)
            {
                meshRenderer = renderer;
            }
            deactivatedMaterial = meshRenderer.materials[materialIndexToChange];
        }
    }

    public override void Interact()
    {
        if(deactivatedMaterial != null)
        {
            Material[] auxMaterials = meshRenderer.materials;
            auxMaterials[materialIndexToChange] = activatedMaterial;
            meshRenderer.materials = auxMaterials;
        }
        objectToActivate.Activate();
        objectToActivate.Activate(gameObject);
        VFX?.SetActive(true);
    }
}