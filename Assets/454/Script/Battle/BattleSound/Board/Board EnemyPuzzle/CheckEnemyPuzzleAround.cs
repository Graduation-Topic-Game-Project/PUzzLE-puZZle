using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckEnemyPuzzleAround : MonoBehaviour
{
    BoardController boardController;
    private static CheckEnemyPuzzleAround checkEnemyPuzzleAround;

    //private static event Func<PuzzleData, bool> Event_CheckEnemyPuzzleAround; //�ˬd�Ĥ���ϬO�_�]��

    private void Awake()
    {
        if (boardController == null) //��������W��BoardController
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

        //Event_CheckEnemyPuzzleAround += IsAround; //�ˬd�|��V�O�_�����s��
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
    /// �ˬd�|��V�O�_�����s��
    /// </summary>
    /// <param name="puzzleData"></param>
    /// <returns></returns>
    private bool IsAround(PuzzleData puzzleData)
    {
        int x; int y;
        (x, y) = puzzleData.puzzlePosition;
        //Debug.Log($"�ˬdEnemyPuzzle{x},{y}");

        if (x != 0 && boardController.board[x - 1, y].Puzzle == null)
            return false; // �p�G�W�褣����ɥB�S�����ϡA�^��flase

        if (x != PuzzleMasterController.BoardX - 1 && boardController.board[x + 1, y].Puzzle == null)
            return false; // �p�G�U�褣����ɥB�S�����ϡA�^��flase

        if (y != PuzzleMasterController.BoardY - 1 && boardController.board[x, y + 1].Puzzle == null)
            return false; // �p�G�k�褣����ɥB�S�����ϡA�^��flase

        if (y != 0 && boardController.board[x, y - 1].Puzzle == null)
            return false; // �p�G���褣����ɥB�S�����ϡA�^��flase

        return true;
    }


}
