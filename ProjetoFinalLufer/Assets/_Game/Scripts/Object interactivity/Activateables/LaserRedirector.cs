using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRedirector : LaserEmmiter
{
    public bool canTurn = false;
    public void Interact()
    {
        if(canEmmit)
        {
            Debug.Log("cannot emmit");
            canEmmit = false;
        }
        else
        {
            Debug.Log("can emmit");
            canEmmit = true;
        }
    }

    public void Turn()
    {
        transform.rotation *= Quaternion.AngleAxis(90.0f, Vector3.up);
        transform.GetChild(0).rotation *= Quaternion.AngleAxis(-90.0f, Vector3.up);
    }
}
