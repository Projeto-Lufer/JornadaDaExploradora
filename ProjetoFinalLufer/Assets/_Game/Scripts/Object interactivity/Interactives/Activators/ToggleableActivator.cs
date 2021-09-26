using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableActivator : DeactivateableActivator
{
    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string sfxLightReceiverActivating;
    public override void Interact()
    {
        if (!base.isActive)
        {
            base.isActive = true;
            FMODUnity.RuntimeManager.PlayOneShot(sfxLightReceiverActivating, transform.position);

            base.Interact();
        }
        else
        {
            base.Deactivate();
        }
    }
}
