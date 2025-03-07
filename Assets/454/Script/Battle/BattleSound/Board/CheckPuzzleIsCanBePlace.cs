using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �ˬd���ϬO�_�i�Q��m
/// </summary>
public class CheckPuzzleIsCanBePlace : MonoBehaviour
{
    BoardController boardController;

    (int, int)[] directionOffset = { (-1, 0), (1, 0), (0, 1), (0, -1) }; // ���O�N��W�B�U�B�k�B�� ����V�y�Юt��
    enum Direction { Up, Down, Right, Left }

    private void Awake()
    {
        if (boardController == null) //��������W��PuzzleSpecifyController
        {
            boardController = FindObjectOfType<BoardController>();
        }

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
        if (boardController.board[i, j].Puzzle != null)  //�ˬd�Ӧ�m�O�_������
        {
            BattleMainMessage.SetMessage("���ؤw�g�����ϤF!");
            return false;
        }

        foreach (Direction direction in Enum.GetValues(typeof(Direction)))  //�NDirection�����C�ӿﶵ���M�ΥH�U�{��
        {
            if (!CheckDirection(i, j, _thisPuzzle, direction))  //�ˬd���w��V�O�_�Ĭ�
            {
                BattleMainMessage.SetMessage("�P�P����ϽĬ�A���Ϥ��i��m");
                return false;
            }
        }

        return true;
    }


    /// <param name="direction">�ˬd����V</param>
    /// <returns></returns>
    private bool CheckDirection(int i, int j, PuzzleData thisPuzzle, Direction direction)
    {
        (int di, int dj) = directionOffset[(int)direction]; //�̷Ӥ�Vdirection���C�|�ȡA���o�y�Юt�Ȱ}�C
        int newI = i + di, newJ = j + dj;

        // �ˬd���
        if (newI < 0 || newI >= boardController.board.GetLength(0) ||
            newJ < 0 || newJ >= boardController.board.GetLength(1))
            return true;

        // �ˬd�O�_�s�b����
        PuzzleData adjacentPuzzle = boardController.board[newI, newJ].Puzzle;
        if (adjacentPuzzle == null)
            return true;

        // �ھڤ�V�ˬd�����䪺�s��
        switch (direction)
        {
            case Direction.Up:
                return CheckSide(thisPuzzle.UpSide_, adjacentPuzzle.DownSide_);
            case Direction.Down:
                return CheckSide(thisPuzzle.DownSide_, adjacentPuzzle.UpSide_);
            case Direction.Right:
                return CheckSide(thisPuzzle.RightSide_, adjacentPuzzle.LeftSide_);
            case Direction.Left:
                return CheckSide(thisPuzzle.LeftSide_, adjacentPuzzle.RightSide_);
            default:
                return false;
        }
    }

    /// <summary>
    /// ������w��P�۾F����O�_�i�H���o�_��
    /// </summary>
    /// <param name="��m���ϭn�����������"></param>
    /// <param name="�P�e�̬۾F����"></param>
    /// <returns></returns>
    private bool CheckSide(PuzzleSideData thisPuzzleSide, PuzzleSideData adjacentPuzzleSide)
    {
        if (thisPuzzleSide.Interlocking_ == PuzzleSideData.Interlocking.protrusions_��_) //�YthisPuzzle����_�A�h�ﱵ�B�������W��
        {
            if (adjacentPuzzleSide.Interlocking_ != PuzzleSideData.Interlocking.indentations_�W��) //�Y�ﱵ�B���O�W���A�^��flase
            {
                return false;
            }

            if (adjacentPuzzleSide.Essence_ != EssenceEnum.Essence.None_�L�ݩ�) //�Y�ﱵ�B���W�ѱa���ݩ�
            {
                //�Y������Y�_�P�ﱵ���W���ݩʬۦP�A�^��true�A�Ϥ��^��false
                return adjacentPuzzleSide.Essence_ == thisPuzzleSide.Essence_;
            }
            else
            {
                return true;
            }
        }
        else if (thisPuzzleSide.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��)//�YthisPuzzle���W��
        {
            if (adjacentPuzzleSide.Interlocking_ != PuzzleSideData.Interlocking.protrusions_��_) //�Y�ﱵ�B���O�Y�_�A�^��flase
            {
                return false;
            }

            if (thisPuzzleSide.Essence_ != EssenceEnum.Essence.None_�L�ݩ�) //�YthisPuzzle���W�ѱa���ݩ�
            {
                //�Y������Y�_�P�ﱵ���W���ݩʬۦP�A�^��true�A�Ϥ��^��false
                return adjacentPuzzleSide.Essence_ == thisPuzzleSide.Essence_;
            }
            else
            {
                return true;
            }
        }
        else
        {
            Debug.LogError("CheckSide�X�{�ҥ~");
        }

        Debug.LogError("CheckSide�X�{�ҥ~");
        return false;
    }
}
