using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : Interactive
{
    [SerializeField] private Dialogue initialDialogue;
    [SerializeField] private Dialogue alreadyInteractedDialogue;

    private bool alreadyInteracted = false;

    public bool isShield;

    public override void Interact(GameObject player)
    {
        PlayerDialogueState dialogueState = player.GetComponentInChildren<PlayerDialogueState>();

        if (alreadyInteracted)
        {
            dialogueState.dialogue = alreadyInteractedDialogue;
        }
        else
        {
            dialogueState.dialogue = initialDialogue;
            alreadyInteracted = true;
        }

        dialogueState.GetComponent<ConcurrentStateMachine>().ChangeState(typeof(PlayerDialogueState));
    }
}