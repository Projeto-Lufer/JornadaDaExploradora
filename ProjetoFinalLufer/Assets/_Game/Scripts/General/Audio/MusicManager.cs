using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    
    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string music1MenuTheme;

    [FMODUnity.EventRef]
    public string music2Cutscene;

    [FMODUnity.EventRef]
    public string music3Overworld;

    [FMODUnity.EventRef]
    public string music4FirstTemple;

    [FMODUnity.EventRef]
    public string music5AylaTheme;

    [FMODUnity.EventRef]
    public string music6SpiritTheme;

    [FMODUnity.EventRef]
    public string music7EnemiesTheme;

    [FMODUnity.EventRef]
    public string music8BossFightTheme;

    public void PlayMusic(string musicEvent)
    {
        
        FMODUnity.RuntimeManager.PlayOneShot(musicEvent, transform.position);
    }
}