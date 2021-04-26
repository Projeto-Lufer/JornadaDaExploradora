using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    public virtual void Interact() { }

    public virtual void Interact(GameObject interactor) { }
}
