using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateableByMultipleDoor : ActivateableByMultiple
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    // Tempor�rio, para os GDs poderem decidir o que � melhor
    [Tooltip("Com check: porta ir� desativar se um dos bot�es desligarem \nSem check: a porta ficar� aberta mesmo com um dos bot�es desligados ")]
    [SerializeField] private bool shouldDeactivateWhenNotAllAreActivating;
    private bool isActivated;

    protected override void ExecuteActivation()
    {
        if (!isActivated)
        {
            animator.SetTrigger("Open");
            audioSource.Play();
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
                audioSource.Play();
                isActivated = false;
            }
        }
    }
}
