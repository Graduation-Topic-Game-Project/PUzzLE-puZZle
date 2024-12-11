using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLinkage : MonoBehaviour
{
    BoardController boardController;

    private void Awake()
    {
        if (boardController == null) //��������W��BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }

        boardController.Event_CheckPuzzleLinkage += CheckPuzzleLinkage;
    }

    /*public void CheckPuzzleLinkage(int i, int j)
    {
        Debug.Log("CheckPuzzleLinkage");
    }*/


    public void CheckPuzzleLinkage(int i, int j)
    {
        int LinkNum = 0;

        PuzzleData nowPuzzle = boardController.board[i, j].Puzzle;

        if (i != 0) //�ˬd�W��
        {
            if (boardController.board[i - 1, j].Puzzle != null)
                LinkNum++;
        }

        if (i != PuzzleMasterController.BoardX - 1) //�ˬd�U��
        {
            if (boardController.board[i + 1, j].Puzzle != null)
                LinkNum++;
        }

        if (j != PuzzleMasterController.BoardY - 1) //�ˬd�k��
        {
            if (boardController.board[i, j + 1].Puzzle != null)
                LinkNum++;
        }

        if (j != 0) //�ˬd����
        {
            if (boardController.board[i, j - 1].Puzzle != null)
                LinkNum++;
        }

        LinkBouns(LinkNum);
    }

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
                MessageTextController.SetLinkageMessage("2���s��A��ʭ�+1");
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
}
