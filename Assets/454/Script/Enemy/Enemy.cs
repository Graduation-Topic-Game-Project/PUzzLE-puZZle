using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

//[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObject/Enemy", order = 2)]
public class Enemy : MonoBehaviour
{
    private BattleGameController battleGameController;

    [Header("�Ĥ�W��")]
    public string enemyName;
    [Header("�Ĥ�Ϥ�")]
    public Sprite EnemyImage;
    public Sprite DeadImage;

    [Header("��q")]
    public int _enemyHp;

    [Header("�O�_����"), Tooltip("True:���� False���`")]
    public bool _LifeOrDead;

    [Header("��������")]
    public int _attackNum = 1;

    /// <summary> �������� </summary>
    //public virtual int AttackNum { get => _attackNum; set => _attackNum = value; }

    [TextArea]
    public string Information; //�Ĥ褶��

    public List<GameObject> enemySkillsPrefab;

    public event Action Event_IsDead;

    protected void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        _LifeOrDead = true;
        AwakeNumericSetting(); //��ϼƭȳ]�w
    }

    /// <summary>
    /// �ƭȳ]�w
    /// </summary>
    protected virtual void AwakeNumericSetting()
    {

    }

    public virtual void Damage(int R, int B, int Y, int P) //����
    {
        if (_LifeOrDead == true)
        {
            DamageFormula(R, B, Y, P); //����ˮ`����
            IsDead();
        }
    }

    /// <summary>
    /// �ˮ`�p�⤽��
    /// </summary>
    protected virtual void DamageFormula(int R, int B, int Y, int P)
    {
        _enemyHp -= R + B + Y + P;
    }

    /// <summary>
    /// �P�w:�O�_���`
    /// </summary>
    protected virtual bool IsDead()
    {
        if (_enemyHp > 0)
        {
            return true;
        }
        else
        {
            _LifeOrDead = false; //���`
            Event_IsDead?.Invoke(); //�o�e�ƥ�EnemyUiController�A���񦺤`�ʵe
            battleGameController.CallEvent_IsAllEnemyDead(); //�d�ݬO�_�Ҧ��ĤH�Ҧ��`
            return false;
        }
    }

}


