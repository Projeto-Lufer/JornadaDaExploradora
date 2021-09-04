using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateableByMultipleDoor : ActivateableByMultiple
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    // Temporário, para os GDs poderem decidir o que é melhor
    [Tooltip("Com check: porta irá desativar se um dos botões desligarem \nSem check: a porta ficará aberta mesmo com um dos botões desligados ")]
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
