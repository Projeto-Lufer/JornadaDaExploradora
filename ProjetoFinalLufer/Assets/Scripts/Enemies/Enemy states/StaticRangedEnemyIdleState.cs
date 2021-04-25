using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRangedEnemyIdleState : SimpleState
{
    [Header("External references")]
    [SerializeField] private AreaDetector areaDetector;

    public override void Enter()
    {
        areaDetector.triggerEnterCallback = StartShooting;
    }

    private void StartShooting(GameObject target)
    {
        stateMachine.ChangeState(typeof(StaticRangedEnemyShootingState), target);
    }

    public override void Exit()
    {
        areaDetector.triggerEnterCallback -= StartShooting;
    }
}
