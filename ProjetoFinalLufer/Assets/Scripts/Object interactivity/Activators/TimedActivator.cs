using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedActivator : DeactivateableActivator
{
    [SerializeField] private float activatedTime = 1;

    private WaitForSeconds activatedTimeWFS;

    protected override void Start()
    {
        base.Start();
        activatedTimeWFS = new WaitForSeconds(activatedTime);
    }

    public override void Interact()
    {
        if (!base.isActive)
        {
            base.Interact();
            base.Interact(gameObject);
            base.isActive = true;
            StartCoroutine(DeactivationTimer());
        }
        else // Resets the timer
        {
            StopAllCoroutines();
            StartCoroutine(DeactivationTimer());
        }
    }

    public override void Deactivate()
    {
        StopAllCoroutines();
        base.Deactivate();
    }

    private IEnumerator DeactivationTimer()
    {
        yield return activatedTimeWFS;
        Deactivate();
    }
}
