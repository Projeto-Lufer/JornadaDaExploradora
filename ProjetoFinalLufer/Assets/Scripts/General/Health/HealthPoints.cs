using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class HealthPoints : MonoBehaviour
{    
    [SerializeField] protected GameObject parentToDestroy;
    [SerializeField] protected AudioClip hitSFX;
    [SerializeField] protected AudioManager audioManager;

    [SerializeField] protected int maxHP;
    protected int curHP;

    protected virtual void Start()
    {
        curHP = maxHP;
    }

    public virtual void ReduceHealth(int amount)
    {
        audioManager.PlaySFX(hitSFX, true);
    }
}
