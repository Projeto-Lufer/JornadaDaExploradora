using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRangedEnemyIdleState : SimpleState
{
    [Header("External references")]
    [SerializeField] private RangeDetector areaDetector;

    public override void Enter()
    {
        StartCoroutine(CheckIfInShootingRange());
    }

    public override void Exit()
    {
        StopAllCoroutines();
    }

    private IEnumerator CheckIfInShootingRange()
    {
        Collider[] hits = areaDetector.GetCollisionsInArea();
        while (hits.Length == 0)
        {
            hits = areaDetector.GetCollisionsInArea();
            yield return null;
        }
        ChangeToShooting();
    }

    private void ChangeToShooting()
    {
        stateMachine.ChangeState(typeof(StaticRangedEnemyShootingState));
    }
}
