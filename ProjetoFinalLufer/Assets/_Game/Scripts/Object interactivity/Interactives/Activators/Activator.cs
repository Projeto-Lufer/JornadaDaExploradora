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

    protected virtual void Start()
    {
        if(changeMaterialWhenActivated)
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            if(renderer != null)
            {
                meshRenderer = renderer;
            }
            deactivatedMaterial = meshRenderer.material;
        }
    }

    public override void Interact()
    {
        if(deactivatedMaterial != null)
        {
            meshRenderer.material = activatedMaterial;
        }
        objectToActivate.Activate();
        objectToActivate.Activate(gameObject);
    }
}
