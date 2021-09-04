using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveIdentifier : MonoBehaviour
{
    [SerializeField] private List<Interactive> interactivesInRange = new List<Interactive>();

    private void OnTriggerEnter(Collider other)
    {
        Interactive interactive = other.GetComponentInChildren<Interactive>();

        if(interactive != null)
        {
            interactivesInRange.Add(interactive);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactive interactive = other.GetComponentInChildren<Interactive>();

        if (interactive != null)
        {
            interactivesInRange.Remove(interactive);
        }
    }

    public bool GetHasInteractibleInRange()
    {
        return interactivesInRange.Count > 0;
    }

    public Interactive PopMostrelevantInteractive()
    {
        if(interactivesInRange.Count > 0)
        {
            Interactive interactive = interactivesInRange[0];
            interactivesInRange.Remove(interactive);
            return interactive;
        }
        return null;
    }

    public Interactive PeekMostRelevantInteractive()
    {
        if (interactivesInRange.Count > 0)
        {
            Interactive interactive = interactivesInRange[0];
            return interactive;
        }
        return null;
    }
}
