using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySkill : MonoBehaviour
{
    protected virtual int damage { get; }

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
    public virtual void SettlementSkill()
    {
        Debug.Log("123");
    }

    /// <summary>
    /// ��ҤƧޯ�(�^�X�}�l��Ĳ�o)
    /// </summary>
    public virtual void InstantiateSkill()
    {

    }

}
