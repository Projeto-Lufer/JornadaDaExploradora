using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private GameObject itemToDrop;

    public virtual void DropItem()
    {
        if(itemToDrop != null)
        {
            Instantiate(itemToDrop, transform.position, transform.rotation);
        }
    }
}
