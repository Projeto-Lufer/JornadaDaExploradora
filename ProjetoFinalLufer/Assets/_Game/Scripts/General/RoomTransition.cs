using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomTransition : MonoBehaviour
{
    public CinemachineVirtualCamera vcam, currCam;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Room"))
        {
            vcam = other.GetComponentInChildren<CinemachineVirtualCamera>();
            vcam.Priority = 10;
            if(currCam != null)
            {
                currCam.Priority = 0;
            }
            currCam = vcam;
        }
    }
}
