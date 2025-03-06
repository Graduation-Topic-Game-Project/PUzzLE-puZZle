using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TitleAnimationController : MonoBehaviour
{
    public VideoClip Title_In; // 動態標題入
    public VideoClip Title_Cycle; // 動態標題循環

    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    private bool isFirstVideoPlaying = true;

    void Start()
    {
        videoPlayer ??= GetComponent<VideoPlayer>();
        audioSource ??= GetComponent<AudioSource>();

        // 綁定事件
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    void OnVideoEnd(VideoPlayer vp) //影片結束時執行
    {

        if (isFirstVideoPlaying)
        {
            Debug.Log("Title in 撥放結束");
            isFirstVideoPlaying = false;
            PlayVideo(Title_Cycle);
        }
    }
    void PlayVideo(VideoClip clip)
    {
        videoPlayer.clip = clip;
        videoPlayer.Play();
    }

    private void OnDestroy()
    {
        videoPlayer.loopPointReached -= OnVideoEnd;
    }
}

