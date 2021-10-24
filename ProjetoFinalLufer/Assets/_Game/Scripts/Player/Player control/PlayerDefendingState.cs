using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefendingState : ConcurrentState
{
    [Header("Controle de velocidade")]
    public float defendingSpeed;

    [Header("Variaveis do escudo")]
    [SerializeField] private GameObject shield;
    [SerializeField] private ToggleableActivator laserReflectionActivator;

    [SerializeField] private float radius;

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string sfxAylaEnableShield;

    private bool isDefending;

    public override void Enter()
    {
        shield.transform.localScale = new Vector3(radius, radius, 1f);
        isDefending = true;
        stateMachine.inputManager.actionDefend.canceled += ctx => isDefending = false;
        FMODUnity.RuntimeManager.PlayOneShot(sfxAylaEnableShield, transform.position);
    }

    public override void Exit()
    {
        if(laserReflectionActivator.GetIsActive())
        {
            laserReflectionActivator.Interact();
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
