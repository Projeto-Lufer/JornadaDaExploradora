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

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string sfxRangedEnemyDigUp;
    [FMODUnity.EventRef]
    public string sfxRangedEnemyDigDown;
    [FMODUnity.EventRef]
    public string sfxRangedEnemyGrowl;

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

        base.PlayAnimationTrigger("Dig up");
        FMODUnity.RuntimeManager.PlayOneShot(sfxRangedEnemyDigUp, transform.position);
        FMODUnity.RuntimeManager.PlayOneShot(sfxRangedEnemyGrowl, transform.position);
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
            Instantiate(projectile).GetComponent<EnemyProjectile>().SetStartingPosition(projectileSpawnPoint.position, projectileSpawnPoint.rotation);
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
        base.PlayAnimationTrigger("Dig down");
        stateMachine.ChangeState(typeof(StaticRangedEnemyIdleState));
        FMODUnity.RuntimeManager.PlayOneShot(sfxRangedEnemyDigDown, transform.position);
    }

    private void ChangeToHiding()
    {
        stateMachine.ChangeState(typeof(StaticRangedEnemyHidingState));
    }
}
