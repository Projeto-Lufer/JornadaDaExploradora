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
        if (Input.GetButtonDown("Interact"))
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
        else if (Input.GetButtonDown("Fire1"))
        {
            stateMachine.ChangeState(typeof(PlayerAttackingState));
        }
        else if(Input.GetMouseButtonDown(1))
        {
            stateMachine.ChangeState(typeof(PlayerChargingState));
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            stateMachine.ChangeState(typeof(PlayerDefendingState));
        }
    }
}
