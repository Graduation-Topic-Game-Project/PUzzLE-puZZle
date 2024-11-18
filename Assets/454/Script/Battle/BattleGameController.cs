using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class BattleGameController : MonoBehaviour
{
    public event EventHandler Event_BattleStart;
    public event EventHandler Event_PuzzlePlaceCompleted; //���ϩ�m����
    public event EventHandler Event_SettlementBoard; //����L��
    public event EventHandler Event_SettlementEnemySkill; //����ĤH�ޯ�
    public event EventHandler Event_EndTurn; //�����^�X




    [Header("���d��T")]
    public BattleInformation battleInformation;

    [Header("�٦�")]
    public Partner[] partners = new Partner[4]; //�n�԰����٦�

    [Header("���")]
    public List<Enemy> enemies = new List<Enemy>();


    private void Start()
    {
        Event_BattleStart?.Invoke(this, EventArgs.Empty);

    }

    /// <summary>
    /// �o�e���ϩ�m�����ƥ�
    /// </summary>
    public void CallEvent_PlacedPuzzle()
    {
        Event_PuzzlePlaceCompleted?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// �o�e����L�����Ϩƥ�
    /// </summary>
    public void CallEvent_SettlementBoard()
    {
        Event_SettlementBoard?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// �o�e����ĤH�ޯ�ƥ�
    /// </summary>
    public void CallEvent_SettlementEnemySkill()
    {
        Event_SettlementEnemySkill?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// �o�e�^�X�����ƥ�
    /// </summary>
    public void CallEvent_EndTurn()
    {
        Event_EndTurn?.Invoke(this, EventArgs.Empty);
    }




}
