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
            Interactive interactive = interactiveIdentifier.PopMostrelevantInteractive();
            //Debug.Log("Interactive name: " + interactive.ToString());

            if(interactive != null)
            {
                GameObject objectInteracted = interactive.Interact(gameObject);

                if (objectInteracted.GetComponent<LiftableObject>() != null)
                {
                    objectManipulator.LiftObject(objectInteracted);
                    base.stateMachine.ChangeState(typeof(PlayerLiftingState));
                }
                else if (objectInteracted.GetComponent<PushableObject>() != null)
                {
                    /*
                    state = playerState.dragging;
                    objectManipulator.GrabObject(objectInteracted);
                    StartCoroutine(haltedTimerCoroutine(liftingHaltDuration));
                    */
                }
            }
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            stateMachine.ChangeState(typeof(PlayerAttackingState));
        }
    }
}
