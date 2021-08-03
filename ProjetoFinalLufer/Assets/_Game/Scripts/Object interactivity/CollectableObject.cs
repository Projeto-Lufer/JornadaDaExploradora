using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}
