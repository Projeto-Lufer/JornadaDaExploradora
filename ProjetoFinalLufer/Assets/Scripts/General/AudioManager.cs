using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void PlaySFX(AudioClip audioToPlay, bool varyPitch = false, bool stopLastAudio = false)
    {
        if (varyPitch)
            audioSource.pitch = Random.Range(0.8f, 1.2f);
        
        if (stopLastAudio)
            audioSource.Stop();

        audioSource.clip = audioToPlay;
        audioSource.Play();
    }
}
