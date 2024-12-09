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

    [Header("��q")]
    public int _enemyHp;

    [Header("�O�_����"), Tooltip("True:���� False���`")]
    public bool _isLife;

    [Header("��������")]
    public int _attackNum;

    /// <summary> �������� </summary>
    public virtual int AttackNum { get => _attackNum; set => _attackNum = value; }

    [TextArea]
    public string Information; //�Ĥ褶��

    public List<GameObject> enemySkillsPrefab;

    public event Action Event_IsDead;

    protected void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        _isLife = false;
        //_isLife = !Application.isPlaying; // �b����Ҧ��U�T��
    }
    private void Start()
    {
        //this.GetComponent<Image>().sprite = EnemyImage;
        SettlementBoardController.Event_Damage += this.Damage;
    }

    protected virtual void Damage(int R, int B, int Y, int P) //����
    {
        if (_isLife == true)
        {
            DamageFormula(R, B, Y, P); //����ˮ`����
            _isLife = IsDead();
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
            Event_IsDead?.Invoke();
            return false;
        }

    }

    void OnDestroy() //�R���ɡA�Ѱ��q�\
    {
        SettlementBoardController.Event_Damage -= this.Damage;
    }
}


