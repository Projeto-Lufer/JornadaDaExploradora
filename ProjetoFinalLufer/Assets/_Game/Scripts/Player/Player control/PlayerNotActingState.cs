using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerNotActingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private InteractiveIdentifier interactiveIdentifier;
    [SerializeField] private ObjectManipulator objectManipulator;

    public bool canDefend = false;
    private Coroutine holdAttackCheckCoroutine;

    public override void Exit()
    {
        StopAllCoroutines();
    }

    public override void HandleInput()
    {

        if (stateMachine.inputManager.actionInteract.triggered)
        {
            Interactive interactive = interactiveIdentifier.PeekMostRelevantInteractive();

            if(interactive != null)
            {
                System.Type interactiveType = interactive.GetType();
                if (interactiveType == typeof(LiftableObject))
                {
                    interactiveIdentifier.PopMostrelevantInteractive();
                    interactive.Interact();
                    objectManipulator.LiftObject(interactive.gameObject);
                    base.stateMachine.ChangeState(typeof(PlayerLiftingState));
                }
                else if(interactiveType.IsSubclassOf(typeof(Activator)) && interactiveType != typeof(GroundButton)
                    && !interactive.CompareTag("Receptor"))
                {
                    interactive.Interact();
                }
                else if (interactiveType == typeof(PushableObject))
                {
                    interactive.Interact();
                    objectManipulator.GrabObject(interactive.gameObject);
                    base.stateMachine.ChangeState(typeof(PlayerDraggingState));
                    interactiveIdentifier.SetInteractPopupShowState(false);
                }
                else if (interactiveType == typeof(InteractiveDoor) ||
                 interactiveType == typeof(ItemContainer) ||
                 interactiveType == typeof(Guardian))
                {
                    interactive.Interact(transform.parent.gameObject);
                }
                else if (interactiveType == typeof(InteractiveShield))
                {
                    interactive.Interact(transform.parent.gameObject);
                    interactiveIdentifier.SetInteractPopupShowState(false);
                }

            }
        }
        else if (stateMachine.inputManager.actionAttack1.triggered)
        {
            if (holdAttackCheckCoroutine == null)
            {
                holdAttackCheckCoroutine = StartCoroutine(CheckForAttackHoldInput());
            }
            else
            {
                StopCoroutine(holdAttackCheckCoroutine);
                holdAttackCheckCoroutine = StartCoroutine(CheckForAttackHoldInput());
            }
            stateMachine.inputManager.actionAttack1.canceled += StopCheckForAttackHoldInputCoroutine;
        }
        else if (stateMachine.inputManager.actionDefend.triggered && canDefend)
        {
            stateMachine.ChangeState(typeof(PlayerDefendingState));
        }
    }

    private void StopCheckForAttackHoldInputCoroutine(InputAction.CallbackContext _ = default)
    {
        if (holdAttackCheckCoroutine != null)
        {
            StopCoroutine(holdAttackCheckCoroutine);
        }
        holdAttackCheckCoroutine = null;
        stateMachine.inputManager.actionAttack1.canceled -= StopCheckForAttackHoldInputCoroutine;
        stateMachine.ChangeState(typeof(PlayerAttackingState));
    }

    IEnumerator CheckForAttackHoldInput()
    {
        for (float timer = 0; timer < InputSystem.settings.defaultHoldTime; timer += Time.deltaTime)
        {
            yield return null;
        }
        if(stateMachine.inputManager.actionAttack1.phase == InputActionPhase.Performed)
        {
            holdAttackCheckCoroutine = null;
            stateMachine.inputManager.actionAttack1.canceled -= StopCheckForAttackHoldInputCoroutine;
            stateMachine.ChangeState(typeof(PlayerChargingState));
        }
        else
        {
            StopCheckForAttackHoldInputCoroutine();
        }
    }
}