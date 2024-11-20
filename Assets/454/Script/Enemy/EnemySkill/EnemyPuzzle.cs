using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyPuzzle : Puzzle
{

    public void RandomlyEnemyPuzzleData() //隨機化敵方拼圖凹凸
    {
        puzzleData.UpSide_ = new PuzzleSideData();
        puzzleData.DownSide_ = new PuzzleSideData();
        puzzleData.RightSide_ = new PuzzleSideData();
        puzzleData.LeftSide_ = new PuzzleSideData();

        puzzleData.UpSide_ = puzzleData.UpSide_.RandomlyGeneratedPuzzleData(puzzleData.UpSide_);
        puzzleData.DownSide_ = puzzleData.DownSide_.RandomlyGeneratedPuzzleData(puzzleData.DownSide_);
        puzzleData.RightSide_ = puzzleData.RightSide_.RandomlyGeneratedPuzzleData(puzzleData.RightSide_);
        puzzleData.LeftSide_ = puzzleData.LeftSide_.RandomlyGeneratedPuzzleData(puzzleData.LeftSide_);

        //puzzleSideData.Interlocking_ = (PuzzleSideData.Interlocking)UnityEngine.Random.Range(1, 3);
    }
}
