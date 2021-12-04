using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : ConcurrentState
{
    private bool canMove;
    private Vector2 direction = Vector2.zero;
    [SerializeField] private Animator animator;

    public override void Enter()
    {
        animator.SetBool("Idle", true);
    }

    public override void HandleInput()
    {
        direction = base.stateMachine.inputManager.actionMove.ReadValue<Vector2>();

        System.Type otherSMStateType = stateMachine.GetOtherStateMachineCurrentState().GetType();

        canMove = otherSMStateType != typeof(PlayerLiftingState) &&
                    otherSMStateType != typeof(PlayerAttackingState) &&
                    otherSMStateType != typeof(PlayerDialogueState) &&
                    otherSMStateType != typeof(FlinchingState) &&
                    otherSMStateType != typeof(PlayerReceivingItemState);

        if (canMove && direction != Vector2.zero)
        {
            animator.SetBool("Idle", false);
            base.stateMachine.ChangeState(typeof(PlayerMovingState));
        }
    }
}