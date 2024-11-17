using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 檢查拼圖是否可被放置
/// </summary>
public class CheckPuzzleIsCanBePlace : MonoBehaviour
{
    public BoardController boardController;

    (int, int)[] directionOffset = { (-1, 0), (1, 0), (0, 1), (0, -1) }; // 分別代表上、下、右、左 的方向座標差值
    enum Direction { Up, Down, Right, Left }

    private void Awake()
    {
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


    /// <param name="direction">檢查的方向</param>
    /// <returns></returns>
    private bool CheckDirection(int i, int j, PuzzleData thisPuzzle, Direction direction)
    {
        (int di, int dj) = directionOffset[(int)direction]; //依照方向direction的列舉值，取得座標差值陣列
        int newI = i + di, newJ = j + dj;

        // 檢查邊界
        if (newI < 0 || newI >= boardController.puzzles.GetLength(0) ||
            newJ < 0 || newJ >= boardController.puzzles.GetLength(1))
            return true;

        // 檢查是否存在拼圖
        PuzzleData adjacentPuzzle = boardController.puzzles[newI, newJ];
        if (adjacentPuzzle == null)
            return true;

        // 根據方向檢查拼圖邊的連接
        switch (direction)
        {
            case Direction.Up:
                return thisPuzzle.UpSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起
                    ? adjacentPuzzle.DownSide_.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷
                    : adjacentPuzzle.DownSide_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起;

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
