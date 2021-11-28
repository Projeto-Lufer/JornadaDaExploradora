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
    [SerializeField] private float textSpeed = 10f;
    private bool isDisplaying = false;

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
        if(isDisplaying)
        {
            //ignore clicks while displaying
            return true;
        }
        if (sentences.Count == 0)
        {
            visuals.SetActive(false);
            return false;
        }

        isDisplaying = true;
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        return true;
    }

    private IEnumerator DisplaySentence(string sentence)
    {
        dialogueText.text = "";
        string currentText = "";
        string finalText = sentence;

        for (int i = 0; i < finalText.Length; i++)
        {
            currentText = finalText.Substring(0, i);
            currentText += "<color=#00000000>" + finalText.Substring(i) + "</color>";
            yield return new WaitForSeconds(1.0f/textSpeed);
            dialogueText.text = currentText;
        }
        // helps avoiding accidently skipping dialogue
        yield return new WaitForSeconds(0.5f);
        isDisplaying = false;
    }
}
