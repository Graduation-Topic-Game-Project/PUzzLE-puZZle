using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class BattleAudioController : MonoBehaviour
{
    static BattleAudioController @this;
    BattleGameController battleGameController;
    AudioSource audioSource;

    [Header("放置拼圖音效")]
    public AudioClip PuzzlePlace; //放置拼圖音效
    [Header("選擇備戰區拼圖音效")]
    public AudioClip SpecifyPuzzle; //選擇備戰區拼圖音效
    [Header("受擊音效")]
    public AudioClip PlayerAttacked; //受擊音效
    [Header("回合結束音效")]
    public AudioClip EndTurn; //回合結束音效

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        if (@this == null)
        {
            @this = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        battleGameController.Event_SpecifyPuzzle += this.PlayAudio_SpecifyPuzzle;
        battleGameController.Event_PuzzlePlaceCompleted += this.PlayAudio_PuzzlePlace;
        battleGameController.Event_EndTurn += this.PlayAudio_EndTurn;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>撥放選擇備戰區拼圖音效 </summary>
    public void PlayAudio_SpecifyPuzzle(bool isSpecify)
    {
        if(isSpecify == true) //若事件是由選擇拼圖觸發的
        audioSource.PlayOneShot(SpecifyPuzzle);
    }

    /// <summary>撥放放置拼圖音效 </summary>
    public void PlayAudio_PuzzlePlace(object sender, EventArgs e)
    {
        audioSource.PlayOneShot(PuzzlePlace, 2.1f);
    }

    /// <summary>撥放玩家受傷音效 </summary>
    public static void PlayAudio_PlayerAttacked()
    {
        @this.audioSource.PlayOneShot(@this.PlayerAttacked);
    }

    /// <summary>撥放回合結束音效 </summary>
    public void PlayAudio_EndTurn(object sender, EventArgs e)
    {
        audioSource.PlayOneShot(EndTurn);
    }

}
