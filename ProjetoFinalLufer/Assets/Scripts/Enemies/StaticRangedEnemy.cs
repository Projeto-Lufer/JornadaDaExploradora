using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRangedEnemy : MonoBehaviour
{
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private float startledTime;

    [SerializeField] private AreaDetector areaDetector;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private GameObject projectile;

    private Transform target;
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
            this.target = target.transform;

            shootingLoop = StartCoroutine(ShootingLoop());
        }
    }

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
        yield return startledTimeWFS;

        while (true)
        {
            for(float timer = 0 ; timer < timeBetweenShots ; timer += Time.deltaTime)
            {
                if(target != null)
                {
                    transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
                }
                yield return null;
            }

            Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        }
    }
}
