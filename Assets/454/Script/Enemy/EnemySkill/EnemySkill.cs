using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySkill : MonoBehaviour
{
    protected virtual int damage { get; }

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
    public virtual void SettlementSkill()
    {
        Debug.Log("123");
    }

    /// <summary>
    /// 實例化技能(回合開始時觸發)
    /// </summary>
    public virtual void InstantiateSkill()
    {

    }

}
