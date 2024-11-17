using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class BattleGameController : MonoBehaviour
{
    public event EventHandler Event_BattleStart;
    public event Action<int> Event_RemovePlacedPuzzle; //移除已放置拼圖
    public event EventHandler Event_PuzzlePlaceCompleted; //拼圖放置完成
    public event EventHandler Event_SettlementBoard; //結算盤面
    public event EventHandler Event_SettlementEnemySkill; //結算敵人技能
    public event EventHandler Event_EndTurn; //結束回合
    //public event EventHandler Event_BillingEssencePointForBoard;


    public Puzzle puzzlePrefab; //預設拼圖Prefab

    [Header("關卡資訊")]
    public BattleInformation battleInformation;

    [Header("夥伴")]
    public Partner[] partners = new Partner[4]; //要戰鬥的夥伴

    [Header("對手")]
    public List<Enemy> enemies = new List<Enemy>();

    [Header("當前選擇的拼圖")]
    public PuzzleData specifyPuzzle; //選擇的備戰區拼圖
    public int specifyPuzzleNumber; //選擇的備戰區編號(第幾格)
    public bool isSpecifyPuzzle = false; //是否選擇備戰區拼圖
    [Header("隨機生成 or 從夥伴拼圖庫生成")]
    [Tooltip("(false:隨機生成 true:夥伴拼圖庫生成)")]
    public bool RandowOrForParnent = false; //隨機生成 or 從夥伴拼圖庫生成(默認隨機)


    private void Start()
    {
        Event_BattleStart?.Invoke(this, EventArgs.Empty);
        isSpecifyPuzzle = false;
    }

    /// <summary>
    /// 刷新選擇的備戰區編號的備戰區
    /// </summary>
    public void CallEvent_RemovePlacedPuzzle()
    {
        Event_RemovePlacedPuzzle?.Invoke(specifyPuzzleNumber); 

    }

    /// <summary>
    /// 發送拼圖放置完成事件
    /// </summary>
    public void CallEvent_PlacedPuzzle()
    {
        Event_PuzzlePlaceCompleted?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 發送結算事件
    /// </summary>
    public void CallEvent_SettlementBoard()
    {
        Event_SettlementBoard?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 發送回合結束事件
    /// </summary>
    public void CallEvent_EndTurn()
    {
        Event_EndTurn?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 是否可放置拼圖
    /// </summary>
    public bool CanPlacePuzzle()
    {
        if (isSpecifyPuzzle == false) //如果未指定拼圖
        {          
            MessageTextController.SetMessage("未指定拼圖");
            return false;
        }

        if (ActionPoint_Controller.ActionPoint <= 0) //如果行動值為零
        {
            MessageTextController.SetMessage("行動值不足");
            return false;
        }

        return true;
    }


}
