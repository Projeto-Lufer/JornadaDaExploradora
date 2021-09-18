using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPoints : HealthPoints
{
    [SerializeField] private PlayerHealthPointsView playerHPView;
    [SerializeField] private GameTransitionsManager transitionsManager;
    [SerializeField] private ConcurrentStateMachine stateMachine;

    protected override void Start()
    {
        base.Start();
        playerHPView.UpdateHealthUI(base.curHP, base.maxHP);
    }

    public override void ReduceHealth(ComboElement attackStats)
    {
        base.ReduceHealth(attackStats);

        playerHPView.ReactToDamage(base.curHP, base.maxHP);

        stateMachine.ChangeOtherStateMachineState(typeof(PlayerIdleState));
        stateMachine.ChangeState(typeof(FlinchingState), attackStats.hitstunDuration);

        if (base.curHP <= 0)
        {
            Die();
        }
    }

    public void AddHealth(int amount)
    {
        base.curHP += amount;
        playerHPView.UpdateHealthUI(base.curHP, base.maxHP);
    }

    private void Die()
    {
        transitionsManager.EndGame();
        Destroy(base.parentToDestroy);
    }
}
