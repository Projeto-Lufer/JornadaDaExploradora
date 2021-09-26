using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;


public class PlayerHealthPointsView : MonoBehaviour
{
    [SerializeField] private Text healthTextUI;
    [SerializeField] private ParticleSystem hitParticles;
    [SerializeField] private List<Image> allHearts;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Sprite halfHeart;
    [SerializeField] private Sprite fullHeart;
    private string baseText;

    void Start()
    {
        baseText = healthTextUI.text;
    }

    public void ReactToDamage(int curHP, int maxHP)
    {
        UpdateHealthUI(curHP, maxHP);
        PlayDamageVisuals();
    }

    public void UpdateHealthUI(int curHP, int maxHP)
    {
        Assert.IsTrue(maxHP%2 == 0, "max HP n é par");
        var filled=curHP;
        var empty=maxHP-curHP;
        var currentHeart = 0;
        while(filled >= 2)
        {
            allHearts[currentHeart].sprite=fullHeart;
            currentHeart += 1;
            filled -=2;
        }
        if(filled == 1)
        {
            allHearts[currentHeart].sprite=halfHeart;
            currentHeart += 1;
            empty -= 1;
        }
        while(empty > 0)
        {
            allHearts[currentHeart].sprite=emptyHeart;
            currentHeart += 1;
            empty -= 2;
        }
    }

    private void PlayDamageVisuals()
    {
        hitParticles.Play();

        //TODO:
        // 1. Tocar animacao
        // 2. Receber callback para destruir objeto quando visuais terminarem
    }
}
