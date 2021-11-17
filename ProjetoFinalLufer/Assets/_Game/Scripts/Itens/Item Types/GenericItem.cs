using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericItem : CollectableObject
{
    [SerializeField] Item itemType;
    public override void Collect(ObjectCollector collector)
    {
        collector.GetItem(itemType);
        base.Collect(collector);
    }
}
