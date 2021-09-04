using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TempleRoom : MonoBehaviour
{
    [SerializeField] private TempleRoomElement[] elements;
    public CinemachineVirtualCamera virtualCamera;
    // !!! Para testar, remover depois
    private void Start()
    {
        SetRoom();
    }

    public void SetRoom()
    {
        foreach (TempleRoomElement element in elements)
        {
            element.Spawn();
        }
    }
}
