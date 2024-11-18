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
    protected override void OnDestroy()  //物件銷毀時取消訂閱
    {
        base.OnDestroy();
    }

    /// <summary>
    /// 此處寫結算事件
    /// </summary>
    protected override void SettlementSkill()
    {
        if(isBreak == false)
        {
            Debug.Log("未被破壞，對我方隊伍造成傷害");
        }

    }
}
