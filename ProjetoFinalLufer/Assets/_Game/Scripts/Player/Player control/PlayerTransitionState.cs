using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerTransitionState : ConcurrentState
{
    private Vector2 direction = Vector2.zero;
    CinemachineBrain brain;
    private bool blendStarted;

    public override void Enter()
    {
        brain = CinemachineCore.Instance.GetActiveBrain(0);
        blendStarted=false;
    }
    public override void LogicUpdate()
    {
        if(blendStarted && !brain.IsBlending)
        {
            base.stateMachine.ChangeState(typeof(PlayerIdleState));
        }
        if(!blendStarted && brain.IsBlending)
        {
            blendStarted=true;
        }
    }
}
