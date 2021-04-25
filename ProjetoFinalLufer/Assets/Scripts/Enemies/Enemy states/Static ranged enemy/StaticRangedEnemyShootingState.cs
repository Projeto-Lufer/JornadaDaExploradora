using UnityEngine;
using System.Collections;

public class StaticRangedEnemyShootingState : SimpleState
{
    [Header("External references")]
    [SerializeField] private AreaDetector areaDetector;
    [SerializeField] private Transform parentToRotate;
    [SerializeField] private ObjectPool projectilePool;

    [Header("Gameplay tweeking fields")]
    [Tooltip("Tempo que o inimigo fica parado quando avista jogador pela primeira vez")]
    [SerializeField] private float startledTime;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawnPoint;

    // Internal attributes
    private Transform target;
    private WaitForSeconds startledTimeWFS;

    private void Start()
    {
        startledTimeWFS = new WaitForSeconds(startledTime);
    }

    public override void Enter(GameObject target)
    {
        this.target = target.transform;
        areaDetector.triggerExitCallback = StopShooting;
        StartCoroutine(ShootingLoop());
    }

    public override void Exit()
    {
        areaDetector.triggerExitCallback -= StopShooting;
    }

    public void StopShooting(GameObject _)
    {
        this.target = null;

        StopAllCoroutines();
        stateMachine.ChangeState(typeof(StaticRangedEnemyIdleState));
    }

    private IEnumerator ShootingLoop()
    {
        parentToRotate.LookAt(new Vector3(target.position.x, parentToRotate.position.y, target.position.z));
        // TODO: Play startled animation
        yield return startledTimeWFS;

        while (true)
        {
            for (float timer = 0; timer < timeBetweenShots; timer += Time.deltaTime)
            {
                if (target != null)
                {
                    parentToRotate.LookAt(new Vector3(target.position.x, parentToRotate.position.y, target.position.z));
                }
                yield return null;
            }
            GameObject projectile = projectilePool.GetPooledObject();
            projectile.GetComponent<EnemyProjectile>().SetStartingPosition(projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        }
    }
}
