using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �ˬd���ϬO�_�i�Q��m
/// </summary>
public class CheckPuzzleIsCanBePlace : MonoBehaviour
{
    public BoardController boardController;

    (int, int)[] directionOffset = { (-1, 0), (1, 0), (0, 1), (0, -1) }; // ���O�N��W�B�U�B�k�B�� ����V�y�Юt��
    enum Direction { Up, Down, Right, Left }

    private void Awake()
    {
        boardController.Event_CheckPuzzleIsCanBePlace += this.Check;
    }

    /// <summary>
    /// �ˬd��m���ϬO�_�i�H��P����ϫ��_��
    /// </summary>
    /// <param name="i">��m��m�y��X</param>
    /// <param name="j">��m��m�y��Y</param>
    /// <param name="_thisPuzzle">��m������</param>
    /// <returns></returns>
    public bool Check(int i, int j, PuzzleData _thisPuzzle)
    {
        if (!CheckDirection(i, j, _thisPuzzle, Direction.Up))
            return false;
        if (!CheckDirection(i, j, _thisPuzzle, Direction.Down))
            return false;
        if (!CheckDirection(i, j, _thisPuzzle, Direction.Right))
            return false;
        if (!CheckDirection(i, j, _thisPuzzle, Direction.Left))
            return false;

        return true;
    }


    /// <param name="direction">�ˬd����V</param>
    /// <returns></returns>
    private bool CheckDirection(int i, int j, PuzzleData thisPuzzle, Direction direction)
    {
        (int di, int dj) = directionOffset[(int)direction]; //�̷Ӥ�Vdirection���C�|�ȡA���o�y�Юt�Ȱ}�C
        int newI = i + di, newJ = j + dj;

        // �ˬd���
        if (newI < 0 || newI >= boardController.puzzles.GetLength(0) ||
            newJ < 0 || newJ >= boardController.puzzles.GetLength(1))
            return true;

        // �ˬd�O�_�s�b����
        PuzzleData adjacentPuzzle = boardController.puzzles[newI, newJ];
        if (adjacentPuzzle == null)
            return true;

        // �ھڤ�V�ˬd�����䪺�s��
        switch (direction)
        {
            case Direction.Up:
                return thisPuzzle.UpSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_
                    ? adjacentPuzzle.DownSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��
                    : adjacentPuzzle.DownSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_;

            case Direction.Down:
                return thisPuzzle.DownSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_
                    ? adjacentPuzzle.UpSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��
                    : adjacentPuzzle.UpSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_;

            case Direction.Right:
                return thisPuzzle.RightSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_
                    ? adjacentPuzzle.LeftSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��
                    : adjacentPuzzle.LeftSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_;

            case Direction.Left:
                return thisPuzzle.LeftSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_
                    ? adjacentPuzzle.RightSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��
                    : adjacentPuzzle.RightSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_;

            default:
                return false;
        }
    }








    /// <summary>
    /// �ˬd��m���ϬO�_�i�H��P����ϫ��_��
    /// </summary>
    /// <param name="i">��m��m�y��X</param>
    /// <param name="j">��m��m�y��Y</param>
    /// <param name="_thisPuzzle">��m������</param>
    /// <returns></returns>
    /*public bool Check(int i, int j, PuzzleData _thisPuzzle)
    {
        if (!CheckUp(i, j, _thisPuzzle) || !CheckDown(i, j, _thisPuzzle) ||
           !CheckRight(i, j, _thisPuzzle) || !CheckLeft(i, j, _thisPuzzle))
        {
            return false;
        }

        return true;
    }

    
    public bool CheckUp(int i, int j, PuzzleData _puzzle)
    {
        PuzzleData thisPuzzle = _puzzle;
        PuzzleData upPuzzle = null;

        if (i == 0)
        {
            //Debug.Log("�W�謰���");
            return true;
        }

        if (boardController.puzzles[i - 1, j] == null) //�p�G�W��S������
        {
            //Debug.Log("�W�謰��");
            return true;
        }
        else
        {
            upPuzzle = boardController.puzzles[i - 1, j];
        }

        if (thisPuzzle.UpSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_)
        {
            if (upPuzzle.DownSide_.Interlocking_ != PuzzleSideData.Interlocking.indentations_�W��)
            {
                return false;
            }
        }

        if (thisPuzzle.UpSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��)
        {
            if (upPuzzle.DownSide_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_��_)
            {
                return false;
            }
        }

        return true;
    }

    public bool CheckDown(int i, int j, PuzzleData _puzzle)
    {
        PuzzleData thisPuzzle = _puzzle;
        PuzzleData upPuzzle = null;

        if (i == 5)
        {
            //Debug.Log("�U�謰���");
            return true;
        }

        if (boardController.puzzles[i + 1, j] == null) //�p�G�U��S������
        {
            //Debug.Log("�U�謰��");
            return true;
        }
        else
        {
            upPuzzle = boardController.puzzles[i + 1, j];
        }

        if (thisPuzzle.DownSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_)
        {
            if (upPuzzle.UpSide_.Interlocking_ != PuzzleSideData.Interlocking.indentations_�W��)
            {
                return false;
            }
        }

        if (thisPuzzle.DownSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��)
        {
            if (upPuzzle.UpSide_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_��_)
            {
                return false;
            }
        }

        return true;
    }
    public bool CheckRight(int i, int j, PuzzleData _puzzle)
    {
        PuzzleData thisPuzzle = _puzzle;
        PuzzleData upPuzzle = null;

        if (j == 6)
        {
            //Debug.Log("�k�謰���");
            return true;
        }

        if (boardController.puzzles[i, j + 1] == null) //�p�G�k��S������
        {
            //Debug.Log("�k�謰��");
            return true;
        }
        else
        {
            upPuzzle = boardController.puzzles[i, j + 1];
        }

        if (thisPuzzle.RightSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_)
        {
            if (upPuzzle.LeftSide_.Interlocking_ != PuzzleSideData.Interlocking.indentations_�W��)
            {
                return false;
            }
        }

        if (thisPuzzle.RightSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��)
        {
            if (upPuzzle.LeftSide_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_��_)
            {
                return false;
            }
        }

        return true;
    }
    public bool CheckLeft(int i, int j, PuzzleData _puzzle)
    {
        PuzzleData thisPuzzle = _puzzle;
        PuzzleData leftPuzzle = null;

        if (j == 0)
        {
            //Debug.Log("���謰���");
            return true;
        }

        if (boardController.puzzles[i, j - 1] == null) //�p�G����S������
        {
            //Debug.Log("���謰��");
            return true;
        }
        else
        {
            leftPuzzle = boardController.puzzles[i, j - 1];
        }

        if (thisPuzzle.LeftSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_)
        {
            if (leftPuzzle.RightSide_.Interlocking_ != PuzzleSideData.Interlocking.indentations_�W��)
            {
                return false;
            }
        }

        if (thisPuzzle.LeftSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��)
        {
            if (leftPuzzle.RightSide_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_��_)
            {
                return false;
            }
        }

        return true;
    }*/




}
