using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class BattleGameController : MonoBehaviour
{
    public event EventHandler Event_BattleStart;
    public event EventHandler Event_StartTurn; //回合開始
    public event EventHandler Event_SpecifyPuzzle; //選擇拼圖
    public event EventHandler Event_PuzzlePlaceCompleted; //拼圖放置完成
    public event EventHandler Event_SettlementBoard; //結算盤面
    public event EventHandler Event_SettlementEnemySkill; //結算敵人技能
    public event EventHandler Event_EndTurn; //結束回合

    [Header("關卡資訊")]
    public BattleInformation battleInformation;

    [Header("夥伴")]
    public Partner[] partners = new Partner[4]; //要戰鬥的夥伴

    [Header("對手")]
    public List<Enemy> enemies = new List<Enemy>();


    private void Start()
    {
        Event_BattleStart?.Invoke(this, EventArgs.Empty);
        CallEvent_StartTurn(); //回合開始事件
    }

    /*public void CallEvent(EventHandler _event)
    {
        _event?.Invoke(this, EventArgs.Empty);
    }*/


    /// <summary>
    /// 發送回合開始事件
    /// </summary>
    public void CallEvent_StartTurn()
    {
        Event_StartTurn?.Invoke(this, EventArgs.Empty);
        //Debug.Log("新的回合開始");
    }

    /// <summary>
    /// 發送選擇拼圖事件
    /// </summary>
    public void CallEvent_SpecifyPuzzle()
    {
        Event_SpecifyPuzzle?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 發送拼圖放置完成事件
    /// </summary>
    public void CallEvent_PlacedPuzzle()
    {
        Event_PuzzlePlaceCompleted?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 發送結算盤面拼圖事件
    /// </summary>
    public void CallEvent_SettlementBoard()
    {
        Event_SettlementBoard?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 發送結算敵人技能事件
    /// </summary>
    public void CallEvent_SettlementEnemySkill()
    {
        Event_SettlementEnemySkill?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 發送回合結束事件
    /// </summary>
    public void CallEvent_EndTurn()
    {
        Event_EndTurn?.Invoke(this, EventArgs.Empty);
    }




}
