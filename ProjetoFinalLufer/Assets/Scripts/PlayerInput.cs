using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public enum playerState {normal, lifting, holding, dragging, halted};

    private playerState state = playerState.normal;
    [SerializeField] private InteractiveIdentifier interactiveIdentifier;
    [SerializeField] private ObjectManipulator objectManipulator;



    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if(state == playerState.lifting)
            {
                objectManipulator.ThrowObject();
                state = playerState.normal;
            }
            else
            {
                Interactive interactive = interactiveIdentifier.PopMostrelevantinteractive();

                if(interactive != null)
                {
                    GameObject objectInteracted = interactive.Interact(gameObject);

                    // Talvez trocar depois para fazer com que o script defina a tag do objeto como "liftable" 
                    //ou seja l� qual a intera��o ao inv�s de usar GetComponent
                    if(objectInteracted.GetComponent<LiftableObject>() != null)
                    {
                        state = playerState.lifting;
                        objectManipulator.LiftObject(objectInteracted);
                    }
                }
            }
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            if(state == playerState.lifting)
            {
                objectManipulator.DropObject();
                state = playerState.normal;
            }
        }
    }
}
