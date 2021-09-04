using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TempleDoor : MonoBehaviour
{
    TempleRoom myRoom;
    TempleRoom nextRoom;

    private void OnCollisionEnter(Collision other) {
        //se for o player
            //myRoom.DespawnItens
            //nextRoom.SpawnItens
            //lockar movimentação do player e tocar animação
            nextRoom.virtualCamera.Priority=1;
            myRoom.virtualCamera.Priority=0;
    }


}
