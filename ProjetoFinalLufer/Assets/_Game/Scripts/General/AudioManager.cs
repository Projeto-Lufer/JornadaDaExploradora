using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string grassSteps;

    [FMODUnity.EventRef]
    public string stoneSteps;

    public void AudioFootsteps()
    {
        FMODUnity.RuntimeManager.PlayOneShot(grassSteps, transform.position);
    }
}
