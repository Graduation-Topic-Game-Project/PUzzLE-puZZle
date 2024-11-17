using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyPuzzle : Puzzle
{
    EnemySkill _enemySkill;

    private void Awake()
    {
        _enemySkill = gameObject.GetComponent<EnemySkill>();
    }
}
