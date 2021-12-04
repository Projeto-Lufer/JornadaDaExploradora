using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveIdentifier : MonoBehaviour
{
    [SerializeField] private List<Interactive> interactivesInRange = new List<Interactive>();
    [SerializeField] private GameObject popupText;

    private void OnTriggerEnter(Collider other)
    {
        Interactive interactive = other.GetComponentInChildren<Interactive>();

        if(interactive != null && !interactivesInRange.Contains(interactive) && other.tag != "Receptor")
        {
            // gambiarra
            interactivesInRange.Clear();

            interactivesInRange.Add(interactive);

            SetInteractPopupShowState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactive interactive = other.GetComponentInChildren<Interactive>();

        if (interactive != null && interactivesInRange.Contains(interactive))
        {
            interactivesInRange.Remove(interactive);

            SetInteractPopupShowState(false);
        }
    }

    public void SetInteractPopupShowState(bool show)
    {
        popupText.SetActive(show);
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