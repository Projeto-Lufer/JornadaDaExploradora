using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;

    public float sweepRange;

    public int weaponDamage;

    public void Sweep()
    {
        Collider[] enemies = Physics.OverlapSphere(attackPoint.position, sweepRange, enemyLayer);

        foreach (Collider enemy in enemies)
        {
            enemy.GetComponent<HealthPoints>().ReduceHealth(weaponDamage);
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
