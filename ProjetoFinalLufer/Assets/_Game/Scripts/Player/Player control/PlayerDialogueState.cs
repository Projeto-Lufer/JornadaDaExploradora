using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueState : ConcurrentState
{
    public Dialogue dialogue;

    public DialogueBox dialogueBox;

    public override void Enter()
    {
        dialogueBox.ShowDialogue(dialogue);
    }

    public override void HandleInput()
    {
        if(base.stateMachine.inputManager.actionInteract.triggered)
        {
            if(!dialogueBox.TryDisplayNextSentece())
            {
                EndDialogue();
            }
        }
    }

    public void EndDialogue()
    {
        base.stateMachine.ChangeState(typeof(PlayerNotActingState));
    }
}
