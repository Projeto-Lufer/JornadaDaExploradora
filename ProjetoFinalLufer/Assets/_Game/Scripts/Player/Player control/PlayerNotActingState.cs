using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotActingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private InteractiveIdentifier interactiveIdentifier;
    [SerializeField] private ObjectManipulator objectManipulator;

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
                else if(interactiveType.IsSubclassOf(typeof(Activator)) && interactiveType != typeof(GroundButton))
                {
                    interactive.Interact();
                }
                else if (interactiveType == typeof(PushableObject))
                {
                    interactiveIdentifier.PopMostrelevantInteractive();
                    interactive.Interact();
                    objectManipulator.GrabObject(interactive.gameObject);
                    base.stateMachine.ChangeState(typeof(PlayerDraggingState));                 
                }
                else if (interactiveType == typeof(InteractiveDoor))
                {
                    interactive.Interact(transform.parent.gameObject);
                }
            }
        }
        else if (stateMachine.inputManager.actionAttack1.triggered)
        {
            stateMachine.ChangeState(typeof(PlayerAttackingState));
        }
        else if(stateMachine.inputManager.actionAttack2.triggered)
        {
            stateMachine.ChangeState(typeof(PlayerChargingState));
        }
        else if (stateMachine.inputManager.actionDefend.triggered)
        {
            stateMachine.ChangeState(typeof(PlayerDefendingState));
        }
    }
}
