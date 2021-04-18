using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public enum playerState {normal, lifting, holding, dragging, halted, attacking};

    private playerState state = playerState.normal;
    [SerializeField] private InteractiveIdentifier interactiveIdentifier;
    [SerializeField] private ObjectManipulator objectManipulator;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerCombat playerCombat;
    [SerializeField] private Animator animator;

    [SerializeField] private float liftingHaltDuration;
    [SerializeField] private float throwingHaltDuration;
    [SerializeField] private float droppingHaltDuration;

    private Dictionary<string, float> animationTimes = new Dictionary<string, float>();

    private void Start()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            animationTimes[clip.name] = clip.length;
        }
    }

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
                StartCoroutine(haltedTimerCoroutine(liftingHaltDuration));
            }
            else if(state == playerState.dragging)
            {
                objectManipulator.ReleaseObject();
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
                        StartCoroutine(haltedTimerCoroutine(throwingHaltDuration));
                    }
                    else if(objectInteracted.GetComponent<PushableObject>() != null)
                    {
                        state = playerState.dragging;
                        objectManipulator.GrabObject(objectInteracted);
                        StartCoroutine(releaseTimerCoroutine(liftingHaltDuration));
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
                StartCoroutine(haltedTimerCoroutine(droppingHaltDuration));
            }
        }
        else if (Input.GetKeyDown("space"))
        {
            playerMovement.Dash();
        }
        else if(Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
            StartCoroutine(haltedTimerCoroutine(animationTimes["Attack"]));
            playerCombat.Sweep();
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
            case playerState.attacking:
                return playerState.normal;
        }
        // Caso nao ache nenhum tipo de comportamento, talvez nao devesse trocar
        return state;
    }

    private IEnumerator haltedTimerCoroutine(float seconds)
    {
        playerState nextState = GetNextState();
        state = playerState.halted;
        yield return new WaitForSeconds(seconds);
        state = nextState;
    }
}
