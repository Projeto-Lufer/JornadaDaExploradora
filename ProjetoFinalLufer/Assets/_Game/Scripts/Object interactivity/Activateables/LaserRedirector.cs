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
            canEmmit = false;
        }
        else
        {
            canEmmit = true;
        }
    }

    public void Turn()
    {
        transform.rotation *= Quaternion.AngleAxis(90.0f, Vector3.up);
        transform.GetChild(0).rotation *= Quaternion.AngleAxis(-90.0f, Vector3.up);
    }
}
