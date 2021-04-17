using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobileMeleeEnemy : MonoBehaviour
{
    [SerializeField] private AreaDetector chaseAreaDetector;
    [SerializeField] private NavMeshAgent agent;

    private Coroutine chaseCoroutine;

    private void Awake()
    {
        chaseAreaDetector.triggerEnterCallback = StartChasing;
        chaseAreaDetector.triggerExitCallback = StopChasing;
    }

    public void StartChasing(GameObject target)
    {
        chaseCoroutine = StartCoroutine(Chase(target.transform));
    }

    public void StopChasing(GameObject _)
    {
        StopCoroutine(chaseCoroutine);
        chaseCoroutine = null;
    }

    IEnumerator Chase(Transform target)
    {
        while (true)
        {
            agent.destination = target.position;
            yield return null;
        }
    }
}
