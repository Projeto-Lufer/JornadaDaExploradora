using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRangedEnemyIdleState : SimpleAnimatableState
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
        while (true)
        {
            if (hits.Length == 0) // player not in range
            {
                hits = areaDetector.GetCollisionsInArea();
            }
            else if (areaDetector.GetHasLineOfSight(hits[0].transform))
            {
                ChangeToShooting();
            }
            yield return null;
        }
    }

    private void ChangeToShooting()
    {
        stateMachine.ChangeState(typeof(StaticRangedEnemyShootingState));
    }
}
