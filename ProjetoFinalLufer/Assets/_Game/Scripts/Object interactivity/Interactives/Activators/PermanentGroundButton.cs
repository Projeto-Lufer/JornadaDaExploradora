using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentGroundButton : Activator
{
    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Push" || other.gameObject.tag == "Player")
        {
            Interact();
        }
    }

    public override void Interact()
    {
        if (!isActivated)
        {
            isActivated = true;

            base.Interact();
        }
    }
}
