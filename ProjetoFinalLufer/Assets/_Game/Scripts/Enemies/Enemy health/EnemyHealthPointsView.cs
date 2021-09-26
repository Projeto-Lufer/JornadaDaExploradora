using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPointsView : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitVFX;
    [SerializeField] private GameObject stunnedVFX;

    public void PlayDamageVisuals()
    {
        hitVFX.Play();
        //TODO: Play animation
    }

    public void SetStunnedVFXEnabled(bool enabled)
    {
        stunnedVFX.SetActive(enabled);
    }
}
