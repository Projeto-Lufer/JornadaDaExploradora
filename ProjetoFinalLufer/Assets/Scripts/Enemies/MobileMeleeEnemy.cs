using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobileMeleeEnemy : MonoBehaviour
{
    private enum states {Idle, Patrolling, Chasing}

    [SerializeField] private AreaDetector chaseAreaDetector;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] patrolPoints;

    private states currentState;
    private int nextPatrolPointIndex;

    private Coroutine currentStateCoroutine;

    private IEnumerator Start()
    {
        currentState = states.Idle;
        chaseAreaDetector.triggerEnterCallback = StartChasing;
        chaseAreaDetector.triggerExitCallback = StartPatrolling;

        yield return null;

        StartPatrolling(null);
        nextPatrolPointIndex = 0;
    }

    public void StartPatrolling(GameObject _)
    {
        if(currentState != states.Patrolling)
        {
            if(currentStateCoroutine != null) StopCoroutine(currentStateCoroutine);

            Debug.Log("Patrol");
            currentStateCoroutine = StartCoroutine(Patrol());
        }
    }

    public void StartChasing(GameObject target)
    {
        if (currentState != states.Chasing)
        {
            if (currentStateCoroutine != null) StopCoroutine(currentStateCoroutine);

            currentStateCoroutine = StartCoroutine(Chase(target.transform));
        }
    }

    IEnumerator Patrol()
    {
        currentState = states.Patrolling;
        agent.destination = patrolPoints[nextPatrolPointIndex].position;
        
        while (true)
        {
            Debug.Log(Vector3.Distance(patrolPoints[nextPatrolPointIndex].position, transform.position));
            if (Vector3.Distance(patrolPoints[nextPatrolPointIndex].position, transform.position) <= 1.2)
            {
                if (++nextPatrolPointIndex >= patrolPoints.Length)
                    nextPatrolPointIndex = 0;

                agent.destination = patrolPoints[nextPatrolPointIndex].position;
                Debug.Log(agent.destination);
            }
            yield return null; // Maybe make it wait for some seconds so it's not so performance intensive
        }
    }

    IEnumerator Chase(Transform target)
    {
        currentState = states.Chasing;
        while (true)
        {
            agent.destination = target.position;
            yield return null;
        }
    }
}
