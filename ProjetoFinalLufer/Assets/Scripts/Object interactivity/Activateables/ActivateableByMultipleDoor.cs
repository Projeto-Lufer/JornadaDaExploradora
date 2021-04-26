using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateableByMultipleDoor : ActivateableByMultiple
{
    protected override void ExecuteActivation()
    {
        Destroy(gameObject);
    }
}
