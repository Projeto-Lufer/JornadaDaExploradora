using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float lungeRange;
    public float lungeWindup;
    public float sweepRange;
    public float sweepWindup;
    public LayerMask enemyLayer;

    public IEnumerator Sweep()
    {
        //Detecção de inimigos
        yield return new WaitForSeconds(sweepWindup);

        Collider[] enemies = Physics.OverlapSphere(attackPoint.position, sweepRange, enemyLayer);

        foreach(Collider enemy in enemies)
        {
            Debug.Log("Hit Sweep");
        }
        //Dano
    }

    public IEnumerator Lunge()
    {
        //Deteccao de inimigos
        yield return new WaitForSeconds(lungeWindup);

        Collider[] enemies = Physics.OverlapBox(attackPoint.position, new Vector3(0.5f,0.5f,lungeRange), Quaternion.identity, enemyLayer);
       
        foreach(Collider enemy in enemies)
        {
            Debug.Log("Hit Lunge");
        }
        //Dano 
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, sweepRange);
        Gizmos.DrawWireCube(attackPoint.position, new Vector3(0.5f,0.5f,lungeRange));
    }
}
