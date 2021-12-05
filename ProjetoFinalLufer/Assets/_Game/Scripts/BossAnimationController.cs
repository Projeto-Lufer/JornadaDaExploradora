using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationController : MonoBehaviour
{
    [SerializeField] private Animator bossAnimator;
    [SerializeField] private GameObject fadeOut;
    [SerializeField] private GameTransitionsManager transitionsManager;

    public void PlayEndGameSequence()
    {
        StartCoroutine(TimedEventsCoroutine());
    }

    private IEnumerator TimedEventsCoroutine()
    {
        bossAnimator.SetTrigger("Taunt");
        yield return new WaitForSeconds(1.5f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3f);
        transitionsManager.WinGame();
    }
}