using UnityEngine;
using System.Collections;

public class StaticRangedEnemyShootingState : SimpleAnimatableState
{
    [Header("External references")]
    [SerializeField] private RangeDetector shootingAreaDetector;
    [SerializeField] private RangeDetector hidingAreaDetector;
    [SerializeField] private Transform parentToRotate;
    //private ObjectPool projectilePool;

    [Header("Gameplay tweeking fields")]
    [Tooltip("Tempo que o inimigo fica parado quando avista jogador pela primeira vez")]
    [SerializeField] private float startledTime;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawnPoint;

    // Internal attributes
    private WaitForSeconds startledTimeWFS;

    protected override void Awake()
    {
        base.Awake();
        
        startledTimeWFS = new WaitForSeconds(startledTime);
    }

    public override void Enter()
    {
        Collider[] hits = shootingAreaDetector.GetCollisionsInArea();
        if (hits.Length > 0)
        {
            GameObject target = hits[0].gameObject;
            StartCoroutine(ShootingLoop(target.transform));
            StartCoroutine(CheckIfStillInShootingRange());
            StartCoroutine(CheckIfInHidingRange());
        }
        else
        {
            ChangeToIdle();
        }
    }

    public override void Exit()
    {
        StopAllCoroutines();
    }

    private IEnumerator ShootingLoop(Transform target)
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
            GameObject projectileInstance = Instantiate(projectile);
            projectileInstance.GetComponent<EnemyProjectile>().SetStartingPosition(projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        }
    }

    IEnumerator CheckIfStillInShootingRange()
    {
        yield return null;
        Collider[] hits = shootingAreaDetector.GetCollisionsInArea();
        while (hits.Length > 0)
        {
            hits = shootingAreaDetector.GetCollisionsInArea();
            yield return null;
        }
        ChangeToIdle();
    }

    private IEnumerator CheckIfInHidingRange()
    {
        Collider[] hits = hidingAreaDetector.GetCollisionsInArea();
        while (true)
        {
            foreach (Collider hit in hits)
            {
                if (hit.tag == "Player")
                {
                    ChangeToHiding();
                }
            }
            hits = hidingAreaDetector.GetCollisionsInArea();
            yield return null;
        }
    }

    private void ChangeToIdle()
    {
        stateMachine.ChangeState(typeof(StaticRangedEnemyIdleState));
    }

    private void ChangeToHiding()
    {
        stateMachine.ChangeState(typeof(StaticRangedEnemyHidingState));
    }
}
