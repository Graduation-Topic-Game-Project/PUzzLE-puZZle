using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyPuzzle : Puzzle
{
    public static event Func<PuzzleData,bool> Event_CheckEnemyPuzzleAround; //檢查EnemyPuzzle四方向拼圖

    public void CallEvent_CheckEnemyPuzzleAround()
    {
        Event_CheckEnemyPuzzleAround?.Invoke(this.puzzleData);
    }
}
