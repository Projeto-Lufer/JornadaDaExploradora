using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPosition;
    [SerializeField] private Transform playerRootTransform;

    private TempleRoom room;

    public void RespawnPlayer()
    {
        playerRootTransform.GetComponentInChildren<PlayerHealthPoints>().MaxOutHealth();
        playerRootTransform.gameObject.SetActive(true);
        playerRootTransform.position = respawnPosition.position;
        room.DestroyElements();
    }

    public void SetLastRoomVisited(TempleRoom room)
    {
        this.room = room;
    }
}
