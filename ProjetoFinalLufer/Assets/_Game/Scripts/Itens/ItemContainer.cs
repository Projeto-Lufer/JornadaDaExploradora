using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : Interactive
{
    [SerializeField] private Item containedItem;
    [SerializeField] private Dialogue emptyDialogue;

    [SerializeField] private Animator animator;

    private bool hasBeenOpened;

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string sfxChestOpening;


    public override void Interact(GameObject interactor)
    {
        if (!hasBeenOpened)
        {
            hasBeenOpened = true;
            FMODUnity.RuntimeManager.PlayOneShot(sfxChestOpening, transform.position);
            animator.SetTrigger("Open");
            ObjectCollector collector = interactor.GetComponent<ObjectCollector>();

            collector.GetItem(containedItem);
        }
        else
        {
            interactor.GetComponentInChildren<PlayerDialogueState>().dialogue = emptyDialogue;
            interactor.transform.GetChild(2).GetComponent<ConcurrentStateMachine>().ChangeState(typeof(PlayerDialogueState));
        }
    }
}
