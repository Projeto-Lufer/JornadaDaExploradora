using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefendingState : ConcurrentState
{
    [Header("Controle de velocidade")]
    public float defendingSpeed;

    [Header("Variaveis do escudo")]
    [SerializeField] private GameObject shield;
    [SerializeField] private float radius;

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string sfxAylaEnableShield;

    private bool isDefending;

    public override void Enter()
    {
        shield.transform.localScale = new Vector3(radius, 1f, radius);
        isDefending = true;
        stateMachine.inputManager.actionDefend.canceled += ctx => isDefending = false;
        FMODUnity.RuntimeManager.PlayOneShot(sfxAylaEnableShield, transform.position);
    }

    public override void Exit()
    {
        if(shield.GetComponent<ShieldReflection>().canEmmit)
        {
            shield.GetComponent<ShieldReflection>().Interact();
        }
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
