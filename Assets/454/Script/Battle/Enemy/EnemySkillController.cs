using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySkillController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public BoardController boardController;

    public List<EnemySkill> enemySkillsThisTurn; //本回合的敵方技能

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (boardController == null) //獲取場景上的BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }

        battleGameController.Event_StartTurn += this.RamdomSkill; //回合開始時，從每個敵人上隨機選一個技能
        battleGameController.Event_StartTurn += this.InstantiateAllSkill;  // 回合開始時，觸發每個技能的實例化效果
        battleGameController.Event_PuzzlePlaceCompleted += this.PuzzlePlaceOver;
        battleGameController.Event_SettlementEnemySkill += this.Settlement; //回合結束時觸發結算事件
    }

    /// <summary>
    /// 回合開始時，從每個敵人上隨機選一個技能
    /// </summary>
    private void RamdomSkill(object sender, EventArgs e)
    {
        enemySkillsThisTurn.Clear(); //清空上回合的技能

        foreach (Enemy enemy in battleGameController.enemies) //每位敵人觸發一次
        {
            int r = UnityEngine.Random.Range(0, enemy.enemySkillsPrefab.Count);  //隨機挑一個技能

            if (enemy.enemySkillsPrefab[r] != null)
            {               
                enemySkillsThisTurn.Add(enemy.enemySkillsPrefab[r].GetComponent<EnemySkill>()); //程式碼1

                /*EnemySkill enemySkill = enemy.enemySkillsPrefab[r].GetComponent<EnemySkill>(); //程式碼2
                enemySkillsThisTurn.Add(enemySkill);*/
            }
            else
            {
                Debug.LogError("錯誤，有敵人Prefab上沒有技能");
            }
        }
    }

    /// <summary>
    /// 回合開始時，觸發每個技能的實例化效果
    /// </summary>
    private void InstantiateAllSkill(object sender, EventArgs e)
    {
        foreach (EnemySkill enemySkill in enemySkillsThisTurn)
        {
            enemySkill.InstantiateSkill();
        }
    }

    /// <summary>
    /// 結算所有敵方技能
    /// </summary>
    private void Settlement(object sender, EventArgs e)
    {
        foreach (EnemySkill enemySkill in enemySkillsThisTurn)
        {
            enemySkill.SettlementSkill();
        }
    }

    /// <summary>
    /// 當拼圖放置完畢時
    /// </summary>
    private void PuzzlePlaceOver(object sender, EventArgs e)
    {
        foreach (EnemyPuzzleSkill enemyPuzzleSkill in enemySkillsThisTurn)
        {
            if (enemyPuzzleSkill.isBreak == false)
            {
                enemyPuzzleSkill.CheckIsBreak();
            }
        }
    }
}
