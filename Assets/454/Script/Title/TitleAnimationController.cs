using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TitleAnimationController : MonoBehaviour
{
    public VideoClip Title_In; // �ʺA���D�J
    public VideoClip Title_Cycle; // �ʺA���D�`��

    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    private bool isFirstVideoPlaying = true;

    void Start()
    {
        videoPlayer ??= GetComponent<VideoPlayer>();
        audioSource ??= GetComponent<AudioSource>();

        // �j�w�ƥ�
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    void OnVideoEnd(VideoPlayer vp) //�v�������ɰ���
    {

        if (isFirstVideoPlaying)
        {
            Debug.Log("Title in ���񵲧�");
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

