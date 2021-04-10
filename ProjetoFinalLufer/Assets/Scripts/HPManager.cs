using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPManager : MonoBehaviour
{

    [SerializeField] private Text healthTextUI;

    //Variaveis para acompanhar o HP da criatura
    private string baseText; 
    public int maxHP;
    private int curHP;

    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        if(healthTextUI != null)
        {
            baseText = healthTextUI.text;
            UpdateHealthUI();
        }
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;

        if(healthTextUI != null)
        {
            UpdateHealthUI();
        }

        if (curHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void UpdateHealthUI()
    {
        healthTextUI.text = $"{baseText} {curHP}/{maxHP}";
    }
}
