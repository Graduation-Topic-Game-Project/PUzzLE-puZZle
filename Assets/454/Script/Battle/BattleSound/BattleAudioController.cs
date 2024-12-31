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

    [Header("��m���ϭ���")]
    public AudioClip PuzzlePlace; //��m���ϭ���
    [Header("��ܳƾ԰ϫ��ϭ���")]
    public AudioClip SpecifyPuzzle; //��ܳƾ԰ϫ��ϭ���
    [Header("��������")]
    public AudioClip PlayerAttacked; //��������
    [Header("�^�X��������")]
    public AudioClip EndTurn; //�^�X��������

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
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

    /// <summary>�����ܳƾ԰ϫ��ϭ��� </summary>
    public void PlayAudio_SpecifyPuzzle(bool isSpecify)
    {
        if(isSpecify == true) //�Y�ƥ�O�ѿ�ܫ���Ĳ�o��
        audioSource.PlayOneShot(SpecifyPuzzle);
    }

    /// <summary>�����m���ϭ��� </summary>
    public void PlayAudio_PuzzlePlace(object sender, EventArgs e)
    {
        audioSource.PlayOneShot(PuzzlePlace, 2.1f);
    }

    /// <summary>���񪱮a���˭��� </summary>
    public static void PlayAudio_PlayerAttacked()
    {
        @this.audioSource.PlayOneShot(@this.PlayerAttacked);
    }

    /// <summary>����^�X�������� </summary>
    public void PlayAudio_EndTurn(object sender, EventArgs e)
    {
        audioSource.PlayOneShot(EndTurn);
    }

}
