using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleAnimatableState : SimpleState
{
    private Animator animator;

    protected override void Awake()
    {
        base.Awake();
        animator = transform.parent.GetComponentInChildren<Animator>();
    }

    protected void PlayAnimationTrigger(string animationName)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            animator.SetTrigger(animationName);
        }
    }

    protected void SetAnimationBool(string animationName, bool shouldPlay)
    {
        animator.SetBool(animationName, shouldPlay);
    }
}
