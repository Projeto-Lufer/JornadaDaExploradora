using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : ConcurrentState
{
    [SerializeField] private MeleeAttacks meleeAttack;
    [SerializeField] private Animator animator;

    public override void HandleInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
            //StartCoroutine(haltedTimerCoroutine(animationTimes["Attack"]));
            meleeAttack.Sweep();
        }
    }
}
