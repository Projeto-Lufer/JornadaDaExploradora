using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefendingState : ConcurrentState
{
    [Header("Controle de velocidade")]
    public float defendingSpeed;

    [Header("Variáveis do escudo")]
    [SerializeField] private GameObject shield;
    [SerializeField] private float radius;

    private bool isDefending;

    public override void Enter()
    {
        shield.transform.localScale = new Vector3(radius, 0.1f, radius);
        isDefending = true;
        stateMachine.inputManager.actionDefend.canceled += ctx => isDefending = false;
    }

    public override void Exit()
    {
        shield.GetComponent<ShieldReflection>().canEmmit = false;
        stateMachine.inputManager.actionDefend.canceled -= ctx => isDefending = false;
    }

    public override void PhysicsUpdate()
    {
        shield.SetActive(isDefending);

        if (!isDefending)
        {
            base.stateMachine.ChangeState(typeof(PlayerNotActingState));
        }
    }
}
