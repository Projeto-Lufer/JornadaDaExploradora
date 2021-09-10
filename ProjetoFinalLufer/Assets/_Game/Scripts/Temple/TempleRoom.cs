using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TempleRoom : MonoBehaviour
{
    [SerializeField] private TempleRoomElement[] elements;
    public CinemachineVirtualCamera virtualCamera;
    public void SpawnElements()
    {
        playerIsHere = true;
        foreach (TempleRoomElement element in elements)
        {
            element.Spawn();
        }
    }

    public void SetRoom()
    {
        foreach (TempleRoomElement element in elements)
        {
            element.Spawn();
        }
    }
}
