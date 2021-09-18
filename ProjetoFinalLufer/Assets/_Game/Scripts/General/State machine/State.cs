using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{ 
    public virtual void Enter() { }

    public virtual void Enter(GameObject gameObject) { }

    public virtual void Enter(float value) { }

    public virtual void HandleInput() { }

    public virtual void PhysicsUpdate() { }

    public virtual void LogicUpdate() { }

    public virtual void Exit() { }
}
