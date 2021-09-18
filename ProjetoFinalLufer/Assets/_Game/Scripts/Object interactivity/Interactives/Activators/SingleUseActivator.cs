using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleUseActivator : Activator
{
    private bool hasBeenActivated;

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string sfxDoorUnlocked;

    public override void Interact()
    {
        if (!hasBeenActivated)
        {
            FMODUnity.RuntimeManager.PlayOneShot(sfxDoorUnlocked, transform.position);
            hasBeenActivated = true;
            base.Interact();
        }
    }
}
