using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueState : ConcurrentState
{
    public Queue<string> sentences = new Queue<string>();

    public Dialogue dialogue;

    public override void Enter()
    {
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentece();
    }

    public override void HandleInput()
    {
        if(base.stateMachine.inputManager.actionInteract.triggered)
        {
            DisplayNextSentece();
        }
    }

    public void DisplayNextSentece()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
    }

    public void EndDialogue()
    {
        base.stateMachine.ChangeState(typeof(PlayerNotActingState));
    }
}
