using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySkill : MonoBehaviour
{
    public string SkillName;
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
    /// ��l�Ƨޯ�(�^�X�}�l��Ĳ�o)
    /// </summary>
    public virtual void InitializeSkill()
    {

    }

    /// <summary>
    /// ��ҤƧޯ�(�^�X�}�l��Ĳ�o)
    /// </summary>
    public virtual void InstantiateSkill()
    {

    }

}
