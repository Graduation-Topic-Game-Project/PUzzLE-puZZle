using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class BattleGameController : MonoBehaviour
{
    /// <summary>戰鬥開始(整場戰鬥觸發一次)</summary>
    public event EventHandler Event_BattleStart;
    /// <summary>回合開始</summary>
    public event EventHandler Event_StartTurn; //回合開始
    /// <summary>選擇備戰區拼圖 [true = 選擇 false = 取消選擇]</summary>
    public event Action<bool> Event_SpecifyPuzzle; //選擇拼圖
    /// <summary>拼圖放置完成</summary>
    public event EventHandler Event_PuzzlePlaceCompleted; //拼圖放置完成
    /// <summary>結算盤面</summary>
    public event EventHandler Event_SettlementBoard; //結算盤面
    /// <summary>結算敵人技能</summary>
    public event EventHandler Event_SettlementEnemySkill; //結算敵人技能
    /// <summary>衝突階段</summary>
    public event Func<Coroutine> Event_Confrontation; //衝突階段
    /// <summary>判定:是否全部敵方皆死亡</summary>
    public event Action Event_IsAllEnemyDead; //判定:是否全部敵方皆死亡
    /// <summary>勝利</summary>
    public event Action Event_Win; //勝利
    /// <summary>結束回合</summary>
    public event EventHandler Event_EndTurn; //結束回合

    [Header("關卡資訊")]
    public BattleInformation battleInformation;

    [Header("夥伴")]
    public Partner[] partners = new Partner[4]; //要戰鬥的夥伴

    [Header("對手")]
    public List<Enemy> enemies = new List<Enemy>();
    //只有開始遊戲生成敵人和施放技能時會用，傷害計算等在BattleGameController的InstancedEnemy

    public List<Enemy> InstancedEnemy; //實例化的敵人

    [Header("是否勝利"), Tooltip("true = win")]
    public bool IsWin;

    private void Start()
    {
        Event_BattleStart?.Invoke(this, EventArgs.Empty);
        CallEvent_StartTurn(); //回合開始事件
    }

    /// <summary>
    /// 發送回合開始事件
    /// </summary>
    public void CallEvent_StartTurn()
    {
        Event_StartTurn?.Invoke(this, EventArgs.Empty);
        //Debug.Log("新的回合開始");
    }

    /// <summary>
    /// 發送選擇拼圖事件{true = 選擇 false = 取消選擇}
    /// </summary>
    public void CallEvent_SpecifyPuzzle(bool Specify_Or_NoSpecify)
    {
        Event_SpecifyPuzzle?.Invoke(Specify_Or_NoSpecify);
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
    /// 發送衝突事件
    /// </summary>
    public void CallEvent_Confrontation()
    {
        Event_Confrontation?.Invoke();

        /*Debug.LogWarning("錯誤，衝突協程未回傳協程");
        return null;*/
    }

    /// <summary>
    /// 發送是否全部敵方皆死亡判定事件
    /// </summary>
    public void CallEvent_IsAllEnemyDead()
    {
        Event_IsAllEnemyDead?.Invoke();
        // Debug.Log("CallEvent_IsWin()");
    }

    /// <summary>
    /// 發送回合結束事件
    /// </summary>
    public void CallEvent_EndTurn()
    {
        Event_EndTurn?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 發送勝利事件
    /// </summary>
    public void CallEvent_Win()
    {
        Event_Win?.Invoke();
        Debug.Log("CallEvent_Win()");
    }


}
