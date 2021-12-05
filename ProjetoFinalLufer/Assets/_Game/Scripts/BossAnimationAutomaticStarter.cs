using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationAutomaticStarter : MonoBehaviour
{
    [SerializeField] private Guardian boss;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            boss.Interact(other.gameObject);
        }
    }
}