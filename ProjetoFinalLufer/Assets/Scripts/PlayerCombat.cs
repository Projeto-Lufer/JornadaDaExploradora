using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;

    //Variaveis relativas ao alcane e tempo dos ataques
    public float lungeRange;
    public float sweepRange;
    public float attackRate;
    [HideInInspector] public float nextAttack;

    //Variaveis para acompanhar o HP do jogador
    public int maxHP;
    private int curHP;

    //Dano da arma equipada, caso a gente decida ter diferentes armas no jogo
    public int weaponDamage;

    private void Start()
    {
        curHP = maxHP;
    }

    public void Sweep()
    {
        //Detecção de inimigos

        Collider[] enemies = Physics.OverlapSphere(attackPoint.position, sweepRange, enemyLayer);

        //Dano

        foreach (Collider enemy in enemies)
        {
            Debug.Log("Hit Sweep");
            enemy.GetComponentInParent<EnemyCombat>().TakeDamage(weaponDamage);
        }

    }

    public void Lunge()
    {
        //Deteccao de inimigos

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
