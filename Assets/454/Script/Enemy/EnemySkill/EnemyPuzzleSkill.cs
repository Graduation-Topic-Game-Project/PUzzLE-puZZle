using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyPuzzleSkill : EnemySkill
{
    public EnemyPuzzle enemyPuzzle;
    public bool isBreak;

    protected override void Awake()
    {
        base.Awake();
        if (enemyPuzzle = null)
            enemyPuzzle = this.gameObject.transform.GetComponent<EnemyPuzzle>();

        isBreak = false;
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
        if(isBreak == false)
        {
            Debug.Log("���Q�}�a�A��ڤ趤��y���ˮ`");
        }

    }
}
