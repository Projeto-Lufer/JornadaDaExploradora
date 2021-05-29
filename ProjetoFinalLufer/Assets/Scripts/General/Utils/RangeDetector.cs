using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetector : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private int targetLayer;
    
    [SerializeField] private Transform thisTransform;

    private int layerMask;

    private void Start()
    {
        layerMask = 1 << targetLayer;
        Debug.Log(LayerMask.LayerToName(6));
        Debug.Log(layerMask);
    }

    public Collider[] GetCollisionsInArea()
    {
        return Physics.OverlapSphere(thisTransform.position, radius, layerMask);
    }

    private void OnDrawGizmosSelected()
    { 
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(thisTransform.position, radius);
    }
}
