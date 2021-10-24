using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceDropper : ItemDropper
{
    [SerializeField][Range(0,1)] private float dropChance;

    public override void DropItem()
    {
        if(Random.Range(0f,1f)<=dropChance)
        {
            base.DropItem();
        }
    }
}
