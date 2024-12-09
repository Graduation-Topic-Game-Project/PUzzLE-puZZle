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

    [Header("敵方名稱")]
    public string enemyName;
    [Header("敵方圖片")]
    public Sprite EnemyImage;

    [Header("血量")]
    public int _enemyHp;

    [Header("是否活著"), Tooltip("True:活著 False死亡")]
    public bool _isLife;

    [Header("攻擊次數")]
    public int _attackNum;

    /// <summary> 攻擊次數 </summary>
    public virtual int AttackNum { get => _attackNum; set => _attackNum = value; }

    [TextArea]
    public string Information; //敵方介紹

    public List<GameObject> enemySkillsPrefab;

    public event Action Event_IsDead;

    protected void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        _isLife = false;
        //_isLife = !Application.isPlaying; // 在執行模式下禁用
    }
    private void Start()
    {
        //this.GetComponent<Image>().sprite = EnemyImage;
        SettlementBoardController.Event_Damage += this.Damage;
    }

    protected virtual void Damage(int R, int B, int Y, int P) //受傷
    {
        if (_isLife == true)
        {
            DamageFormula(R, B, Y, P); //執行傷害公式
            _isLife = IsDead();
        }
    }

    /// <summary>
    /// 傷害計算公式
    /// </summary>
    protected virtual void DamageFormula(int R, int B, int Y, int P)
    {
        _enemyHp -= R + B + Y + P;
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
            Event_IsDead?.Invoke();
            return false;
        }

    }

    void OnDestroy() //刪除時，解除訂閱
    {
        SettlementBoardController.Event_Damage -= this.Damage;
    }
}


