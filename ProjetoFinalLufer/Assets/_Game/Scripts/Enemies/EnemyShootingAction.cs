using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingAction : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawnPoint;

    public void Shoot()
    {
        Instantiate(projectile).GetComponent<EnemyProjectile>().SetStartingPosition(projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    }
}
