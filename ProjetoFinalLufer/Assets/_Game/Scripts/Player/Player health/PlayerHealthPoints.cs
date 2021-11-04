using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPoints : HealthPoints
{
    [SerializeField] private PlayerHealthPointsView playerHPView;
    [SerializeField] private GameTransitionsManager transitionsManager;
    [SerializeField] private ConcurrentStateMachine stateMachine;

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string sfxReceiveDamage;
    [FMODUnity.EventRef]
    public string sfxAddHealth;
    [FMODUnity.EventRef]
    public string sfxDie;

    [FMODUnity.EventRef]
    public string voiceAylaHurt;


    protected override void Start()
    {
        base.Start();
        playerHPView.UpdateHealthUI(base.curHP, base.maxHP);
    }

    public override void ReduceHealth(ComboElement attackStats)
    {
        FMODUnity.RuntimeManager.PlayOneShot(sfxReceiveDamage, transform.position);
        FMODUnity.RuntimeManager.PlayOneShot(voiceAylaHurt, transform.position);
        base.ReduceHealth(attackStats);

        playerHPView.ReactToDamage(base.curHP, base.maxHP);

        stateMachine.ChangeOtherStateMachineState(typeof(PlayerIdleState));
        stateMachine.ChangeState(typeof(FlinchingState), attackStats.hitstunDuration);

        if (base.curHP <= 0)
        {
            Die();
        }
    }

    public void AddHealth(int amount)
    {
        amount = Mathf.Min(amount, base.maxHP - base.curHP);
        base.curHP += amount;
        playerHPView.UpdateHealthUI(base.curHP, base.maxHP);
        FMODUnity.RuntimeManager.PlayOneShot(sfxAddHealth, transform.position);
    }

    private void Die()
    {
        FMODUnity.RuntimeManager.PlayOneShot(sfxDie, transform.position);
        transitionsManager.EndGame();
        Destroy(base.parentToDestroy);
    }
}
