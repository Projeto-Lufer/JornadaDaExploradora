using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : Interactive
{
    [SerializeField] private Dialogue initialDialogue;
    [SerializeField] private Dialogue alreadyInteractedDialogue;

    private bool alreadyInteracted = false;
    public override void Interact(GameObject player)
    {
        if(alreadyInteracted)
        {
            player.GetComponentInChildren<PlayerDialogueState>().dialogue = alreadyInteractedDialogue;
            player.transform.GetChild(2).GetComponent<ConcurrentStateMachine>().ChangeState(typeof(PlayerDialogueState));
        }
        else
        {
            player.GetComponentInChildren<PlayerDialogueState>().dialogue = initialDialogue;
            player.transform.GetChild(2).GetComponent<ConcurrentStateMachine>().ChangeState(typeof(PlayerDialogueState));
            alreadyInteracted = true;
        }
    }
}
