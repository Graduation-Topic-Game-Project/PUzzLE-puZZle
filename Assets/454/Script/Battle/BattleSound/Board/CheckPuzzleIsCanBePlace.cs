using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 檢查拼圖是否可被放置
/// </summary>
public class CheckPuzzleIsCanBePlace : MonoBehaviour
{
    BoardController boardController;

    (int, int)[] directionOffset = { (-1, 0), (1, 0), (0, 1), (0, -1) }; // 分別代表上、下、右、左 的方向座標差值
    enum Direction { Up, Down, Right, Left }

    private void Awake()
    {
        if (boardController == null) //獲取場景上的PuzzleSpecifyController
        {
            boardController = FindObjectOfType<BoardController>();
        }

        boardController.Event_CheckPuzzleIsCanBePlace += this.Check;
    }

    /// <summary>
    /// 檢查放置拼圖是否可以跟周圍拼圖拼起來
    /// </summary>
    /// <param name="i">放置位置座標X</param>
    /// <param name="j">放置位置座標Y</param>
    /// <param name="_thisPuzzle">放置的拼圖</param>
    /// <returns></returns>
    public bool Check(int i, int j, PuzzleData _thisPuzzle)
    {
        if (boardController.board[i, j].Puzzle != null)  //檢查該位置是否有拼圖
        {
            BattleMainMessage.SetMessage("那裏已經有拼圖了!");
            return false;
        }

        foreach (Direction direction in Enum.GetValues(typeof(Direction)))  //將Direction內的每個選項都套用以下程式
        {
            if (!CheckDirection(i, j, _thisPuzzle, direction))  //檢查指定方向是否衝突
            {
                BattleMainMessage.SetMessage("與周圍拼圖衝突，拼圖不可放置");
                return false;
            }
        }

        return true;
    }


    /// <param name="direction">檢查的方向</param>
    /// <returns></returns>
    private bool CheckDirection(int i, int j, PuzzleData thisPuzzle, Direction direction)
    {
        (int di, int dj) = directionOffset[(int)direction]; //依照方向direction的列舉值，取得座標差值陣列
        int newI = i + di, newJ = j + dj;

        // 檢查邊界
        if (newI < 0 || newI >= boardController.board.GetLength(0) ||
            newJ < 0 || newJ >= boardController.board.GetLength(1))
            return true;

        // 檢查是否存在拼圖
        PuzzleData adjacentPuzzle = boardController.board[newI, newJ].Puzzle;
        if (adjacentPuzzle == null)
            return true;

        // 根據方向檢查拼圖邊的連接
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
    /// 比較指定邊與相鄰的邊是否可以拼得起來
    /// </summary>
    /// <param name="放置拼圖要比較的那個邊"></param>
    /// <param name="與前者相鄰的邊"></param>
    /// <returns></returns>
    private bool CheckSide(PuzzleSideData thisPuzzleSide, PuzzleSideData adjacentPuzzleSide)
    {
        if (thisPuzzleSide.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起) //若thisPuzzle為突起，則對接處必須為凹陷
        {
            if (adjacentPuzzleSide.Interlocking_ != PuzzleSideData.Interlocking.indentations_凹陷) //若對接處不是凹陷，回傳flase
            {
                return false;
            }

            if (adjacentPuzzleSide.Essence_ != EssenceEnum.Essence.None_無屬性) //若對接處的凹槽帶有屬性
            {
                //若比較的凸起與對接的凹槽屬性相同，回傳true，反之回傳false
                return adjacentPuzzleSide.Essence_ == thisPuzzleSide.Essence_;
            }
            else
            {
                return true;
            }
        }
        else if (thisPuzzleSide.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷)//若thisPuzzle為凹陷
        {
            if (adjacentPuzzleSide.Interlocking_ != PuzzleSideData.Interlocking.protrusions_突起) //若對接處不是凸起，回傳flase
            {
                return false;
            }

            if (thisPuzzleSide.Essence_ != EssenceEnum.Essence.None_無屬性) //若thisPuzzle的凹槽帶有屬性
            {
                //若比較的凸起與對接的凹槽屬性相同，回傳true，反之回傳false
                return adjacentPuzzleSide.Essence_ == thisPuzzleSide.Essence_;
            }
            else
            {
                return true;
            }
        }
        else
        {
            Debug.LogError("CheckSide出現例外");
        }

        Debug.LogError("CheckSide出現例外");
        return false;
    }
}
