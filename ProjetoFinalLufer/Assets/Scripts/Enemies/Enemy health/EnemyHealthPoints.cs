using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPoints : HealthPoints
{
    [SerializeField] private EnemyHealthPointsView HPView;
    [SerializeField] private StateMachine stateMachine;

    public override void ReduceHealth(int amount)
    {
        base.ReduceHealth(amount);

        base.curHP -= amount;

        HPView.PlayDamageVisuals();

        stateMachine.ChangeState(typeof(FlinchingState));

        if (base.curHP <= 0)
        {
            Die();
        }
    }

    public void Stun()
    {
        stateMachine.ChangeState(typeof(StunnedState));
    }

    private void Die()
    {
        Destroy(parentToDestroy);
    }
}
