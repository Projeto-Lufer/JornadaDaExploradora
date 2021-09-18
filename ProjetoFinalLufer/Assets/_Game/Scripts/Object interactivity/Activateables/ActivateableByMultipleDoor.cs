using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateableByMultipleDoor : ActivateableByMultiple
{
    [SerializeField] private Animator animator;
    
    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string sfxDoorOpening;

    // Tempor�rio, para os GDs poderem decidir o que e melhor
    [Tooltip("Com check: porta ira desativar se um dos botoes desligarem \nSem check: a porta ficara aberta mesmo com um dos botoes desligados ")]
    [SerializeField] private bool shouldDeactivateWhenNotAllAreActivating;
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
        if (shouldDeactivateWhenNotAllAreActivating)
        {
            if (isActivated)
            {
                animator.SetTrigger("Close");
                isActivated = false;
            }
        }
    }
}
