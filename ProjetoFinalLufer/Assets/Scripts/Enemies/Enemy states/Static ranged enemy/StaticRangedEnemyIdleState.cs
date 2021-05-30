using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRangedEnemyIdleState : SimpleState
{
    [Header("External references")]
    [SerializeField] private RangeDetector shootingAreaDetector;

    public override void Enter()
    {
        StartCoroutine(CheckIfInShootingRange());
    }

    public override void Exit()
    {
        StopAllCoroutines();
    }

    IEnumerator CheckIfInShootingRange()
    {
        Collider[] hits = shootingAreaDetector.GetCollisionsInArea();
        while (hits.Length == 0)
        {
            hits = shootingAreaDetector.GetCollisionsInArea();
            yield return null;
        }
        ChangeToShooting();
    }

    private void ChangeToShooting()
    {
        stateMachine.ChangeState(typeof(StaticRangedEnemyShootingState));
    }
}
