using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPoints : HealthPoints
{
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
        Destroy(parentToDestroy);
    }
}
