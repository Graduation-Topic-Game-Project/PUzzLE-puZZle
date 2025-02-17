using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private PuzzleData puzzle;
    private GameObject enemySkill;

    public PuzzleData Puzzle { get => puzzle; set { puzzle = value; } }
    public GameObject EnemySkill { get => enemySkill; set { enemySkill = value; } }

    public Board()
    {
        //puzzle = null;
    }
}
