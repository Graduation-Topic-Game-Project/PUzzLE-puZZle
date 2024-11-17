using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class BattleGameController : MonoBehaviour
{
    public event EventHandler Event_BattleStart;
    public event Action<int> Event_RemovePlacedPuzzle; //�����w��m����
    public event EventHandler Event_PuzzlePlaceCompleted; //���ϩ�m����
    public event EventHandler Event_SettlementBoard; //����L��
    public event EventHandler Event_SettlementEnemySkill; //����ĤH�ޯ�
    public event EventHandler Event_EndTurn; //�����^�X
    //public event EventHandler Event_BillingEssencePointForBoard;


    public Puzzle puzzlePrefab; //�w�]����Prefab

    [Header("���d��T")]
    public BattleInformation battleInformation;

    [Header("�٦�")]
    public Partner[] partners = new Partner[4]; //�n�԰����٦�

    [Header("���")]
    public List<Enemy> enemies = new List<Enemy>();

    [Header("��e��ܪ�����")]
    public PuzzleData specifyPuzzle; //��ܪ��ƾ԰ϫ���
    public int specifyPuzzleNumber; //��ܪ��ƾ԰Ͻs��(�ĴX��)
    public bool isSpecifyPuzzle = false; //�O�_��ܳƾ԰ϫ���
    [Header("�H���ͦ� or �q�٦���Ϯw�ͦ�")]
    [Tooltip("(false:�H���ͦ� true:�٦���Ϯw�ͦ�)")]
    public bool RandowOrForParnent = false; //�H���ͦ� or �q�٦���Ϯw�ͦ�(�q�{�H��)


    private void Start()
    {
        Event_BattleStart?.Invoke(this, EventArgs.Empty);
        isSpecifyPuzzle = false;
    }

    /// <summary>
    /// ��s��ܪ��ƾ԰Ͻs�����ƾ԰�
    /// </summary>
    public void CallEvent_RemovePlacedPuzzle()
    {
        Event_RemovePlacedPuzzle?.Invoke(specifyPuzzleNumber); 

    }

    /// <summary>
    /// �o�e���ϩ�m�����ƥ�
    /// </summary>
    public void CallEvent_PlacedPuzzle()
    {
        Event_PuzzlePlaceCompleted?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// �o�e����ƥ�
    /// </summary>
    public void CallEvent_SettlementBoard()
    {
        Event_SettlementBoard?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// �o�e�^�X�����ƥ�
    /// </summary>
    public void CallEvent_EndTurn()
    {
        Event_EndTurn?.Invoke(this, EventArgs.Empty);
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


}
