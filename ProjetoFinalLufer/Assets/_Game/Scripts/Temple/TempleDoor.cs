using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TempleDoor : MonoBehaviour
{
    [SerializeField] private TempleRoom myRoom;
    [SerializeField] private TempleRoom nextRoom;

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
        }            
    }
}
