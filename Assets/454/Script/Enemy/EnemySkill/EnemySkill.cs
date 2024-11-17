using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySkill : MonoBehaviour
{
    BattleGameController battleGameController;

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        battleGameController.Event_SettlementEnemySkill += this.Settlement;
    }

    private void OnDestroy()  //物件銷毀時取消訂閱
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

    }

    protected virtual void SettlementSkill()
    {

    }

}
