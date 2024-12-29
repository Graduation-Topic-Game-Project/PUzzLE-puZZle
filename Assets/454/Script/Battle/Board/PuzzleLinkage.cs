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
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        if (boardController == null) //獲取場景上的BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }

        boardController.Event_CheckPuzzleLinkage += CheckPuzzleLinkageCombo;
        battleGameController.Event_PuzzlePlaceCompleted += CheckPuzzleLinagek;
    }

    /// <summary>
    /// 檢查盤面上的拼圖是否連鎖
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
    /// 檢查拼圖是否連鎖，若有連鎖則開啟該拼圖邊的Link
    /// </summary>
    public void IsPuzzleLinkage(PuzzleData nowPuzzle)
    {
        int i = nowPuzzle.puzzlePosition.Item1;
        int j = nowPuzzle.puzzlePosition.Item2;

        if (i != 0) //檢查上方
        {
            if (boardController.board[i - 1, j].Puzzle != null)
                nowPuzzle.UpSide_.Linkage = true;
        }

        if (i != PuzzleMasterController.BoardX - 1) //檢查下方
        {
            if (boardController.board[i + 1, j].Puzzle != null)
                nowPuzzle.DownSide_.Linkage = true;
        }

        if (j != PuzzleMasterController.BoardY - 1) //檢查右方
        {
            if (boardController.board[i, j + 1].Puzzle != null)
                nowPuzzle.RightSide_.Linkage = true;
        }

        if (j != 0) //檢查左方
        {
            if (boardController.board[i, j - 1].Puzzle != null)
                nowPuzzle.LeftSide_.Linkage = true;
        }

    }


    public void CheckPuzzleLinkageCombo(int i, int j)
    {
        int LinkNum = 0;

        PuzzleData nowPuzzle = boardController.board[i, j].Puzzle;

        if (i != 0) //檢查上方
        {
            if (boardController.board[i - 1, j].Puzzle != null)
            {
                LinkNum++;
            }
        }

        if (i != PuzzleMasterController.BoardX - 1) //檢查下方
        {
            if (boardController.board[i + 1, j].Puzzle != null)
            {
                LinkNum++;
            }

        }

        if (j != PuzzleMasterController.BoardY - 1) //檢查右方
        {
            if (boardController.board[i, j + 1].Puzzle != null)
            {
                LinkNum++;
            }
        }

        if (j != 0) //檢查左方
        {
            if (boardController.board[i, j - 1].Puzzle != null)
            {
                LinkNum++;
            }
        }

        LinkBouns(LinkNum);
    }

    /// <summary>
    /// 放置拼圖時檢查多重連鎖，依照連結邊數量獲得獎勵
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
                PuzzleLinkMessage.SetMessage("2重連鎖，不消耗行動值");
                break;
            case 3:
                ActionPoint_Controller.ActionPoint = ActionPoint_Controller.ActionPoint + 2;
                PuzzleLinkMessage.SetMessage("3重連鎖，行動值+1");
                break;
            case 4:
                ActionPoint_Controller.ActionPoint = ActionPoint_Controller.ActionPoint + 4;
                PuzzleLinkMessage.SetMessage("3重連鎖，行動值+3");
                break;
        }
    }
}
