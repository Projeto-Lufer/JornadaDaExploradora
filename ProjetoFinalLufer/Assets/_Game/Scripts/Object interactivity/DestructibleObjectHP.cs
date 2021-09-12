using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObjectHP : HealthPoints
{
    [SerializeField] private ItemDropper dropper;

    public override void ReduceHealth(ComboElement attackStats)
    {
        LaserRedirector lr = base.GetComponent<LaserRedirector>();
        if(lr != null)
        {
            lr.Turn();
            return;
        }
        
        base.ReduceHealth(attackStats);

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
