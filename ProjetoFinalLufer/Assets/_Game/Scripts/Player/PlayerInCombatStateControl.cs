using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInCombatStateControl : MonoBehaviour
{
    [SerializeField] float timeUntilPassive;
    [SerializeField] Animator animator;
    [SerializeField] GameObject backSpear;
    [SerializeField] GameObject wieldingSpear;

    private bool isInCombat;
    private float counter;
    private Coroutine timerToPassiveCoroutine = null;

    private void Start()
    {
        SetBackSpearActive();
        isInCombat = false;
    }

    public bool GetIsInCombat()
    {
        return isInCombat;
    }

    private void SetWieldingSpearActive()
    {
        backSpear.SetActive(false);
        wieldingSpear.SetActive(true);
    }

    private void SetBackSpearActive()
    {
        backSpear.SetActive(true);
        wieldingSpear.SetActive(false);
    }

    public void SetInCombat()
    {
        counter = 0;
        if(timerToPassiveCoroutine == null)
        {
            timerToPassiveCoroutine = StartCoroutine(TimerToPassive());
        }
    }

    private IEnumerator TimerToPassive()
    {
        isInCombat = true;
        animator.SetBool("Aggressive", isInCombat);
        SetWieldingSpearActive();

        while(counter < timeUntilPassive)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        isInCombat = false;
        animator.SetBool("Aggressive", isInCombat);
        SetBackSpearActive();
        timerToPassiveCoroutine = null;
    }
}
