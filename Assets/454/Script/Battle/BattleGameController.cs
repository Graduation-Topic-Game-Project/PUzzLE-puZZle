using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class BattleGameController : MonoBehaviour
{
    public event EventHandler Event_BattleStart;
    public event EventHandler Event_BattleAwake;
    public event EventHandler Event_TestUpdatePuzzleBoard;
    public event Action<int> Event_RemovePlacedPuzzle; //�����w��m����
    public event EventHandler Event_PuzzlePlaceCompleted; //���ϩ�m����

    public Puzzle puzzlePrefab; //�w�]����Prefab

    public PuzzleData specifyPuzzle; //��ܪ��ƾ԰ϫ���
    public int specifyPuzzleNumber; //��ܪ��ƾ԰ϫ��Ͻs��
    public bool isSpecifyPuzzle = false; //�O�_��ܳƾ԰ϫ���


    private void Awake()
    {
        Event_BattleAwake?.Invoke(this, EventArgs.Empty);
    }

    private void Start()
    {
        Event_BattleStart?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Event_TestUpdatePuzzleBoard?.Invoke(this, EventArgs.Empty);
        }
    }

    public void RemovePlacedPuzzle()
    {
        Event_RemovePlacedPuzzle?.Invoke(specifyPuzzleNumber); //��s��ܪ��ƾ԰Ͻs�����ƾ԰�
        isSpecifyPuzzle = false;
    }

    /// <summary>
    /// �o�e���ϩ�m�����ƥ�
    /// </summary>
    public void PlacedPuzzle()
    {
        Event_PuzzlePlaceCompleted?.Invoke(this, EventArgs.Empty);
    }


}
