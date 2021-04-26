using UnityEngine;

public class Activateable : MonoBehaviour
{
    public virtual void Activate() { }
    
    public virtual void Activate(GameObject activator) { }

    public virtual void Deactivate() { }

    public virtual void Deactivate(GameObject activator) { }
}
