using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private GameObject visuals;
    [SerializeField] private GameObject basicBackground;
    [SerializeField] private GameObject backgroundWithName;
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private float textSpeed = 10f;
    [SerializeField] private GameObject animatedArrow;
    [SerializeField] private PlayerInputManager inputManager;
    [SerializeField] private BossAnimationController bossAnimation;

    private bool isDisplaying = false;
    private bool skippedDialog = false;
    private Coroutine checkSkipCoroutine;
    private string speakerName;

    private Queue<string> sentences = new Queue<string>();

    public Action onDialogFinished;

    public void ShowDialogue(Dialogue dialogue)
    {
        visuals.SetActive(true);
        speakerName = dialogue.name;

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
            if (speakerName == "Corruption")
            {
                bossAnimation.PlayEndGameSequence();
            }
            return false;
        }

        isDisplaying = true;
        string sentence = sentences.Dequeue();
        StartCoroutine(DisplaySentence(sentence));

        return true;
    }

    private IEnumerator CheckForSkip()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            if (inputManager.input.actions["Interact"].triggered)
            {
                skippedDialog = true;
                yield break;
            }

            yield return null;
        }
    }

    private IEnumerator DisplaySentence(string sentence)
    {
        checkSkipCoroutine = StartCoroutine(CheckForSkip());
        animatedArrow.SetActive(false);
        dialogueText.text = "";
        string currentText = "";
        string finalText = sentence;

        for (int i = 0; i < finalText.Length; i++)
        {
            if (skippedDialog)
            {
                skippedDialog = false;
                dialogueText.text = finalText;
                break;
            }
            currentText = finalText.Substring(0, i);
            currentText += "<color=#00000000>" + finalText.Substring(i) + "</color>";
            yield return new WaitForSeconds(1.0f/textSpeed);
            dialogueText.text = currentText;
        }
        // helps avoiding accidently skipping dialogue
        yield return new WaitForSeconds(0.5f);
        isDisplaying = false;
        animatedArrow.SetActive(true);
        StopCoroutine(checkSkipCoroutine);
        checkSkipCoroutine = null;
    }
}