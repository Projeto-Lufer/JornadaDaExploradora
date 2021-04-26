using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : Interactive
{
    [SerializeField] private GameObject objectToActivate;

    public override void Interact(GameObject interactor)
    {
        objectToActivate.GetComponent<Activateable>().Activate();
    }
}
