using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyA : Enemy
{

    private void Awake()
    {
        base.Awake();
        enemyName = "����";
        _enemyHp = 20;
    }

    protected override void Damage(int R, int B, int Y, int P)
    {
        _enemyHp -= R + B + Y + P;
    }
}
