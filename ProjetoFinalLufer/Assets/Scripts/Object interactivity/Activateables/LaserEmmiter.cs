using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEmmiter : MonoBehaviour
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
        if(canEmmit)
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

                if (hit.transform.tag == "Receptor" || hit.transform.tag == "Redirector")
                {
                    if (lastHit == null)
                    {
                        hit.transform.SendMessage("Interact");
                        lastHit = hit.transform.gameObject;
                    }
                    else if(lastHit != null && lastHit.tag == "Shield")
                    {
                        lastHit.SendMessage("Interact");
                        hit.transform.SendMessage("Interact");
                        lastHit = hit.transform.gameObject;
                    }
                }
                else if (hit.transform.tag == "Shield")
                {
                    if (lastHit == null)
                    {
                        hit.transform.SendMessage("Interact");
                        lastHit = hit.transform.gameObject;
                    }
                    else if(lastHit != null && lastHit.tag != "Shield")
                    {
                        hit.transform.SendMessage("Interact");
                    }
                }
                else
                {
                    if (lastHit != null)
                    {
                        if(lastHit.activeSelf == true)
                        {
                            lastHit.transform.SendMessage("Interact");
                        }
                        lastHit = null;
                    }
                }
            }
            else
            {
                lr.SetPosition(1, transform.forward * maxDistance);

                if (lastHit != null)
                {
                    if(lastHit.activeSelf == true)
                    {
                        lastHit.transform.SendMessage("Interact");
                    }
                    lastHit = null;
                }
            }
        }
        else
        {
            if(lastHit != null)
            {
                lastHit.SendMessage("Interact");
                lastHit = null;
            }
            lr.SetPosition(0, startPoint.position);
            lr.SetPosition(1, startPoint.position);
        }

    }
}
