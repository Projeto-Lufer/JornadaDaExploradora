using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedActivator : Activator
{
    [SerializeField] private float activatedTime = 1;

    private WaitForSeconds activatedTimeWFS;
    private bool isActivated;

    protected override void Start()
    {
        base.Start();
        activatedTimeWFS = new WaitForSeconds(activatedTime);
    }

    public override void Interact()
    {
        if (!isActivated)
        {
            base.Interact();
            base.Interact(gameObject);
            isActivated = true;
            StartCoroutine(DeactivationTimer());
        }
        else // Resets the timer
        {
            StopAllCoroutines();
            StartCoroutine(DeactivationTimer());
        }
    }

    private IEnumerator DeactivationTimer()
    {
        yield return activatedTimeWFS;
        isActivated = false;
        base.meshRenderer.material = base.deactivatedMaterial;
        base.objectToActivate.Deactivate();
        base.objectToActivate.Deactivate(gameObject);
    }
}
