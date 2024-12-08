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
    protected virtual int _minX { get; } = 0;
    protected virtual int _maxX { get; } = 5;
    protected virtual int _minY { get; } = 0;
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
            PlayerBattleData.Damage(damage);
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
    }

    /// <summary>
    /// 實例化技能
    /// </summary>
    public override void InstantiateSkill()
    {
        if (boardController == null) //獲取場景上的BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }

        int x = UnityEngine.Random.Range(_minX, _maxX);
        int y = UnityEngine.Random.Range(_minY, _maxY);


        if (boardController.board[x, y].Puzzle == null)
        {
            boardController.board[x, y].Puzzle = enemyPuzzle.puzzleData; //更新PuzzleData內的拼圖座標
            boardController.board[x, y].Puzzle.puzzlePosition = (x, y);
        }
        else
            Debug.Log("錯誤，該地方已有拼圖，無法放置敵方拼圖技能");

        boardController.UpdatePuzzleBoard();
    }

    public void CheckIsBreak() //檢查是否被破壞
    {
        if (isBreak == false)
        {
            if (CheckEnemyPuzzleAround.Check(enemyPuzzle.puzzleData))
            {
                isBreak = true;
                MessageTextController.SetMessage("敵方拼圖已被破壞");
                Debug.Log("敵方拼圖已被破壞");
            }
        }
    }
}
