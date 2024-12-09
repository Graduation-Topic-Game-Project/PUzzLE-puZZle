using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyAttack_B : EnemyPuzzleSkill
{
    protected override int damage { get; } = 40;

    protected override int _minX { get; } = 3;

    protected override int _minY { get; } = 6;

}
