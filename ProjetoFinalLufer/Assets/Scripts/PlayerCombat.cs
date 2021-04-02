using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayer;

    //Variaveis relativas ao alcane e tempo de cast do ataque
    public float lungeRange;
    public float lungeWindup;
    public float sweepRange;
    public float sweepWindup;

    //Variaveis para acompanhar o HP do jogador
    public int maxHP;
    private int curHP;

    //Dano da arma equipada, caso a gente decida ter diferentes armas no jogo
    public int weaponDamage;

    private void Start()
    {
        curHP = maxHP;
    }

    public IEnumerator Sweep()
    {
        //Detecção de inimigos
        yield return new WaitForSeconds(sweepWindup);

        Collider[] enemies = Physics.OverlapSphere(attackPoint.position, sweepRange, enemyLayer);

        //Dano

        foreach (Collider enemy in enemies)
        {
            Debug.Log("Hit Sweep");
            enemy.GetComponentInParent<EnemyCombat>().TakeDamage(weaponDamage);
        }

    }

    public IEnumerator Lunge()
    {
        //Deteccao de inimigos
        yield return new WaitForSeconds(lungeWindup);

        Collider[] enemies = Physics.OverlapBox(attackPoint.position, new Vector3(0.5f,0.5f,lungeRange), Quaternion.identity, enemyLayer);
       
        //Dano 

        foreach(Collider enemy in enemies)
        {
            Debug.Log("Hit Lunge");
            enemy.GetComponentInParent<EnemyCombat>().TakeDamage(weaponDamage);
        }
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

    public void TakeDamage(int damage)
    {
        curHP -= damage;

        if(curHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
