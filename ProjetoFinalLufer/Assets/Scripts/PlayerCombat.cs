using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;

    //Variaveis relativas ao alcane e tempo dos ataques
    public float sweepRange;
    public float attackRate;
    [HideInInspector] public float nextAttack;

    //Dano da arma equipada, caso a gente decida ter diferentes armas no jogo
    public int weaponDamage;

    public void Sweep()
    {
        //Detecção de inimigos

        Collider[] enemies = Physics.OverlapSphere(attackPoint.position, sweepRange, enemyLayer);
        //Dano

        foreach (Collider enemy in enemies)
        {
            Debug.Log("Hit Sweep");
            enemy.GetComponentInParent<HPManager>().TakeDamage(weaponDamage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, sweepRange);
    }
}
