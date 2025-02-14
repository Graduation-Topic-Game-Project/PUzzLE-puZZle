using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private PuzzleData puzzle;
    private EnemySkill enemySkill;

    public PuzzleData Puzzle { get => puzzle; set { puzzle = value; } }
    public EnemySkill EnemySkill { get => enemySkill; set { enemySkill = value; } }

    public Board()
    {
        //puzzle = null;
    }
}
