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
    protected override void OnDestroy()  //����P���ɨ����q�\
    {
        base.OnDestroy();
    }

    /// <summary>
    /// ���B�g����ƥ�
    /// </summary>
    protected override void SettlementSkill()
    {
        /*if(enemyPuzzle.puzzleData != null)
        {
            if (enemyPuzzle.puzzleData.puzzlePosition == (-1, -1))
            {
                Debug.Log("��L���~�A��Ĳ�o����ƥ�");
                return;
            }
        }*/

        if (isBreak == false)
        {
            Debug.Log("���Q�}�a�A��ڤ趤��y���ˮ`");
        }
        else
        {
            Debug.Log("�w�Q�}�a�A���y���ˮ`");
        }
    }

    /// <summary>
    /// ���ͧޯ�
    /// </summary>
    protected override void GenerateSkills()
    {
        int x = UnityEngine.Random.Range(_minX, _maxX);
        int y = UnityEngine.Random.Range(_minY, _maxY);
        
    }
}
