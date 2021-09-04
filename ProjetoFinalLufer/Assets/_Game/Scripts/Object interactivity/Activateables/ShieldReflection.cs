using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldReflection : MonoBehaviour
{
    private LineRenderer lr;
    private Transform startPoint;
    private GameObject lastHit;
    [SerializeField] private int maxDistance;
    public bool canEmmit;

    [SerializeField] private LayerMask ignoreLayer;
    private LayerMask targetLayers;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        startPoint = gameObject.transform;
        targetLayers = ~ignoreLayer;
    }

    // Update is called once per frame
    void Update()
    {
        Emmit();
    }

    public void Emmit()
    {
        if (canEmmit)
        {
            lr.positionCount = 2;
            lr.SetPosition(0, startPoint.position);
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.up, out hit, maxDistance, targetLayers))
            {
                if (hit.collider)
                {
                    lr.SetPosition(1, hit.point);
                }

                if (hit.transform.tag == "Receptor" || hit.transform.tag == "Redirector")
                {
                    if (lastHit == null)
                    {
                        hit.transform.SendMessage("Interact");
                        lastHit = hit.transform.gameObject;
                    }
                }
                else
                {
                    if (lastHit != null)
                    {
                        lastHit.transform.SendMessage("Interact");
                        lastHit = null;
                    }
                }
            }
            else
            {
                lr.SetPosition(1, transform.up * maxDistance);

                if (lastHit != null)
                {
                    lastHit.transform.SendMessage("Interact");
                    lastHit = null;
                }
            }
        }
        else
        {
            lr.SetPosition(0, startPoint.position);
            lr.SetPosition(1, startPoint.position);
        }

    }

    public void Interact()
    {
        if(canEmmit)
        {
            Debug.Log("Entrou caraleo");
            maxDistance = 0;
            canEmmit = false;
            if(lastHit != null)
            {
                lastHit.transform.SendMessage("Interact");
                lastHit = null;
            }
        }
        else
        {
            maxDistance = 1000;
            canEmmit = true;
        }
    }
}
