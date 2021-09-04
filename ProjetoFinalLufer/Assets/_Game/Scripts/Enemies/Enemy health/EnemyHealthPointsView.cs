using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPointsView : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitVFX;

    public void PlayDamageVisuals()
    {
        hitVFX.Play();
        //TODO: Play animation
    }
}
