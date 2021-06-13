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
    public int weaponDamage;
    private bool keyDown;
    private float speed;
    [HideInInspector] public bool canTurn = true;
    [SerializeField] private ParticleSystem chargingParticles;
    [SerializeField] private ParticleSystem chargedParticles;

    public override void Enter()
    {
        speed = maxDistance / time;
        HandleInput();
    }

    public override void HandleInput()
    {
        keyDown = Input.GetMouseButton(1);
    }

    public override void PhysicsUpdate()
    {
        if(keyDown)
        {
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
            if(currChargeTime >= chargeTime)
            {
                StartCoroutine(Charge());
            }
            else
            {
                Collider[] targets = Physics.OverlapBox(attackPoint.position, damageArea, transform.rotation, targetLayer);

                foreach (Collider target in targets)
                {
                    target.GetComponent<HealthPoints>().ReduceHealth(weaponDamage);
                }
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
            currPosition = transform.position;
            charController.Move(transform.forward * speed * Time.deltaTime);
            currDistance += Vector3.Distance(currPosition, transform.position);

            Collider[] targets = Physics.OverlapBox(attackPoint.position, damageArea, transform.rotation, targetLayer);

            foreach (Collider target in targets)
            {
                if(target.tag == "Obstacle")
                {
                    hitObstacle = true;
                }
                HealthPoints currHP = target.GetComponent<HealthPoints>();
                if(currHP != null)
                {
                    currHP.ReduceHealth(weaponDamage);
                }
            }

            if (hitObstacle)
            {
                break;
            }
            else
            {
                yield return null;
            }
        }

        canTurn = true;
    }
}
