using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private MeleeAttacks meleeAttack;
    [SerializeField] private Animator animator;

    [Header("Gameplay tweaking fields")]
    [SerializeField] private ComboElement[] comboSequence;

    // Internal variables
    private bool isAttacking;
    private int currIndex;
    private float attackTimeElapsed;
    private bool willTriggerNextAttack;

    public override void Enter()
    {
        animator.SetTrigger("Attack");
        currIndex = 0;
        StartCoroutine(AttackRoutine(comboSequence[currIndex++]));
    }

    public override void HandleInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (CheckIfCanTriggerNextAttack())
            {
                willTriggerNextAttack = true;
            }
        }
    }

    public override void LogicUpdate()
    {
        if (attackTimeElapsed >= comboSequence[currIndex-1].duration && willTriggerNextAttack)
        {
            animator.SetTrigger("Attack");

            StopAllCoroutines();
            StartCoroutine(AttackRoutine(comboSequence[currIndex++]));
        }
    }

    private bool CheckIfCanTriggerNextAttack()
    {
        return currIndex < comboSequence.Length  &&
            (attackTimeElapsed >= comboSequence[currIndex].comboWindowStart) &&
            (attackTimeElapsed <= comboSequence[currIndex].comboWindowFinish);
    }

    private IEnumerator AttackRoutine(ComboElement element)
    {
        willTriggerNextAttack = false;
        meleeAttack.Sweep(element);
        stateMachine.ChangeOtherStateMachineState(typeof(PlayerIdleState));
        isAttacking = true;

        for (attackTimeElapsed = 0 ; attackTimeElapsed < element.timeout ; attackTimeElapsed += Time.deltaTime)
        {
            yield return null;
        }
        
        isAttacking = false;
        stateMachine.ChangeState(typeof(PlayerNotActingState));
    }
}
