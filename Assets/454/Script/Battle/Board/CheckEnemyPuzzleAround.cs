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

    private bool Check(PuzzleData puzzleData)
    {
        int x; int y;
        (x, y) = puzzleData.puzzlePosition;
        Debug.Log($"檢查EnemyPuzzle{x},{y}");

        if (boardController.puzzles[x - 1, y] == null || boardController.puzzles[x + 1, y] == null ||
            boardController.puzzles[x, y + 1] == null || boardController.puzzles[x, y - 1] == null)
        {
            return false; //如果上下右左其中一方向為空的，回傳flase
        }
    
        return true;
    }
}
