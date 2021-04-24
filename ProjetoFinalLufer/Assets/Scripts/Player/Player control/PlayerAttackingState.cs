using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private MeleeAttacks meleeAttack;
    [SerializeField] private Animator animator;

    [Header("Gameplay tweeking fields")]
    [SerializeField] private float[] timeBetweenAttacks;

    // Internal variables
    private List<WaitForSeconds> timeBetweenAttacksWFS;
    private bool isAttacking;

    private void Start()
    {
        timeBetweenAttacksWFS = new List<WaitForSeconds>();
        foreach (float time in timeBetweenAttacks)
        {
            timeBetweenAttacksWFS.Add(new WaitForSeconds(time));
        }
    }

    public override void Enter()
    {
        animator.SetTrigger("Attack");
        meleeAttack.Sweep();
        StartCoroutine(AttackDuration(timeBetweenAttacksWFS[0]));
    }

    public override void HandleInput()
    {
        if (!isAttacking)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Attack");
                meleeAttack.Sweep();
                StartCoroutine(AttackDuration(timeBetweenAttacksWFS[0]));
            }
        }
    }

    private IEnumerator AttackDuration(WaitForSeconds duration)
    {
        stateMachine.ChangeOtherStateMachineState(typeof(PlayerIdleState));
        isAttacking = true;
        yield return duration;
        isAttacking = false;
        stateMachine.ChangeState(typeof(PlayerNotActingState));
    }
}
