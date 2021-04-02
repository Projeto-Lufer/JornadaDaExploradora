using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int maxHP;
    private int curHP;

    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;

        if (curHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
