using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularKeyItem : CollectableObject
{
    //[SerializeField] private
    public override void Collect(ObjectCollector collector)
    {
        //collector.GetItem(Item.regularKey);
        base.Collect(collector);
    }
}