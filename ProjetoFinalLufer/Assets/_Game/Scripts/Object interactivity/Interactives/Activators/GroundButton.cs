using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButton : Activator
{
    private bool isActivated = false;
    private bool playerIsOn = false;
    private bool boxIsOn = false;

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string sfxPressurePlateSpinning;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Push")
        {
            boxIsOn = true;
            if(!playerIsOn)
            {
                Interact();
            }
        }
        else if (other.gameObject.tag == "Player")
        {
            playerIsOn = true;
            if(!boxIsOn)
            {
                Interact();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Push")
        {
            boxIsOn = false;
            if (!playerIsOn)
            {
                Interact();
            }
        }
        else if (other.gameObject.tag == "Player")
        {
            playerIsOn = false;
            if (!boxIsOn)
            {
                Interact();
            }
        }
    }

    public override void Interact()
    {
        FMODUnity.RuntimeManager.PlayOneShot(sfxPressurePlateSpinning, transform.position);
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
}
