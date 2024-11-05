using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ˬd���ϬO�_�i�Q��m
/// </summary>
public class CheckPuzzleIsCanBePlace : MonoBehaviour
{
    public BoardController boardController;

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
        if (!CheckUp(i, j, _thisPuzzle) || !CheckDown(i, j, _thisPuzzle) ||
           !CheckRight(i, j, _thisPuzzle) || !CheckLeft(i, j, _thisPuzzle))
        {
            return false;
        }

        return true;
    }

    /*public bool CheckDirection(int i, int j, PuzzleData _puzzle, int di, int dj, PuzzleSideData thisSide, PuzzleSideData otherSide)
    {
        int newI = i + di;
        int newJ = j + dj;

        // ����ˬd
        if (newI < 0 || newI >= boardController.puzzles.GetLength(0) ||
            newJ < 0 || newJ >= boardController.puzzles.GetLength(1))
        {
            return true;
        }

        // �p�G�۾F��m�S������
        if (boardController.puzzles[newI, newJ] == null)
        {
            return true;
        }


        // �ˬd���Ϥ���
        if (thisSide.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_ &&
            otherSide.Interlocking_ != PuzzleSideData.Interlocking.indentations_�W��)
        {
            return false;
        }

        if (thisSide.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W�� &&
            otherSide.Interlocking_ != PuzzleSideData.Interlocking.protrusions_��_)
        {
            return false;
        }

        return true;
    }

    public bool CheckUp(int i, int j, PuzzleData _puzzle)
    {
        PuzzleSideData _upPuzzleDownSide = null;

        if (i! <= 0)
        {
            if (boardController.puzzles[i - 1, j] != null)
            {
                _upPuzzleDownSide = boardController.puzzles[i - 1, j].Down_; //�W����Ϫ�DownSide
            }

        }

        return CheckDirection(i, j, _puzzle, -1, 0, _puzzle.Up_, _upPuzzleDownSide);
    }

    public bool CheckDown(int i, int j, PuzzleData _puzzle)
    {
        PuzzleSideData _downPuzzleUpSide = null;

        if (i! >= 5)
        {
            if (boardController.puzzles[i + 1, j] != null)
                _downPuzzleUpSide = boardController.puzzles[i + 1, j].Up_; //�U����Ϫ�UpSide
        }


        return CheckDirection(i, j, _puzzle, 1, 0, _puzzle.Down_, _downPuzzleUpSide);
    }

    public bool CheckRight(int i, int j, PuzzleData _puzzle)
    {
        PuzzleSideData _rightPuzzleLeftSide = null;

        if (j! >= 6)
        {
            if (boardController.puzzles[i, j + 1] != null)
                _rightPuzzleLeftSide = boardController.puzzles[i, j + 1].Left_; //�k����Ϫ�LeftSide
        }


        return CheckDirection(i, j, _puzzle, 0, 1, _puzzle.Right_, _rightPuzzleLeftSide);
    }

    public bool CheckLeft(int i, int j, PuzzleData _puzzle)
    {
        PuzzleSideData _leftPuzzleRightSide = null;

        if (j! <= 0)
        {
            if (boardController.puzzles[i, j - 1] != null)
                _leftPuzzleRightSide = boardController.puzzles[i, j - 1].Right_; //������Ϫ�RightSide
        }

        return CheckDirection(i, j, _puzzle, 0, -1, _puzzle.Left_, _leftPuzzleRightSide);
    }*/


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

        if (thisPuzzle.Up_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_)
        {
            if (upPuzzle.Down_.Interlocking_ != PuzzleSideData.Interlocking.indentations_�W��)
            {
                return false;
            }
        }

        if (thisPuzzle.Up_.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��)
        {
            if (upPuzzle.Down_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_��_)
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

        if (thisPuzzle.Down_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_)
        {
            if (upPuzzle.Up_.Interlocking_ != PuzzleSideData.Interlocking.indentations_�W��)
            {
                return false;
            }
        }

        if (thisPuzzle.Down_.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��)
        {
            if (upPuzzle.Up_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_��_)
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

        if (thisPuzzle.Right_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_)
        {
            if (upPuzzle.Left_.Interlocking_ != PuzzleSideData.Interlocking.indentations_�W��)
            {
                return false;
            }
        }

        if (thisPuzzle.Right_.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��)
        {
            if (upPuzzle.Left_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_��_)
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

        if (thisPuzzle.Left_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_)
        {
            if (leftPuzzle.Right_.Interlocking_ != PuzzleSideData.Interlocking.indentations_�W��)
            {
                return false;
            }
        }

        if (thisPuzzle.Left_.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��)
        {
            if (leftPuzzle.Right_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_��_)
            {
                return false;
            }
        }

        return true;
    }



}
