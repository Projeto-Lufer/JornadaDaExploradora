using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleAnimatableState : SimpleState
{
    private Animator animator;

    private void OnValidate()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    protected void PlayAnimationTrigger(string animationName)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            animator.SetTrigger(animationName);
        }
    }
}
