using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : Interactive
{
    [SerializeField] private Item containedItem;
    [SerializeField] private Dialogue emptyDialogue;

    private bool hasBeenOpened;

    public override void Interact(GameObject interactor)
    {
        if (!hasBeenOpened)
        {
            hasBeenOpened = true;
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
