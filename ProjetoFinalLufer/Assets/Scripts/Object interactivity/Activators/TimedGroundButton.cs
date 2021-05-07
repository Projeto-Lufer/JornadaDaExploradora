using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedGroundButton : Activator
{
    private bool isActivated = false;
    [SerializeField] private float activatedTime;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        if (other.gameObject.tag == "Push" || other.gameObject.tag == "Player")
        {
            Interact();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Push" || other.gameObject.tag == "Player")
        {
            StartCoroutine(StartDeactivation());
        }
    }

    public override void Interact()
    {
        if (!isActivated)
        {
            isActivated = true;

            base.Interact();
        }
        else
        {
            isActivated = false;
            base.meshRenderer.material = base.deactivatedMaterial;
            objectToActivate.Deactivate();
            objectToActivate.Deactivate(gameObject);
        }
    }

    private IEnumerator StartDeactivation()
    {
        yield return new WaitForSeconds(activatedTime);
        Interact();
    }
}
