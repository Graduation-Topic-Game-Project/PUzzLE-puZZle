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

    /// <summary>
    /// �ˬd�|��V�O�_�����s��
    /// </summary>
    /// <param name="puzzleData"></param>
    /// <returns></returns>
    private bool Check(PuzzleData puzzleData)
    {
        int x; int y;
        (x, y) = puzzleData.puzzlePosition;
        Debug.Log($"�ˬdEnemyPuzzle{x},{y}");

        if (x != 0 && boardController.board[x - 1, y].puzzle == null)
            return false; // �p�G�W�褣����ɥB�S�����ϡA�^��flase

        if (x != PuzzleMasterController.BoardX && boardController.board[x - 1, y].puzzle == null)
            return false; // �p�G�U�褣����ɥB�S�����ϡA�^��flase

        if (y != 0 && boardController.board[x - 1, y].puzzle == null)
            return false; // �p�G�k�褣����ɥB�S�����ϡA�^��flase

        if (y != PuzzleMasterController.BoardY && boardController.board[x - 1, y].puzzle == null)
            return false; // �p�G���褣����ɥB�S�����ϡA�^��flase


        return true;
    }
}
