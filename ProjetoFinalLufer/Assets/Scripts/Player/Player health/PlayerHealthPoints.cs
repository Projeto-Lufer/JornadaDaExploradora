using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPoints : HealthPoints
{
    [SerializeField] private PlayerHealthPointsView playerHPView;
    [SerializeField] private GameTransitionsManager transitionsManager;

    protected override void Start()
    {
        base.Start();
        playerHPView.UpdateHealthUI(base.curHP, base.maxHP);
    }

    public override void ReduceHealth(int amount)
    {
        base.ReduceHealth(amount);
        base.curHP -= amount;

        playerHPView.ReactToDamage(base.curHP, base.maxHP);

        if (base.curHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        transitionsManager.EndGame();
        Destroy(base.parentToDestroy);
    }
}
