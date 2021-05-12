using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacks : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private AudioClip attackSFX;
    [SerializeField] private AudioManager audioManager;

    public float sweepRange;

    public int weaponDamage;

    public void Sweep()
    {
        Collider[] targets = Physics.OverlapSphere(attackPoint.position, sweepRange, targetLayer);
        bool shield = false;
        audioManager.PlaySFX(attackSFX, true, false);

        foreach(Collider target in targets)
        {
            if (target.tag == "Shield")
            {
                shield = true;
            }
        }

        if(shield == false)
        {
            foreach (Collider target in targets)
            {
                target.GetComponent<HealthPoints>().ReduceHealth(weaponDamage);
            }
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
