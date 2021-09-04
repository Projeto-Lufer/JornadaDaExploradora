using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateableByPulse : Activateable
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject objectToSpawn;

    public override void Activate()
    {
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
