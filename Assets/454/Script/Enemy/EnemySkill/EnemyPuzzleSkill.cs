using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyPuzzleSkill : EnemySkill
{
    public EnemyPuzzle enemyPuzzle;

    protected override void Awake()
    {
        base.Awake();
        if (enemyPuzzle = null)
            enemyPuzzle = this.gameObject.transform.GetComponent<EnemyPuzzle>();
    }
    protected override void OnDestroy()  //����P���ɨ����q�\
    {
        base.OnDestroy();
    }

    /// <summary>
    /// ���B�g����ƥ�
    /// </summary>
    protected override void SettlementSkill()
    {

    }
}
