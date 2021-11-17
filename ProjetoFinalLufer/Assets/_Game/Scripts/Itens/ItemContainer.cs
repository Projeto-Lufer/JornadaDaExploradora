using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : Interactive
{
    [SerializeField] private ItemConfig containedItem;
    [SerializeField] private Dialogue emptyDialogue;
    [SerializeField] private bool isLocked = true;

    [SerializeField] private Animator animator;
    [FMODUnity.EventRef]
    public string sfxDoorLocked;
    [FMODUnity.EventRef]
    public string sfxDoorUnlocked;
    [FMODUnity.EventRef]
    public string sfxChestOpening;

    private bool hasBeenOpened;

    public void SetIsLocked(bool isLocked)
    {
        this.isLocked = isLocked;

        if (isLocked)
        {
            FMODUnity.RuntimeManager.PlayOneShot(sfxDoorLocked, transform.position);
        }
        else
        {
            FMODUnity.RuntimeManager.PlayOneShot(sfxDoorUnlocked, transform.position);
        }
    }

    public override void Interact(GameObject interactor)
    {
        if (isLocked)
        {
            if(interactor.tag == "Player")
            {
                FMODUnity.RuntimeManager.PlayOneShot(sfxDoorLocked, transform.position);
                /* (Bernardo) TODO: Adicionar dialogo de "trancado"
                *
                * interactor.GetComponentInChildren<PlayerDialogueState>().dialogue = lockedDialogue;
                interactor.transform.GetChild(2).GetComponent<ConcurrentStateMachine>().ChangeState(typeof(PlayerDialogueState));*/
            }
        }
        else
        {
            if (!hasBeenOpened)
            {
                FMODUnity.RuntimeManager.PlayOneShot(sfxChestOpening, transform.position);
                hasBeenOpened = true;
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
}