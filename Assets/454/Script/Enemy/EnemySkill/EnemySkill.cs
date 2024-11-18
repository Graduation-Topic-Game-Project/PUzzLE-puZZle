using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySkill : MonoBehaviour
{
    public BattleGameController battleGameController;

    protected virtual void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        battleGameController.Event_SettlementEnemySkill += this.Settlement;
    }

    protected virtual void OnDestroy()  //����P���ɨ����q�\
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
        SettlementSkill();
    }

    /// <summary>
    /// ���B�g����ƥ�
    /// </summary>
    protected virtual void SettlementSkill()
    {

    }

}
