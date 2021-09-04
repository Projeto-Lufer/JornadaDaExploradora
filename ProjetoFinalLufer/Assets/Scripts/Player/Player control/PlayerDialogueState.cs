using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDialogueState : ConcurrentState
{
    public Queue<string> sentences = new Queue<string>();
    public TMP_Text dialogueText;
    public Dialogue dialogue;

    public GameObject dialogueBox;

    public override void Enter()
    {
        dialogueBox.SetActive(true);

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
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        base.stateMachine.ChangeState(typeof(PlayerNotActingState));
    }
}
