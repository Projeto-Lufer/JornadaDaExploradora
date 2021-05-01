using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivateableByCorrectOrder : Activateable
{
    [SerializeField] private DeactivateableActivator[] activatorOrder;

    private List<DeactivateableActivator> activeActivators = new List<DeactivateableActivator>();

    public override void Activate(GameObject activatorGameObject)
    {
        DeactivateableActivator activator = activatorGameObject.GetComponent<DeactivateableActivator>();

        if (!activeActivators.Contains(activator))
        {
            activeActivators.Add(activator);
            if (activeActivators.Count == activatorOrder.Length)
            {
                for (int i = 0; i < activatorOrder.Length; ++i)
                {
                    if (activatorOrder[i] != activeActivators[i])
                    {
                        FailPuzzle();
                        return;
                    }
                }
                ExecuteActivation();
            }
        }
    }

    public override void Deactivate(GameObject activatorGameObject)
    {
        DeactivateableActivator activator = activatorGameObject.GetComponent<DeactivateableActivator>();
        if (activeActivators.Contains(activator))
        {
            activeActivators.Remove(activator);
        }
    }

    private void FailPuzzle()
    {
        DeactivateableActivator[] auxArray = new DeactivateableActivator[activeActivators.Count];
        activeActivators.CopyTo(auxArray);

        foreach (DeactivateableActivator activator in auxArray)
        {
            activator.Deactivate();
        }
    }

    protected abstract void ExecuteActivation();
}
