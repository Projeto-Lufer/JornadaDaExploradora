using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEmmiter : Activateable
{
    [SerializeField] private int maxDistance;
    [SerializeField] private LayerMask ignoreLayer;
    [SerializeField] private bool startOn;
    [SerializeField] private Transform startPoint;

    private LineRenderer lr;
    private GameObject lastHit;
    private LayerMask targetLayers;
    private Coroutine emmitCoroutine;
    private Activator lastActivatorHit;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        targetLayers = ~ignoreLayer;
        lastHit = gameObject;

        if(startOn)
        {
            this.Activate();
        }
    }

    public override void Activate()
    {
        if(emmitCoroutine == null)
        {
            emmitCoroutine = StartCoroutine(Emmit());
        }
    }

    public override void Deactivate()
    {
        lr.SetPosition(0, startPoint.position);
        lr.SetPosition(1, startPoint.position);

        DisableLastActivatorHit();
        if(emmitCoroutine != null)
        {
            StopCoroutine(emmitCoroutine);
            emmitCoroutine = null;
        }
    }

    public IEnumerator Emmit()
    {
        while (true)
        {
            lr.positionCount = 2;
            lr.SetPosition(0, startPoint.position);
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, targetLayers))
            {
                if (hit.collider)
                {
                    lr.SetPosition(1, hit.point);
                }

                if (IsHittingDifferentObject(hit))
                {
                    DisableLastActivatorHit();
                    if (hit.transform.CompareTag("Receptor") || hit.transform.CompareTag("Shield"))
                    {
                        lastActivatorHit = hit.transform.GetComponent<Activator>();
                        lastActivatorHit.Interact();
                    }

                    lastHit = hit.collider.gameObject;
                }
            }
            else
            {
                lr.SetPosition(1, transform.forward * maxDistance);
                DisableLastActivatorHit();
                
                lastActivatorHit = null;
                lastHit = null;
            }
            yield return null;
        }
    }

    private bool IsHittingDifferentObject(RaycastHit raycastData)
    {
        return lastHit == null || !lastHit.Equals(raycastData.collider.gameObject);
    }

    private void DisableLastActivatorHit()
    {
        if (lastActivatorHit != null)
        {
            if (lastActivatorHit.gameObject.activeSelf)
            {
                lastActivatorHit.Interact();
            }
            lastActivatorHit = null;
        }
    }
}
