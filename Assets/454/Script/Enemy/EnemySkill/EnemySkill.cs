using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySkill : MonoBehaviour
{
    public BattleGameController battleGameController;

    protected virtual void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        battleGameController.Event_SettlementEnemySkill += this.Settlement;
    }

    protected virtual void OnDestroy()  //物件銷毀時取消訂閱
    {
        if (battleGameController != null)
        {
            battleGameController.Event_SettlementEnemySkill -= Settlement;
        }
    }

    /// <summary>
    /// 結算
    /// </summary>
    private void Settlement(object sender, EventArgs e) 
    {
        SettlementSkill();
    }

    /// <summary>
    /// 此處寫結算事件
    /// </summary>
    protected virtual void SettlementSkill()
    {

    }

}
