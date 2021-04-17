using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AreaDetector : MonoBehaviour
{
    public System.Action<GameObject> triggerEnterCallback;
    public System.Action<GameObject> triggerExitCallback;
    [SerializeField] private string[] relevantTags;

    private void OnTriggerEnter(Collider other)
    {
        if (relevantTags.Contains(other.tag))
            triggerEnterCallback.Invoke(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (relevantTags.Contains(other.tag))
            triggerExitCallback.Invoke(other.gameObject);
    }
}
