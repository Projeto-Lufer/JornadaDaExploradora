using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private GameObject visuals;
    [SerializeField] private GameObject basicBackground;
    [SerializeField] private GameObject backgroundWithName;
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private TMP_Text dialogueText;

    private Queue<string> sentences = new Queue<string>();

    public void ShowDialogue(Dialogue dialogue)
    {
        visuals.SetActive(true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        if (dialogue.name != "")
        {
            backgroundWithName.SetActive(true);
            basicBackground.SetActive(false);
            characterName.text = dialogue.name;
        }
        else
        {
            backgroundWithName.SetActive(false);
            basicBackground.SetActive(true);
        }
        TryDisplayNextSentece();
    }

    public bool TryDisplayNextSentece()
    {
        if (sentences.Count == 0)
        {
            visuals.SetActive(false);
            return false;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        return true;
    }
}
