using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("External references")]
    [SerializeField] private GameObject objectToPool;

    [Header("Gameplay tweeking fields")]
    [SerializeField] private int amountToPool;

    private List<GameObject> pooledObjects;

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        
        for(int i = 0 ; i < amountToPool ; ++i)
        {
            AddNewInstanceToPool();
        }
    }

    private GameObject AddNewInstanceToPool()
    {
        GameObject tmp;
        tmp = Instantiate(objectToPool, this.transform);
        tmp.SetActive(false);
        pooledObjects.Add(tmp);
        return tmp;
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0 ; i < amountToPool ; ++i)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }
        // Needs more objects than we have instantiated, so we create more
        GameObject newObject = AddNewInstanceToPool();
        newObject.SetActive(true);

        return newObject;
    }
}
