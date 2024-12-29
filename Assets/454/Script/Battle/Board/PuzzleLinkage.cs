using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleLinkage : MonoBehaviour
{
    public BattleGameController battleGameController;
    public BoardController boardController;

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        if (boardController == null) //��������W��BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }

        boardController.Event_CheckPuzzleLinkage += CheckPuzzleLinkageCombo;
        battleGameController.Event_PuzzlePlaceCompleted += CheckPuzzleLinagek;
    }

    /// <summary>
    /// �ˬd�L���W�����ϬO�_�s��
    /// </summary>
    public void CheckPuzzleLinagek(object sender, EventArgs e)
    {
        foreach (Board nowBoard in boardController.board)
        {
            PuzzleData nowPuzzle = nowBoard.Puzzle;

            if (nowPuzzle != null)
            {
                int i = nowPuzzle.puzzlePosition.Item1;
                int j = nowPuzzle.puzzlePosition.Item2;
                IsPuzzleLinkage(nowPuzzle);
            }
        }
    }

    /// <summary>
    /// �ˬd���ϬO�_�s��A�Y���s��h�}�Ҹӫ����䪺Link
    /// </summary>
    public void IsPuzzleLinkage(PuzzleData nowPuzzle)
    {
        int i = nowPuzzle.puzzlePosition.Item1;
        int j = nowPuzzle.puzzlePosition.Item2;

        if (i != 0) //�ˬd�W��
        {
            if (boardController.board[i - 1, j].Puzzle != null)
                nowPuzzle.UpSide_.Linkage = true;
        }

        if (i != PuzzleMasterController.BoardX - 1) //�ˬd�U��
        {
            if (boardController.board[i + 1, j].Puzzle != null)
                nowPuzzle.DownSide_.Linkage = true;
        }

        if (j != PuzzleMasterController.BoardY - 1) //�ˬd�k��
        {
            if (boardController.board[i, j + 1].Puzzle != null)
                nowPuzzle.RightSide_.Linkage = true;
        }

        if (j != 0) //�ˬd����
        {
            if (boardController.board[i, j - 1].Puzzle != null)
                nowPuzzle.LeftSide_.Linkage = true;
        }

    }


    public void CheckPuzzleLinkageCombo(int i, int j)
    {
        int LinkNum = 0;

        PuzzleData nowPuzzle = boardController.board[i, j].Puzzle;

        if (i != 0) //�ˬd�W��
        {
            if (boardController.board[i - 1, j].Puzzle != null)
            {
                LinkNum++;
            }
        }

        if (i != PuzzleMasterController.BoardX - 1) //�ˬd�U��
        {
            if (boardController.board[i + 1, j].Puzzle != null)
            {
                LinkNum++;
            }

        }

        if (j != PuzzleMasterController.BoardY - 1) //�ˬd�k��
        {
            if (boardController.board[i, j + 1].Puzzle != null)
            {
                LinkNum++;
            }
        }

        if (j != 0) //�ˬd����
        {
            if (boardController.board[i, j - 1].Puzzle != null)
            {
                LinkNum++;
            }
        }

        LinkBouns(LinkNum);
    }

    /// <summary>
    /// ��m���Ϯ��ˬd�h���s��A�̷ӳs����ƶq��o���y
    /// </summary>
    /// <param name="linkNum"></param>
    public void LinkBouns(int linkNum)
    {
        switch (linkNum)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                ActionPoint_Controller.ActionPoint = ActionPoint_Controller.ActionPoint + 1;
                PuzzleLinkMessage.SetMessage("2���s��A�����Ӧ�ʭ�");
                break;
            case 3:
                ActionPoint_Controller.ActionPoint = ActionPoint_Controller.ActionPoint + 2;
                PuzzleLinkMessage.SetMessage("3���s��A��ʭ�+1");
                break;
            case 4:
                ActionPoint_Controller.ActionPoint = ActionPoint_Controller.ActionPoint + 4;
                PuzzleLinkMessage.SetMessage("3���s��A��ʭ�+3");
                break;
        }
    }
}
