using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnableWhenHit : HealthPoints
{
    [TextArea()]
    [SerializeField] private string WARNING;

    [SerializeField] private Transform objectToTurn;
    [HideInInspector] public bool canTurn = false;

    private Coroutine turnCoroutine = null;
    private float maxTurnAmount = 90f;

    public override void ReduceHealth(ComboElement attackStats)
    {
        if (turnCoroutine == null)
        {
            turnCoroutine = StartCoroutine(TurnAnimation());
        }
    }

    public IEnumerator TurnAnimation()
    {
        float totalRotation = 0;
        float currTurnAmount = 0;

        while (totalRotation < maxTurnAmount)
        {
            currTurnAmount += Time.deltaTime * 90;

            if (totalRotation + currTurnAmount > maxTurnAmount)
            {
                currTurnAmount = maxTurnAmount - totalRotation;
            }
            objectToTurn.rotation *= Quaternion.AngleAxis(currTurnAmount, Vector3.up);

            totalRotation += currTurnAmount;

            yield return null;
        }

        turnCoroutine = null;
    }
}
