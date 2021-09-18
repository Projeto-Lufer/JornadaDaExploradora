using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateableByCorrectOrderDoor : ActivateableByCorrectOrder
{
    [SerializeField] private Animator animator;

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string sfxDoorOpening;

    private bool isActivated;

    protected override void ExecuteActivation()
    {
        if (!isActivated)
        {
            FMODUnity.RuntimeManager.PlayOneShot(sfxDoorOpening, transform.position);
            animator.SetTrigger("Open");
            isActivated = true;
        }
    }

    protected override void ExecuteDeactivation()
    {
        if (isActivated)
        {
            animator.SetTrigger("Close");
            isActivated = false;
        }
    }
}
