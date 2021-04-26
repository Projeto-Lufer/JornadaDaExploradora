using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateableDoor : MonoBehaviour, Activateable
{
    public void Activate()
    {
        Destroy(gameObject);
    }
}
