using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : Interactive
{
    [SerializeField] private Item containedItem;

    private bool hasBeenOpened;

    public override void Interact(GameObject interactor)
    {
        if (!hasBeenOpened)
        {
            hasBeenOpened = true;
            ObjectCollector collector = interactor.GetComponent<ObjectCollector>();

            collector.GetItem(containedItem);
        }
    }
}
