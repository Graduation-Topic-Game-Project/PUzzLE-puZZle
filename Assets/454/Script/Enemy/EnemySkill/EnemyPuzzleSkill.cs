using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyPuzzleSkill : EnemySkill
{
    public EnemyPuzzle enemyPuzzle;
    public bool isBreak;
    int _minX = 0;
    int _maxX = 5;
    int _minY = 0;
    int _maxY = 6;


    protected override void Awake()
    {
        base.Awake();
        if (enemyPuzzle == null)
            enemyPuzzle = this.gameObject.transform.GetComponent<EnemyPuzzle>();

        isBreak = false;
    }
    protected override void OnDestroy()  //物件銷毀時取消訂閱
    {
        base.OnDestroy();
    }

    /// <summary>
    /// 此處寫結算事件
    /// </summary>
    protected override void SettlementSkill()
    {
        /*if(enemyPuzzle.puzzleData != null)
        {
            if (enemyPuzzle.puzzleData.puzzlePosition == (-1, -1))
            {
                Debug.Log("於盤面外，未觸發結算事件");
                return;
            }
        }*/

        if (isBreak == false)
        {
            Debug.Log("未被破壞，對我方隊伍造成傷害");
        }
        else
        {
            Debug.Log("已被破壞，未造成傷害");
        }
    }

    /// <summary>
    /// 產生技能
    /// </summary>
    protected override void GenerateSkills()
    {
        int x = UnityEngine.Random.Range(_minX, _maxX);
        int y = UnityEngine.Random.Range(_minY, _maxY);
        
    }
}
