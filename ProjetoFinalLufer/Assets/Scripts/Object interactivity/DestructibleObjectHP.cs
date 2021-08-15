using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObjectHP : HealthPoints
{
    [SerializeField] private ItemDropper dropper;

    public override void ReduceHealth(int amount)
    {
        base.curHP -= amount;

        if (base.curHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        dropper.DropItem();

        Destroy(parentToDestroy);
    }
}
