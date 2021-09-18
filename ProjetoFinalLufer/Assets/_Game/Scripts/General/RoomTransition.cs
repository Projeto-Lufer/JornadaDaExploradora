using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomTransition : MonoBehaviour
{
    [HideInInspector]
    public CinemachineVirtualCamera vcam, currCam;
    public ConcurrentStateMachine stateMachine;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Room"))
        {
            vcam = other.GetComponentInChildren<CinemachineVirtualCamera>();
            vcam.Priority = 10;
            if(currCam != null && currCam != vcam)
            {
                currCam.Priority = 0;
                currCam = vcam;
                stateMachine.ChangeState(typeof(PlayerTransitionState));
            }

            //currCam.Follow = transform;

        }
    }
}
