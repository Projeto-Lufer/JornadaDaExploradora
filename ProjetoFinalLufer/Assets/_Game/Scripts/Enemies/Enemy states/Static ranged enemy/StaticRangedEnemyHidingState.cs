using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRangedEnemyHidingState : SimpleAnimatableState
{
    [SerializeField] private RangeDetector hidingAreaDetector;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private Collider bodyCollider;

    private Vector3 originalPosition;
    private Vector3 hidingPosition;

    [FMODUnity.EventRef]
    public string sfxRangedEnemyDigDown;

    private void Start()
    {
        originalPosition = enemyTransform.position;
        hidingPosition = new Vector3(enemyTransform.position.x, enemyTransform.position.y * 0.2f, enemyTransform.position.z);
    }

    public override void Enter()
    {
        Collider[] hits = hidingAreaDetector.GetCollisionsInArea();
        if (hits.Length > 0)
        {
            GameObject target = hits[0].gameObject;
            Hide();
            StartCoroutine(CheckIfStillInHidingRange());
        }
        else
        {
            ChangeToShooting();
        }
    }

    public override void Exit()
    {
        base.PlayAnimationTrigger("Dig up");
        Show();
    }

    private void Hide()
    {
        base.PlayAnimationTrigger("Dig down");
        bodyCollider.enabled = false;
        FMODUnity.RuntimeManager.PlayOneShot(sfxRangedEnemyDigDown, transform.position);
    }

    private void Show()
    {
        bodyCollider.enabled = true;
    }

    IEnumerator CheckIfStillInHidingRange()
    {
        yield return null;
        Collider[] hits = hidingAreaDetector.GetCollisionsInArea();
        while (hits.Length > 0)
        {
            hits = hidingAreaDetector.GetCollisionsInArea();
            yield return null;
        }
        ChangeToShooting();
    }

    private void ChangeToShooting()
    {
        stateMachine.ChangeState(typeof(StaticRangedEnemyShootingState));
    }
}
