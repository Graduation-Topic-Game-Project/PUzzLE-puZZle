using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyA : Enemy
{
    EnemySkill enemySkill;
    private void Awake()
    {
        base.Awake();
        enemyName = "§¯ºë";
        _enemyHp = 20;
        _enemyAtk = 10;
    }

    protected override void Damage(int R, int B, int Y, int P)
    {
        _enemyHp -= R + B + Y + P;
    }
}
