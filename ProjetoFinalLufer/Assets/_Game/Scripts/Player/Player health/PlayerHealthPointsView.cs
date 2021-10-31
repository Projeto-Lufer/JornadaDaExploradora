using System.Collections;
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
    [SerializeField] private Animator animator;
    [SerializeField] private DamageBlinkController damageBlinkController;

    private string baseText;
    int damageAnimHash;

    void Start()
    {
        baseText = healthTextUI.text;
        damageAnimHash = Animator.StringToHash("Damage");
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
        animator.CrossFade(damageAnimHash, 0f);

        damageBlinkController.PlayBlinkingAnimation();
    }
}