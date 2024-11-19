using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckEnemyPuzzleAround : MonoBehaviour
{
    public BoardController boardController;

    private void Awake()
    {
        if (boardController == null) //獲取場景上的BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }

        EnemyPuzzle.Event_CheckEnemyPuzzleAround += Check;
    }

    /// <summary>
    /// 檢查四方向是否都有連接
    /// </summary>
    /// <param name="puzzleData"></param>
    /// <returns></returns>
    private bool Check(PuzzleData puzzleData)
    {
        int x; int y;
        (x, y) = puzzleData.puzzlePosition;
        Debug.Log($"檢查EnemyPuzzle{x},{y}");

        if (x != 0 && boardController.board[x - 1, y].puzzle == null)
            return false; // 如果上方不為邊界且沒有拼圖，回傳flase

        if (x != PuzzleMasterController.BoardX && boardController.board[x - 1, y].puzzle == null)
            return false; // 如果下方不為邊界且沒有拼圖，回傳flase

        if (y != 0 && boardController.board[x - 1, y].puzzle == null)
            return false; // 如果右方不為邊界且沒有拼圖，回傳flase

        if (y != PuzzleMasterController.BoardY && boardController.board[x - 1, y].puzzle == null)
            return false; // 如果左方不為邊界且沒有拼圖，回傳flase


        return true;
    }
}
