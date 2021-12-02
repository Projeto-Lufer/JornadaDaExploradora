using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargingState : ConcurrentState
{
    [Header("Variaveis de tempo")]
    [SerializeField] private float chargeTime;
    [SerializeField] private float currChargeTime;
    [Header("Contole do avanco")]
    [SerializeField] private float maxDistance;
    [SerializeField] private float time;
    [SerializeField] private CharacterController charController;
    [Header("Variaveis de ataque")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private Vector3 damageArea;
    [SerializeField] private ComboElement chargedStabStats;
    [SerializeField] private ComboElement unchargedStabStats;
    [SerializeField] private float chargeTimeNeededToStab;

    [SerializeField] private ParticleSystem chargingParticles;
    [SerializeField] private ParticleSystem chargedParticles;

    [SerializeField] private Animator animator;
    [SerializeField] private PlayerInCombatStateControl playerInCombatControl;

    [HideInInspector] public bool canTurn = true;
    private bool keyDown;
    private float speed;
    [Header("Audio FMOD Event")]
    FMOD.Studio.EventInstance sfxAylaSpecialAttack;

    public override void Enter()
    {
        speed = maxDistance / time;
        keyDown = true;
        stateMachine.inputManager.actionAttack2.canceled += ctx => keyDown = false;
        sfxAylaSpecialAttack = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Ayla/sfx-ayla-special-attack");
        sfxAylaSpecialAttack.start();
    }

    public override void Exit()
    {
        stateMachine.inputManager.actionAttack2.canceled -= ctx => keyDown = false;
    }

    public override void PhysicsUpdate()
    {
        if(keyDown)
        {
            playerInCombatControl.SetInCombat();
            animator.SetBool("ChargingSpecial", true);
            if (currChargeTime < chargeTime && !chargingParticles.isPlaying)
            {
                chargingParticles.Play();
                Debug.Log("Audio charge yellowww");
                sfxAylaSpecialAttack.setParameterByName("AylaSpecialAttack", 0f);
            }

            currChargeTime += Time.deltaTime;

            if (currChargeTime >= chargeTime && !chargedParticles.isPlaying)
            {
                chargingParticles.Stop();
                chargedParticles.Play();
                Debug.Log("Audio charge reedddd");
            }
        }
        else
        {
            animator.SetBool("ChargingSpecial", false);
            if (currChargeTime >= chargeTime)
            {
                StartCoroutine(Charge());
            }
            else if(currChargeTime >= chargeTimeNeededToStab)
            {
                StartCoroutine(UnchargedStab());
            }

            chargedParticles.Stop();
            chargingParticles.Stop();
            currChargeTime = 0;
            base.stateMachine.ChangeState(typeof(PlayerNotActingState));

            //sfxAylaSpecialAttack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    private IEnumerator Charge()
    {
        float currDistance = 0;
        Vector3 currPosition;
        canTurn = false;
        bool hitObstacle = false;

        sfxAylaSpecialAttack.setParameterByName("AylaSpecialAttack", 1f);
        Debug.Log("Audio charge attackinggg");
        animator.SetBool("UsingSpecial", true);

        while (currDistance < maxDistance)
        {
            playerInCombatControl.SetInCombat();
            currPosition = transform.position;
            charController.Move(transform.forward * speed * Time.deltaTime);
            currDistance += Vector3.Distance(currPosition, transform.position);

            hitObstacle = DoStabDamage(chargedStabStats);

            if (hitObstacle)
            {
                break;
            }
            else
            {
                yield return null;
            }
        }
        animator.SetBool("UsingSpecial", false);
        canTurn = true;

        //sfxAylaSpecialAttack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    private IEnumerator UnchargedStab()
    {
        Debug.Log("Audio charge cancellll");
        sfxAylaSpecialAttack.setParameterByName("AylaSpecialAttack", 2f);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("AylaSpecialAttack", 2f);

        playerInCombatControl.SetInCombat();
        animator.SetBool("UsingSpecial", true);
        DoStabDamage(unchargedStabStats);
        yield return new WaitForSeconds(unchargedStabStats.duration);
        animator.SetBool("UsingSpecial", false);

        //sfxAylaSpecialAttack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        
    }

    private bool DoStabDamage(ComboElement stabStats)
    {
        bool hitObstacle = false;

        Collider[] targets = Physics.OverlapBox(attackPoint.position, damageArea, transform.rotation, targetLayer);

        foreach (Collider target in targets)
        {
            if (target.tag == "Obstacle")
            {
                hitObstacle = true;
            }
            HealthPoints currHP = target.GetComponent<HealthPoints>();
            if (currHP != null)
            {
                currHP.ReduceHealth(stabStats);
            }
        }

        //sfxAylaSpecialAttack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        return hitObstacle;
    }
}
