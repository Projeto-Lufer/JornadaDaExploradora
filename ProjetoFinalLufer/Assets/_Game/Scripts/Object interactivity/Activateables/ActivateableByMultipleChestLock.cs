using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateableByMultipleChestLock : ActivateableByMultiple
{
    [SerializeField] private ItemContainer container;

    protected override void ExecuteActivation()
    {
        container.SetIsLocked(false);
    }
    protected override void ExecuteDeactivation()
    {
        container.SetIsLocked(true);
    }
}
