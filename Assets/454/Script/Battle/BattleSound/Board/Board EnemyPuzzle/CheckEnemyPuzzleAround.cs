using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckEnemyPuzzleAround : MonoBehaviour
{
    BoardController boardController;
    private static CheckEnemyPuzzleAround checkEnemyPuzzleAround;

    //private static event Func<PuzzleData, bool> Event_CheckEnemyPuzzleAround; //檢查敵方拼圖是否包圍

    private void Awake()
    {
        if (boardController == null) //獲取場景上的BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }

        if (checkEnemyPuzzleAround == null)
        {
            checkEnemyPuzzleAround = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        //Event_CheckEnemyPuzzleAround += IsAround; //檢查四方向是否都有連接
    }

    public static bool Check(PuzzleData puzzle)
    {
        //if (Event_CheckEnemyPuzzleAround?.Invoke(puzzle) == true)
        if (checkEnemyPuzzleAround.IsAround(puzzle) == true)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 檢查四方向是否都有連接
    /// </summary>
    /// <param name="puzzleData"></param>
    /// <returns></returns>
    private bool IsAround(PuzzleData puzzleData)
    {
        int x; int y;
        (x, y) = puzzleData.puzzlePosition;
        //Debug.Log($"檢查EnemyPuzzle{x},{y}");

        if (x != 0 && boardController.board[x - 1, y].Puzzle == null)
            return false; // 如果上方不為邊界且沒有拼圖，回傳flase

        if (x != PuzzleMasterController.BoardX - 1 && boardController.board[x + 1, y].Puzzle == null)
            return false; // 如果下方不為邊界且沒有拼圖，回傳flase

        if (y != PuzzleMasterController.BoardY - 1 && boardController.board[x, y + 1].Puzzle == null)
            return false; // 如果右方不為邊界且沒有拼圖，回傳flase

        if (y != 0 && boardController.board[x, y - 1].Puzzle == null)
            return false; // 如果左方不為邊界且沒有拼圖，回傳flase

        return true;
    }


}
