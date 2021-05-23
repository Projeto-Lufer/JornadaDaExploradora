using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activator : Interactive
{
    [SerializeField] protected Activateable objectToActivate;
    [SerializeField] protected Material activatedMaterial;

    protected Material deactivatedMaterial;
    protected MeshRenderer meshRenderer;

    protected virtual void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        deactivatedMaterial = meshRenderer.material;
    }

    public override void Interact()
    {
        meshRenderer.material = activatedMaterial;
        objectToActivate.Activate();
        objectToActivate.Activate(gameObject);
    }
}
