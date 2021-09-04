using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateableByCorrectOrderDoor : ActivateableByCorrectOrder
{
    [SerializeField] private Animator animator;

    private bool isActivated;

    protected override void ExecuteActivation()
    {
        if (!isActivated)
        {
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
