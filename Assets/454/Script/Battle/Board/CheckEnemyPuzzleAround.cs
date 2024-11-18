using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckEnemyPuzzleAround : MonoBehaviour
{
    public BoardController boardController;

    private void Awake()
    {
        if (boardController == null) //��������W��BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }

        EnemyPuzzle.Event_CheckEnemyPuzzleAround += Check;
    }

    private bool Check(PuzzleData puzzleData)
    {
        int x; int y;
        (x, y) = puzzleData.puzzlePosition;
        Debug.Log($"�ˬdEnemyPuzzle{x},{y}");

        if (boardController.puzzles[x - 1, y] == null || boardController.puzzles[x + 1, y] == null ||
            boardController.puzzles[x, y + 1] == null || boardController.puzzles[x, y - 1] == null)
        {
            return false; //�p�G�W�U�k���䤤�@��V���Ū��A�^��flase
        }
    
        return true;
    }
}
