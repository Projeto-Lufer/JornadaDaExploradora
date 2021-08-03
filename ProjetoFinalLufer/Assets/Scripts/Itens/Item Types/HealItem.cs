using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Item
{
    [SerializeField] private int healAmount;

    public override void Use(GameObject healthObject)
    {
        healthObject.GetComponent<PlayerHealthPoints>().AddHealth(healAmount);
    }
}
