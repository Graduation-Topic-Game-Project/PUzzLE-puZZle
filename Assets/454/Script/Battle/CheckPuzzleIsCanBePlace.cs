using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 檢查拼圖是否可被放置
/// </summary>
public class CheckPuzzleIsCanBePlace : MonoBehaviour
{
    public BoardController boardController;

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

        // 邊界檢查
        if (newI < 0 || newI >= boardController.puzzles.GetLength(0) ||
            newJ < 0 || newJ >= boardController.puzzles.GetLength(1))
        {
            return true;
        }

        // 如果相鄰位置沒有拼圖
        if (boardController.puzzles[newI, newJ] == null)
        {
            return true;
        }


        // 檢查拼圖互鎖
        if (thisSide.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起 &&
            otherSide.Interlocking_ != PuzzleSideData.Interlocking.indentations_凹陷)
        {
            return false;
        }

        if (thisSide.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷 &&
            otherSide.Interlocking_ != PuzzleSideData.Interlocking.protrusions_突起)
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
                _upPuzzleDownSide = boardController.puzzles[i - 1, j].Down_; //上方拼圖的DownSide
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
                _downPuzzleUpSide = boardController.puzzles[i + 1, j].Up_; //下方拼圖的UpSide
        }


        return CheckDirection(i, j, _puzzle, 1, 0, _puzzle.Down_, _downPuzzleUpSide);
    }

    public bool CheckRight(int i, int j, PuzzleData _puzzle)
    {
        PuzzleSideData _rightPuzzleLeftSide = null;

        if (j! >= 6)
        {
            if (boardController.puzzles[i, j + 1] != null)
                _rightPuzzleLeftSide = boardController.puzzles[i, j + 1].Left_; //右方拼圖的LeftSide
        }


        return CheckDirection(i, j, _puzzle, 0, 1, _puzzle.Right_, _rightPuzzleLeftSide);
    }

    public bool CheckLeft(int i, int j, PuzzleData _puzzle)
    {
        PuzzleSideData _leftPuzzleRightSide = null;

        if (j! <= 0)
        {
            if (boardController.puzzles[i, j - 1] != null)
                _leftPuzzleRightSide = boardController.puzzles[i, j - 1].Right_; //左方拼圖的RightSide
        }

        return CheckDirection(i, j, _puzzle, 0, -1, _puzzle.Left_, _leftPuzzleRightSide);
    }*/


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

        if (thisPuzzle.Up_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起)
        {
            if (upPuzzle.Down_.Interlocking_ != PuzzleSideData.Interlocking.indentations_凹陷)
            {
                return false;
            }
        }

        if (thisPuzzle.Up_.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷)
        {
            if (upPuzzle.Down_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_突起)
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

        if (thisPuzzle.Down_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起)
        {
            if (upPuzzle.Up_.Interlocking_ != PuzzleSideData.Interlocking.indentations_凹陷)
            {
                return false;
            }
        }

        if (thisPuzzle.Down_.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷)
        {
            if (upPuzzle.Up_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_突起)
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

        if (thisPuzzle.Right_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起)
        {
            if (upPuzzle.Left_.Interlocking_ != PuzzleSideData.Interlocking.indentations_凹陷)
            {
                return false;
            }
        }

        if (thisPuzzle.Right_.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷)
        {
            if (upPuzzle.Left_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_突起)
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

        if (thisPuzzle.Left_.Interlocking_ == PuzzleSideData.Interlocking.protrusions_突起)
        {
            if (leftPuzzle.Right_.Interlocking_ != PuzzleSideData.Interlocking.indentations_凹陷)
            {
                return false;
            }
        }

        if (thisPuzzle.Left_.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷)
        {
            if (leftPuzzle.Right_.Interlocking_ != PuzzleSideData.Interlocking.protrusions_突起)
            {
                return false;
            }
        }

        return true;
    }



}
