using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveIdentifier : MonoBehaviour
{
    List<Interactive> interactivesInRange = new List<Interactive>();

    private void OnTriggerEnter(Collider other)
    {
        Interactive interactive = other.GetComponentInChildren<Interactive>();

        if(interactive != null)
        {
            interactivesInRange.Add(interactive);
            Debug.Log("Added: " + interactive.ToString());
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactive interactive = other.GetComponentInChildren<Interactive>();

        if (interactive != null)
        {
            interactivesInRange.Remove(interactive);
            Debug.Log("Removed: " + interactive.ToString());
        }
    }

    public Interactive Getmostrelevantinteractive()
    {
        if(interactivesInRange.Count > 0)
        {
            return interactivesInRange[0];
        }
        return null;
    }
}
