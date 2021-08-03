using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRedirector : LaserEmmiter
{
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
}
