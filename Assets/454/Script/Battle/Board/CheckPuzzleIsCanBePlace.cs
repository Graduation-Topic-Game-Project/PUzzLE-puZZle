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
            MessageTextController.SetMessage("那裏已經有拼圖了!");
            return false;
        }

        foreach (Direction direction in Enum.GetValues(typeof(Direction)))  //將Direction內的每個選項都套用以下程式
        {
            if (!CheckDirection(i, j, _thisPuzzle, direction))  //檢查指定方向是否衝突
            {
                MessageTextController.SetMessage("與周圍拼圖衝突，拼圖不可放置");
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
                ///               return thisPuzzle.UpSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起       //檢查上邊，若為突起執行第二行，反之執行第三行
                ///                   ? adjacentPuzzle.DownSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷 //若上邊為突起，則對接處必須為凹陷，凹陷回傳true，反之則回傳flase
                ///                  : adjacentPuzzle.DownSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起; //若上邊為凹陷，則對接處必須為突起，突起回傳true，反之則回傳flase
                return CheckSide(thisPuzzle.UpSide_, adjacentPuzzle.DownSide_);
            case Direction.Down:
                return thisPuzzle.DownSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起
                    ? adjacentPuzzle.UpSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷
                    : adjacentPuzzle.UpSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起;

            case Direction.Right:
                return thisPuzzle.RightSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起
                    ? adjacentPuzzle.LeftSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷
                    : adjacentPuzzle.LeftSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起;

            case Direction.Left:
                return thisPuzzle.LeftSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起
                    ? adjacentPuzzle.RightSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷
                    : adjacentPuzzle.RightSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起;

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
        return thisPuzzleSide.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起       //檢查上邊，若為突起執行第二行，反之執行第三行
                    ? adjacentPuzzleSide.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷 //若上邊為突起，則對接處必須為凹陷，凹陷回傳true，反之則回傳flase
                    : adjacentPuzzleSide.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起; //若上邊為凹陷，則對接處必須為突起，突起回傳true，反之則回傳flase
    }






    /// <summary>
    /// 檢查放置拼圖是否可以跟周圍拼圖拼起來
    /// </summary>
    /// <param name="i">放置位置座標X</param>
    /// <param name="j">放置位置座標Y</param>
    /// <param name="_thisPuzzle">放置的拼圖</param>
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
            //Debug.Log("上方為邊界");
            return true;
        }

        if (boardController.puzzles[i - 1, j] == null) //如果上方沒有拼圖
        {
            //Debug.Log("上方為空");
            return true;
        }
        else
        {
            upPuzzle = boardController.puzzles[i - 1, j];
        }

        if (thisPuzzle.UpSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起)
        {
            if (upPuzzle.DownSide_.Interlocking_ != PuzzleSideData.Interlocking.indentations_凹陷)
            {
                return false;
            }
        }

        if (thisPuzzle.UpSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷)
        {
            if (upPuzzle.DownSide_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_突起)
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
            //Debug.Log("下方為邊界");
            return true;
        }

        if (boardController.puzzles[i + 1, j] == null) //如果下方沒有拼圖
        {
            //Debug.Log("下方為空");
            return true;
        }
        else
        {
            upPuzzle = boardController.puzzles[i + 1, j];
        }

        if (thisPuzzle.DownSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起)
        {
            if (upPuzzle.UpSide_.Interlocking_ != PuzzleSideData.Interlocking.indentations_凹陷)
            {
                return false;
            }
        }

        if (thisPuzzle.DownSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷)
        {
            if (upPuzzle.UpSide_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_突起)
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
            //Debug.Log("右方為邊界");
            return true;
        }

        if (boardController.puzzles[i, j + 1] == null) //如果右方沒有拼圖
        {
            //Debug.Log("右方為空");
            return true;
        }
        else
        {
            upPuzzle = boardController.puzzles[i, j + 1];
        }

        if (thisPuzzle.RightSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起)
        {
            if (upPuzzle.LeftSide_.Interlocking_ != PuzzleSideData.Interlocking.indentations_凹陷)
            {
                return false;
            }
        }

        if (thisPuzzle.RightSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷)
        {
            if (upPuzzle.LeftSide_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_突起)
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
            //Debug.Log("左方為邊界");
            return true;
        }

        if (boardController.puzzles[i, j - 1] == null) //如果左方沒有拼圖
        {
            //Debug.Log("左方為空");
            return true;
        }
        else
        {
            leftPuzzle = boardController.puzzles[i, j - 1];
        }

        if (thisPuzzle.LeftSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起)
        {
            if (leftPuzzle.RightSide_.Interlocking_ != PuzzleSideData.Interlocking.indentations_凹陷)
            {
                return false;
            }
        }

        if (thisPuzzle.LeftSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷)
        {
            if (leftPuzzle.RightSide_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_突起)
            {
                return false;
            }
        }

        return true;
    }*/




}
