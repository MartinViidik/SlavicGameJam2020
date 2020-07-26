using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer VideoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
    void Start()
    {
        VideoPlayer.loopPointReached += LoadScene;
    }
    void LoadScene(VideoPlayer vp)
    {
        LevelChanger.Instance.LoadLevel(2);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            LoadScene(VideoPlayer);
        }
    }
}