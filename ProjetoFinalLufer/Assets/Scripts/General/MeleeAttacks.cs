using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacks : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask targetLayer;

    public float sweepRange;

    public int weaponDamage;

    public void Sweep()
    {
        Collider[] targets = Physics.OverlapSphere(attackPoint.position, sweepRange, targetLayer);

        foreach (Collider target in targets)
        {
            target.GetComponent<HealthPoints>().ReduceHealth(weaponDamage);
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
