using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    public virtual void Interact(GameObject interactor) { }

    public virtual System.Type GetClassType()
    {
        return this.GetType();
    }
}
