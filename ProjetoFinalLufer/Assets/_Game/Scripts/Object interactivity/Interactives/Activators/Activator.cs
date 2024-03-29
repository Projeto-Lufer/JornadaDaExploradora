using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activator : Interactive
{
    [SerializeField] protected Activateable objectToActivate;
    [SerializeField] protected Material activatedMaterial;

    protected Material deactivatedMaterial;
    [SerializeField] protected MeshRenderer meshRenderer;

    protected virtual void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if(renderer != null)
        {
            meshRenderer = renderer;
        }
        deactivatedMaterial = meshRenderer.material;
    }

    public override void Interact()
    {
        meshRenderer.material = activatedMaterial;
        objectToActivate.Activate();
        objectToActivate.Activate(gameObject);
    }
}
