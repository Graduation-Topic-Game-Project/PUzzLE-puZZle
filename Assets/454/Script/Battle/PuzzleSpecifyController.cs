using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ��ܡA��m�A�ͦ����Ϫ��`���
/// </summary>
public class PuzzleSpecifyController : MonoBehaviour
{
    BattleGameController battleGameController;

    public Puzzle puzzlePrefab; //�w�]����Prefab

    [Header("���e��ܪ�����")]
    public PuzzleData specifyPuzzle; //��ܪ��ƾ԰ϫ���
    public int specifyPuzzleNumber = -1; //��ܪ��ƾ԰Ͻs��(�ĴX��)
    public bool isSpecifyPuzzle = false; //�O�_��ܳƾ԰ϫ���
    [Header("�H���ͦ� or �q�٦���Ϯw�ͦ�")]
    [Tooltip("(false:�H���ͦ� true:�٦���Ϯw�ͦ�)")]
    public bool RandowOrForParnent = false; //�H���ͦ� or �q�٦���Ϯw�ͦ�(�q�{�H��)

    public event Action<int> Event_RemovePlacedPuzzle; //�����w��m�������ƾ԰ϫ���
    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
    }
    private void Start()
    {
        isSpecifyPuzzle = false;
    }

    /// <summary>
    /// �O�_�i��m����
    /// </summary>
    public bool CanPlacePuzzle()
    {
        if (isSpecifyPuzzle == false) //�p�G�����w����
        {
            MessageTextController.SetMessage("�����w����");
            return false;
        }

        if (ActionPoint_Controller.ActionPoint <= 0) //�p�G��ʭȬ��s
        {
            MessageTextController.SetMessage("��ʭȤ���");
            return false;
        }

        return true;
    }

    /// <summary>
    /// ��s��ܪ��ƾ԰Ͻs�����ƾ԰�
    /// </summary>
    public void CallEvent_RemovePlacedPuzzle()
    {
        Event_RemovePlacedPuzzle?.Invoke(specifyPuzzleNumber);
    }
}