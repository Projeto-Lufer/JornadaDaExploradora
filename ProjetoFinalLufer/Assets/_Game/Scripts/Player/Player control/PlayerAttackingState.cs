using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private MeleeAttacks meleeAttack;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerInCombatStateControl playerInCombatControl;

    [Header("Gameplay tweaking fields")]
    [SerializeField] private ComboElement[] comboSequence;

    // Internal variables
    private bool isAttacking;
    private int currIndex;
    private float attackTimeElapsed;
    private bool willTriggerNextAttack;

    public override void Enter()
    {
        animator.Play("Hit1");
        animator.SetBool("Fighting", true);
        playerInCombatControl.SetInCombat();
        currIndex = 0;
        StartCoroutine(AttackRoutine(comboSequence[currIndex++]));
    }

    public override void Exit()
    {
        animator.SetBool("Fighting", false);
    }

    public override void HandleInput()
    {
        if (stateMachine.inputManager.actionAttack1.triggered)
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
        // TODO: Tocar animacao de ataque
        meleeAttack.Sweep(element);
        stateMachine.ChangeOtherStateMachineState(typeof(PlayerIdleState));
        stateMachine.canChangeStates = false;

        isAttacking = true;

        for (attackTimeElapsed = 0 ; attackTimeElapsed < element.totalTime ; attackTimeElapsed += Time.deltaTime)
        {
            yield return null;
        }

        isAttacking = false;
        stateMachine.canChangeStates = true;
        stateMachine.ChangeState(typeof(PlayerNotActingState));
    }
}