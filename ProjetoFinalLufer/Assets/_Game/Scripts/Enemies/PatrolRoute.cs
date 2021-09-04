using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    [SerializeField] [TextArea(5, 10)] private string howToUse;
    [SerializeField] private Transform[] patrolPoints;

    private int nextPatrolPointIndex;

    public void StartPatrolRoute()
    {
        nextPatrolPointIndex = 0;
    }

    public Vector3 GetNextPatrolPointPosition()
    {
        return patrolPoints[nextPatrolPointIndex].position;
    }

    public void GoToNextPatrolPoint()
    {
        if (++nextPatrolPointIndex >= patrolPoints.Length)
        {
            nextPatrolPointIndex = 0;
        }
    }
}
