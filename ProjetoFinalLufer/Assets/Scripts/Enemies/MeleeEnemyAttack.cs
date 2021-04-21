using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;

    public float sweepRange;

    //Dano da arma equipada, caso a gente decida ter diferentes armas no jogo
    public int weaponDamage;

    public void Sweep()
    {
        //Detecção de inimigos
        Collider []player = Physics.OverlapSphere(attackPoint.position, sweepRange, playerLayer);

        //Dano
        if(player.Length > 0)
        {
            player[0].GetComponent<HealthPoints>().ReduceHealth(weaponDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, sweepRange);
    }
}
