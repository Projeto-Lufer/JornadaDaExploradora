using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseActivator : Activator
{
    [SerializeField] private float activatedTime = 1;

    private WaitForSeconds activatedTimeWFS;
    private bool isActive;

    public override void Interact()
    {
        if (!isActive)
        {
            isActive = true;
            activatedTimeWFS = new WaitForSeconds(activatedTime);
            base.Interact();
            StartCoroutine(changeMaterialTimer());
        }
    }

    private IEnumerator changeMaterialTimer()
    {
        yield return activatedTimeWFS;
        base.meshRenderer.material = base.deactivatedMaterial;
        isActive = false;
    }
}
