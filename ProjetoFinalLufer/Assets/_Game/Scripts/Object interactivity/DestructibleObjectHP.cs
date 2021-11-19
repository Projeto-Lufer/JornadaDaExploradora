using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObjectHP : HealthPoints
{
    [SerializeField] private ItemDropper dropper;

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string sfxBreakingJar;


    public override void ReduceHealth(ComboElement attackStats)
    {        
        base.ReduceHealth(attackStats);

        if (base.curHP <= 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot(sfxBreakingJar, transform.position);
            Die();
        }
    }

    private void Die()
    {
        dropper.DropItem();

        Destroy(parentToDestroy);
    }
}
