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

    public override void Enter()
    {
        shield.transform.localScale = new Vector3(radius, 0.1f, radius);
    }

    public override void PhysicsUpdate()
    {
        if(Input.GetButton("Fire2"))
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
            base.stateMachine.ChangeState(typeof(PlayerNotActingState));
        }
    }
}
