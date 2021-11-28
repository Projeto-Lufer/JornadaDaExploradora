using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TempleDoor : MonoBehaviour
{
    [SerializeField] private TempleRoom myRoom;
    [SerializeField] private TempleRoom nextRoom;
    [SerializeField] private TempleDoor nextDoor;
    [SerializeField] private Transform teleportLocation;

    private void OnTriggerEnter(Collider other) {
        //se for o player
        //myRoom.DespawnItens
        //nextRoom.SpawnItens
        //lockar movimentação do player e tocar animação
        if (other.tag == "Player")
        { 
            myRoom.DestroyElements();
            nextRoom.SpawnElements();
            nextRoom.virtualCamera.Priority = 1;
            myRoom.virtualCamera.Priority = 0;

            nextDoor.TeleportPlayerHere(other.transform);
        }            
    }


    public void TeleportPlayerHere(Transform player)
    {
        player.position = teleportLocation.position;
        Physics.SyncTransforms();
    }
}
