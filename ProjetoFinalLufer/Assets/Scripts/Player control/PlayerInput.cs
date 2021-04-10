using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public enum playerState {normal, lifting, holding, dragging, halted};

    private playerState state = playerState.normal;
    [SerializeField] private InteractiveIdentifier interactiveIdentifier;
    [SerializeField] private ObjectManipulator objectManipulator;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerCombat playerCombat;

    [SerializeField] private float liftingHaltDuration;
    [SerializeField] private float throwingHaltDuration;
    [SerializeField] private float droppingHaltDuration;


    void Update()
    {
        if(state == playerState.halted)
        {
            playerMovement.UpdateDirection(0, 0);
            return;
        }

        playerMovement.UpdateDirection(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Interact"))
        {
            if(state == playerState.holding)
            {
                objectManipulator.ThrowObject();
                state = playerState.normal;
                StartCoroutine(releaseTimerCoroutine(liftingHaltDuration));
            }
            else if(state == playerState.normal)
            {
                Interactive interactive = interactiveIdentifier.PopMostrelevantinteractive();

                if(interactive != null)
                {
                    GameObject objectInteracted = interactive.Interact(gameObject);

                    // Talvez trocar depois para fazer com que o script defina a tag do objeto como "liftable" 
                    //ou seja la qual a interacao ao inves de usar GetComponent
                    if(objectInteracted.GetComponent<LiftableObject>() != null)
                    {
                        state = playerState.lifting;
                        objectManipulator.LiftObject(objectInteracted);
                        StartCoroutine(releaseTimerCoroutine(throwingHaltDuration));
                    }
                }
            }
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            if(state == playerState.holding)
            {
                objectManipulator.DropObject();
                state = playerState.normal;
                StartCoroutine(releaseTimerCoroutine(droppingHaltDuration));
            }
        }
        else if (Input.GetKeyDown("space"))
        {
            playerMovement.Dash();
        }
        else if(Input.GetButtonDown("Fire1"))
        {
            //Ataque em arco
            if(Time.time >= playerCombat.nextAttack)
            {
                playerCombat.Sweep();
                playerCombat.nextAttack = Time.time + 1 / playerCombat.attackRate;
            }
        }
    }

    private playerState GetNextState()
    {
        switch (state)
        {
            case playerState.lifting:
                return playerState.holding;
            case playerState.holding:
                return playerState.normal;
        }
        // Caso nao ache nenhum tipo de comportamento, talvez nao devesse trocar
        return state;
    }

    private IEnumerator releaseTimerCoroutine(float seconds)
    {
        playerState nextState = GetNextState();
        state = playerState.halted;
        yield return new WaitForSeconds(seconds);
        state = nextState;
    }
}
