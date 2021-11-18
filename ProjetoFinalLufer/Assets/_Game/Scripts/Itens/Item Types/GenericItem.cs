using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericItem : CollectableObject
{
    [SerializeField] ItemConfig itemConfig;
    public override void Collect(ObjectCollector collector)
    {
        collector.GetItem(itemConfig);
        base.Collect(collector);
    }
}