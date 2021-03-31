using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRangedEnemy : MonoBehaviour
{
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private float startledTime;

    private enum RangedEnemyStates {idle, shooting};
    private RangedEnemyStates state = RangedEnemyStates.idle;

    [SerializeField] private AreaDetector areaDetector;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private GameObject projectile;

    private GameObject target;
    private WaitForSeconds startledTimeWFS;
    private Coroutine shootingLoop;

    private void Start()
    {
        startledTimeWFS = new WaitForSeconds(startledTime);
        areaDetector.triggerEnterCallback += StartShooting;
        areaDetector.triggerExitCallback += StopShooting;
    }

    public void StartShooting(GameObject target)
    {
        if(target.tag == "Player")
        {
            this.target = target;

            shootingLoop = StartCoroutine(ShootingLoop());
        }
    }

    // Ignore o parametro
    public void StopShooting(GameObject target)
    {
        if(target.tag == "Player")
        {
            this.target = null;

            StopCoroutine(shootingLoop);
        }
    }

    private IEnumerator ShootingLoop()
    {
        // 1. Startled delay
        // 2. Aims at player
        // 3. Fires
        // 4. Repeat from 2
        Debug.Log("Saw you!");
        yield return startledTimeWFS;

        while (true)
        {
            for(float timer = 0 ; timer < timeBetweenShots ; timer += Time.deltaTime)
            {
                transform.LookAt(target.transform);
                yield return null;
            }

            Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        }
    }
}
