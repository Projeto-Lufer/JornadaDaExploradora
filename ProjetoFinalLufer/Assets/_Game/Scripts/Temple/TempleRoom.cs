using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TempleRoom : MonoBehaviour
{
    [SerializeField] private TempleRoomElement[] elements;
    [SerializeField] private GameObject shadowsParent;
    public CinemachineVirtualCamera virtualCamera;
    private Coroutine shadowsCoroutine;


    [Header("Audio FMOD Event")]
    public MusicManager musicController = null;
    public int musicNumber = 3;

    public void SpawnElements()
    {
        musicController.PlayMusic(musicNumber);
        foreach (TempleRoomElement element in elements)
        {
            element.Spawn();
        }
        StartShadowsStateChangeCoroutine(0, true);
    }

    public void DestroyElements()
    {
        foreach (TempleRoomElement element in elements)
        {
            element.Despawn();
        }
        StartShadowsStateChangeCoroutine(2, false);
    }

    private void StartShadowsStateChangeCoroutine(float delay, bool show)
    {
        if(shadowsCoroutine != null)
        {
            StopCoroutine(shadowsCoroutine);
        }

        shadowsCoroutine = StartCoroutine(SetShadowsShowStateWithDelay(delay, show));
    }

    private IEnumerator SetShadowsShowStateWithDelay(float delay, bool show)
    {
        yield return new WaitForSeconds(delay);

        shadowsParent.SetActive(show);
        shadowsCoroutine = null;
    }
}
