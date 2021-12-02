using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    
    [Header("Audio FMOD Event")]
    FMOD.Studio.EventInstance musicPlaying;

    [FMODUnity.ParamRef]
    public string eventParameter;


    void Start ()
    {
        musicPlaying = FMODUnity.RuntimeManager.CreateInstance("event:/Music/music-manager");
        musicPlaying.start();
        Debug.Log("Music Started");
    }

    public void PlayMusic(int musicNumber)
    {
        Debug.Log("Music Number Playing: " + musicNumber);
        switch (musicNumber)
        {
            case 1:
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicParameter", 1f);
                break;
            case 2:
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicParameter", 2f);
                break;
            case 3:
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicParameter", 3f);
                break;
            case 4:
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicParameter", 4f);
                break;
            case 5:
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicParameter", 5f);
                break;
            case 6:
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicParameter", 6f);
                break;
            case 7:
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicParameter", 7f);
                break;
            case 8:
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicParameter", 8f);
                break;
        }
    }
}