using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargingState : ConcurrentState
{
    [Header("Variáveis de tempo")]
    [SerializeField] private float chargeTime;
    [SerializeField] private float currChargeTime;
    [Header("Contole do avanço")]
    [SerializeField] private float maxDistance;
    [SerializeField] private float time;
    [SerializeField] private CharacterController charController;
    [Header("Variáveis de ataque")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private Vector3 damageArea;
    [SerializeField] private ComboElement chargedStabStats;
    [SerializeField] private ComboElement unchargedStabStats;
    [SerializeField] private float chargeTimeNeededToStab;

    [SerializeField] private ParticleSystem chargingParticles;
    [SerializeField] private ParticleSystem chargedParticles;

    [SerializeField] private Animator animator;

    [HideInInspector] public bool canTurn = true;
    private bool keyDown;
    private float speed;

    public override void Enter()
    {
        speed = maxDistance / time;
        keyDown = true;
        stateMachine.inputManager.actionAttack2.canceled += ctx => keyDown = false;
    }

    public override void Exit()
    {
        stateMachine.inputManager.actionAttack2.canceled -= ctx => keyDown = false;
    }

    public override void PhysicsUpdate()
    {
        if(keyDown)
        {
            animator.SetBool("ChargingSpecial", true);
            if (currChargeTime < chargeTime && !chargingParticles.isPlaying)
            {
                chargingParticles.Play();
            }

            currChargeTime += Time.deltaTime;

            if (currChargeTime >= chargeTime && !chargedParticles.isPlaying)
            {
                chargingParticles.Stop();
                chargedParticles.Play();
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
        }
    }

    private IEnumerator Charge()
    {
        float currDistance = 0;
        Vector3 currPosition;
        canTurn = false;
        bool hitObstacle = false;

        while(currDistance < maxDistance)
        {
            animator.SetBool("UsingSpecial", true);
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
    }

    private IEnumerator UnchargedStab()
    {
        animator.SetBool("UsingSpecial", true);
        DoStabDamage(unchargedStabStats);
        yield return new WaitForSeconds(unchargedStabStats.duration);
        animator.SetBool("UsingSpecial", false);
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

        return hitObstacle;
    }
}
