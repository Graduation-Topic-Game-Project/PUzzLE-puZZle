using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyA : Enemy
{
    //public override int AttackNum { get => _attackNum; set => _attackNum = 2; }

    protected override void AwakeNumericSetting()
    {
        _attackNum = 2;
        enemyName = "妖精";
        _enemyHp = 30;
    }

    protected override void DamageFormula(int R, int B, int Y, int P)
    {
        _enemyHp -= R + B + Y * 2 + P * 2;
        Debug.Log($"受到{ R + B + Y * 2 + P * 2}點傷害，體力剩餘{_enemyHp}");
    }
}
