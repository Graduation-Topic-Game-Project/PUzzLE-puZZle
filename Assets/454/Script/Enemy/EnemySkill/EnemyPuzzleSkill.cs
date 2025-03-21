using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyPuzzleSkill : EnemySkill
{
    BoardController boardController;

    protected override int damage { get; } = 10;

    public EnemyPuzzle enemyPuzzle;
    public bool isBreak;

    /// <summary>敵方拼圖生成的最上橫行(0~5) </summary>
    protected virtual int _minX { get; } = 0;
    /// <summary>敵方拼圖生成的最下橫行(0~5) </summary>
    protected virtual int _maxX { get; } = 5;
    /// <summary>敵方拼圖生成的最左直列(0~6) </summary>
    protected virtual int _minY { get; } = 0;
    /// <summary>敵方拼圖生成的最右直列(0~6) </summary>
    protected virtual int _maxY { get; } = 6;


    protected void Awake()
    {
        if (boardController == null) //獲取場景上的BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }
        //base.Awake();
        if (enemyPuzzle == null)
            enemyPuzzle = this.gameObject.transform.GetComponent<EnemyPuzzle>();

        isBreak = false;
    }

    /// <summary>
    /// 此處寫結算事件
    /// </summary>
    public override void SettlementSkill()
    {
        if (isBreak == false)
        {
            Debug.Log("未被破壞，對我方隊伍造成傷害");
            BattleConfrontationController.AddEnemyAttack(damage);
            //PlayerBattleData.Instance.Damage(damage);
        }
        else
        {
            Debug.Log("已被破壞，未造成傷害");
        }
    }

    /// <summary>
    /// 初始化技能
    /// </summary>
    public override void InitializeSkill()
    {
        isBreak = false;
        enemyPuzzle.BreakImage_OpenOrClose(false);
    }

    /// <summary>
    /// 實例化技能(將批圖資料存進BoardBoard)
    /// </summary>
    public override void InstantiateSkill()
    {
        if (boardController == null) //獲取場景上的BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }

        TryInstantiateSkill();
        boardController.UpdatePuzzleBoard();
    }

    private void TryInstantiateSkill(int attempt = 0)
    {
        if (attempt > 100)
        {
            Debug.LogWarning("已達最大嘗試次數，無法生成拼圖!");
            return;
        }

        int x = UnityEngine.Random.Range(_minX, _maxX + 1);
        int y = UnityEngine.Random.Range(_minY, _maxY + 1);

        if (boardController.board[x, y].Puzzle == null && boardController.board[x, y].EnemySkill == null)
        {
            boardController.board[x, y].Puzzle = enemyPuzzle.puzzleData;
            boardController.board[x, y].Puzzle.puzzlePosition = (x, y);
            boardController.board[x, y].EnemySkill = this.gameObject;
        }
        else
        {
            Debug.Log($"該地方已有拼圖，第{attempt + 1}次重新選擇位置...");
            TryInstantiateSkill(attempt + 1); // 增加嘗試次數
        }
    }

    public void CheckIsBreak() //檢查是否被破壞
    {
        if (isBreak == false)
        {
            if (CheckEnemyPuzzleAround.Check(enemyPuzzle.puzzleData))
            {
                isBreak = true;
                BattleMainMessage.SetMessage("敵方拼圖已被破壞");
                Debug.Log("敵方拼圖已被破壞");

                /*(int x, int y) = enemyPuzzle.puzzleData.puzzlePosition;
                 boardController.board[x, y].Puzzle = enemyPuzzle.puzzleData;

                 Debug.Log(boardController.board[x, y].Puzzle);
                 Debug.Log($"test 更新敵方拼圖{x},{y}的board 資料");*/
                boardController.UpdatePuzzleBoard();
            }
        }
    }

    public void OpenEenemyPuzzleBreakImage()
    {
        enemyPuzzle.BreakImage_OpenOrClose(true);
    }
}
