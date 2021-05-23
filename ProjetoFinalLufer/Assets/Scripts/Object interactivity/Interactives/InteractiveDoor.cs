using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDoor : Interactive
{
    public override void Interact()
    {
        Destroy(this.gameObject);
    }
}
