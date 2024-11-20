using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private PuzzleData puzzle;

    public PuzzleData Puzzle { get => puzzle; set { puzzle = value; } }

    public Board()
    {
        //puzzle = null;
    }
}
