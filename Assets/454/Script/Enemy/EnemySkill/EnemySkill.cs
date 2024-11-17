using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySkill : MonoBehaviour
{
    BattleGameController battleGameController;

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        battleGameController.Event_SettlementEnemySkill += this.Settlement;
    }

    private void OnDestroy()  //����P���ɨ����q�\
    {
        if (battleGameController != null)
        {
            battleGameController.Event_SettlementEnemySkill -= Settlement;
        }
    }

    /// <summary>
    /// ����
    /// </summary>
    private void Settlement(object sender, EventArgs e) 
    {

    }

    protected virtual void SettlementSkill()
    {

    }

}
