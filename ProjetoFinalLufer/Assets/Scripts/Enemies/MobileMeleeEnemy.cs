using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobileMeleeEnemy : MonoBehaviour
{
    private enum states {Idle, Patrolling, Chasing, Fighting, Attacking}

    [SerializeField] private AreaDetector chaseAreaDetector;
    [SerializeField] private AreaDetector fightAreaDetector;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private MeleeAttacks attack;
    [SerializeField] private Animator animator;
    [SerializeField] private float attackPlayerDelay;

    private Dictionary<string, float> animationTimes = new Dictionary<string, float>();
    private states currentState;
    private int nextPatrolPointIndex;
    private WaitForSeconds attackAnimationLength;
    private Coroutine currentStateCoroutine;

    private IEnumerator Start()
    {
        currentState = states.Idle;
        chaseAreaDetector.triggerEnterCallback = StartChasing;
        chaseAreaDetector.triggerExitCallback = StartPatrolling;
        fightAreaDetector.triggerEnterCallback = StartFighting;
        fightAreaDetector.triggerExitCallback = StartChasing;

        yield return null;

        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            animationTimes[clip.name] = clip.length;
        }

        attackAnimationLength = new WaitForSeconds(animationTimes["Attack"]);

        StartPatrolling(null);
        nextPatrolPointIndex = 0;
    }
    
    public void StartPatrolling(GameObject _)
    {
        Debug.Log("Patrolling");
        if (currentState != states.Patrolling)
        {
            currentState = states.Patrolling;
            agent.isStopped = false;
            PlayAnimationTrigger("Walking");
            if (currentStateCoroutine != null) StopCoroutine(currentStateCoroutine);

            currentStateCoroutine = StartCoroutine(Patrol());
        }
    }

    public void StartChasing(GameObject target)
    {
        Debug.Log("Chasing");
        if (currentState != states.Chasing)
        {
            currentState = states.Chasing;
            agent.isStopped = false;
            PlayAnimationTrigger("Walking");
            if (currentStateCoroutine != null) StopCoroutine(currentStateCoroutine);

            currentStateCoroutine = StartCoroutine(Chase(target.transform));
        }
    }

    public void StartFighting(GameObject target)
    {
        Debug.Log("Fighting");
        if (currentState != states.Fighting)
        {
            currentState = states.Fighting;
            agent.isStopped = true;
            PlayAnimationTrigger("Fighting");
            if (currentStateCoroutine != null) StopCoroutine(currentStateCoroutine);

            currentStateCoroutine = StartCoroutine(Fight(target.transform));
        }
    }

    private void PlayAnimationTrigger(string animationName)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            animator.SetTrigger(animationName);
        }
    }

    IEnumerator Patrol()
    {
        agent.destination = patrolPoints[nextPatrolPointIndex].position;
        
        while (true)
        {
            if (Vector3.Distance(patrolPoints[nextPatrolPointIndex].position, transform.position) <= 1.2)
            {
                if (++nextPatrolPointIndex >= patrolPoints.Length)
                    nextPatrolPointIndex = 0;

                agent.destination = patrolPoints[nextPatrolPointIndex].position;
            }
            yield return null; // Maybe make it wait for some seconds so it's not so performance intensive
        }
    }

    IEnumerator Chase(Transform target)
    {
        while (true)
        {
            agent.destination = target.position;
            yield return null;
        }
    }

    // Will be called when the player is close to enemy
    IEnumerator Fight(Transform target)
    {
        while (true)
        {
            PlayAnimationTrigger("Fighting");
            for (float i = 0 ; i < attackPlayerDelay ; i += Time.deltaTime)
            {
                transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
                yield return null;
            }
            PlayAnimationTrigger("Attacking");
            attack.Sweep();
            yield return attackAnimationLength;
        }
    }
}
