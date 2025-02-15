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

    public EnemyUIController enemyUIController;

    [Header("敵方名稱")]
    public string enemyName;
    [Header("敵方圖片")]
    public Sprite EnemyImage;
    public Sprite DeadImage;

    [Header("血量")]
    public int _enemyHp;

    [Header("是否活著"), Tooltip("True:活著 False死亡")]
    public bool _LifeOrDead;

    [Header("攻擊次數")]
    public int _attackNum = 1;

    /// <summary> 攻擊次數 </summary>
    //public virtual int AttackNum { get => _attackNum; set => _attackNum = value; }

    [TextArea]
    public string Information; //敵方介紹

    public List<GameObject> enemySkillsPrefab;

    /// <summary> 【事件】死亡時 </summary>
    public event Action Event_IsDead;  //死亡時

    public event Action<int> Event_ConfrontaionStart;

    public event Action Event_ConfrontaionEnd;

    protected void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        _LifeOrDead = true;
        AwakeNumericSetting(); //初使數值設定
    }

    /// <summary>
    /// 數值設定
    /// </summary>
    protected virtual void AwakeNumericSetting()
    {
        //子物件用
    }

    public virtual void Damage(int R, int B, int Y, int P) //受傷
    {
        if (_LifeOrDead == true)
        {
            DamageFormula(R, B, Y, P); //執行傷害公式
            IsDead();
        }
    }

    public virtual void Damage(int damage) //受傷(無屬性)
    {
        if (_LifeOrDead == true)
        {
            DamageFormula(damage); //執行傷害公式
            IsDead();
        }
    }

    /// <summary>傷害計算公式 </summary>
    protected virtual void DamageFormula(int R, int B, int Y, int P)
    {
        _enemyHp -= R + B + Y + P;
    }

    /// <summary>傷害計算公式(無屬性) </summary>
    protected virtual void DamageFormula(int damage)
    {
        _enemyHp -= damage;
    }

    /// <summary> 顯示戰力值 </summary>
    public void ShowCombatPower(int _combatPower)
    {
        Event_ConfrontaionStart?.Invoke(_combatPower);
    }

    /// <summary> 隱藏戰力值UI </summary>
    public void ClearCombatPower()
    {
        Event_ConfrontaionEnd?.Invoke();
    }

    /// <summary>
    /// 判定:是否死亡
    /// </summary>
    protected virtual bool IsDead()
    {
        if (_enemyHp > 0)
        {
            return true;
        }
        else
        {
            _LifeOrDead = false; //死亡
            Event_IsDead?.Invoke(); //發送事件給EnemyUiController，撥放死亡動畫
            battleGameController.CallEvent_IsAllEnemyDead(); //查看是否所有敵人皆死亡
            return false;
        }
    }

}


