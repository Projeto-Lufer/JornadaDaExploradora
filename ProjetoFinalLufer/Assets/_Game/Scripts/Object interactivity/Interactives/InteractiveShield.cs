using UnityEngine;

public class InteractiveShield : Interactive
{
    [SerializeField] private ItemConfig shieldConfig;
    public override void Interact(GameObject interactor)
    {
        interactor.GetComponentInChildren<ObjectCollector>().GetItem(shieldConfig);

        Destroy(this.gameObject);
    }
}