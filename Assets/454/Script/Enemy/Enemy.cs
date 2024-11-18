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

    public int _enemyAtk;
    public int _enemyHp;

    public List<GameObject> enemySkills;

    protected void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        battleGameController.Event_BattleStart += this.SkillLoad;
    }
    private void Start()
    {
        this.GetComponent<Image>().sprite = EnemyImage;
        SettlementBoardController.Event_Damage += this.Damage;
    }

    public void SkillLoad(object sender, EventArgs e)
    {
        //enemySkills
    }
    
    protected virtual void Damage(int R, int B, int Y, int P) //受傷
    {
        _enemyHp -= R + B + Y + P;
    }



}


