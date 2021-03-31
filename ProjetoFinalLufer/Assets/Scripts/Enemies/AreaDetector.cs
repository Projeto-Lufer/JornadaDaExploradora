using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetector : MonoBehaviour
{
    public System.Action<GameObject> triggerEnterCallback;
    public System.Action<GameObject> triggerExitCallback;

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterCallback.Invoke(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitCallback.Invoke(other.gameObject);
    }
}
