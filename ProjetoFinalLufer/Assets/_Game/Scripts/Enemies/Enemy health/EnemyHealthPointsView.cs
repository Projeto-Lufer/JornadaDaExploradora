using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPointsView : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitVFX;
    [SerializeField] private GameObject stunnedVFX;
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private DamageBlinkController damageBlinkController;

    public void PlayDamageVisuals()
    {
        hitVFX.Play();
        damageBlinkController.PlayBlinkingAnimation();
    }

    public void PlayDeathVisual()
    {
        Instantiate(deathVFX, transform.parent.position, transform.parent.rotation);
    }

    public void SetStunnedVFXEnabled(bool enabled)
    {
        stunnedVFX.SetActive(enabled);
    }
}