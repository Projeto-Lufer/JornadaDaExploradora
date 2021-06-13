using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetector : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private int targetLayer;
    [SerializeField] private List<string> obstructingTags;
    
    [SerializeField] private Transform thisTransform;

    private int layerMask;

    private void Start()
    {
        layerMask = 1 << targetLayer;
    }

    public Collider[] GetCollisionsInArea()
    {
        return Physics.OverlapSphere(thisTransform.position, radius, layerMask);
    }

    public bool GetHasLineOfSight(Transform target)
    {
        Vector3 distance = (target.position - thisTransform.position);
        RaycastHit[] hits = Physics.RaycastAll(thisTransform.position, distance.normalized, distance.magnitude);
        
        foreach(RaycastHit hit in hits)
        {
            if (obstructingTags.Contains(hit.collider.tag))
            {
                return false;
            }
        }
        return true;
    }

    private void OnDrawGizmosSelected()
    { 
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(thisTransform.position, radius);
    }
}
