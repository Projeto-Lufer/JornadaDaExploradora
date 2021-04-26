using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivateableByMultiple : Activateable
{
    [SerializeField] private int activatorsAmountNeeded;

    private List<GameObject> activeActivators = new List<GameObject>();

    public override void Activate(GameObject activator)
    {
        if(!activeActivators.Contains(activator))
        {
            activeActivators.Add(activator);
            if(activeActivators.Count == activatorsAmountNeeded)
            {
                ExecuteActivation();
            }
        }
    }
    public override void Deactivate(GameObject activator)
    {
        if (activeActivators.Contains(activator))
        {
            activeActivators.Remove(activator);
        }
    }

    protected abstract void ExecuteActivation();
}
