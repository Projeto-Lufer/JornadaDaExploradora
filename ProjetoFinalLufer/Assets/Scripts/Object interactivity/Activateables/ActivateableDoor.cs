using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateableDoor : Activateable
{
    public override void Activate()
    {
        Destroy(gameObject);
    }
}
