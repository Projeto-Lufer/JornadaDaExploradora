using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomTransition : MonoBehaviour
{
    public CinemachineVirtualCamera vcam, currCam;
    public ConcurrentStateMachine stateMachine;

    [SerializeField] private Respawn respawn;

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
            else{
                currCam = vcam;
            }

            respawn.SetLastRoomVisited(other.GetComponentInParent<TempleRoom>());
        }
    }
}