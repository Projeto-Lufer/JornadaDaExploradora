using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatableDoor : ActivateableByMultiple
{
    protected override void ExecuteActivation()
    {
        gameObject.SetActive(false);
    }

    protected override void ExecuteDeactivation()
    {
        gameObject.SetActive(true);
    }

}
