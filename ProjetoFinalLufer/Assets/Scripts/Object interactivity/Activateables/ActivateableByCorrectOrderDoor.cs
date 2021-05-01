using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateableByCorrectOrderDoor : ActivateableByCorrectOrder
{
    protected override void ExecuteActivation()
    {
        Destroy(gameObject);
    }
}
