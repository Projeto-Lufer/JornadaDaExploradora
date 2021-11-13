using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    [SerializeField]
    private VideoClip clip;
    [SerializeField]
    private string sceneName;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        PlayStartThenChangeScene(sceneName);
    }

    public void PlayStartThenChangeScene(string sceneName)
    {
        videoPlayer.Play();
        // >>> começar audio do vídeo aqui <<<
        StartCoroutine(ChangeSceneOnVideoEnd(sceneName));
    }
    private IEnumerator ChangeSceneOnVideoEnd(string sceneName)
    {
        yield return new WaitUntil(() => videoPlayer.isPlaying);
        yield return new WaitUntil(() => !videoPlayer.isPlaying);
        SceneManager.LoadScene(sceneName);
    }
}
