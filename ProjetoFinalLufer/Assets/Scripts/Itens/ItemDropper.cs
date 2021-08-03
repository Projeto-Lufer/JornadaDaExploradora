using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private GameObject itemToDrop;

    public void DropItem()
    {
        Instantiate(itemToDrop, transform.position, transform.rotation);
    }
}
