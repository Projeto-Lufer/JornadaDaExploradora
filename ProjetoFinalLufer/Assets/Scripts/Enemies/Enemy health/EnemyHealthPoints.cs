using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPoints : HealthPoints
{
    [SerializeField] private EnemyHealthPointsView HPView;

    public override void ReduceHealth(int amount)
    {
        base.curHP -= amount;

        HPView.PlayDamageVisuals();

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
