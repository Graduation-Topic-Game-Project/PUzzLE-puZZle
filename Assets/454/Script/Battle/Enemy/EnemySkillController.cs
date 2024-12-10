using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySkillController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public BoardController boardController;

    public List<EnemySkill> enemySkillsThisTurn; //���^�X���Ĥ�ޯ�

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (boardController == null) //��������W��BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }

        battleGameController.Event_StartTurn += this.RamdomSkill; //�^�X�}�l�ɡA�q�C�ӼĤH�W�H����@�ӧޯ�
        battleGameController.Event_StartTurn += this.InitializeAndInstantiateAllSkill;  // �^�X�}�l�ɡAĲ�o�C�ӧޯ઺��l�ƻP��ҤƮĪG
        battleGameController.Event_PuzzlePlaceCompleted += this.PuzzlePlaceOver;
        battleGameController.Event_SettlementEnemySkill += this.Settlement; //�^�X������Ĳ�o����ƥ�
    }

    /// <summary>
    /// �^�X�}�l�ɡA�q�C�ӼĤH�W�H����@�ӧޯ�
    /// </summary>
    private void RamdomSkill(object sender, EventArgs e)
    {
        enemySkillsThisTurn.Clear(); //�M�ŤW�^�X���ޯ�
        Debug.Log("123:");
        foreach (Enemy enemy in battleGameController.InstancedEnemy) //�C��ĤHĲ�o�@��
        {
 
            for (int i = 0; i < enemy._attackNum; i++)
            {
                int r = UnityEngine.Random.Range(0, enemy.enemySkillsPrefab.Count);  //�H���D�@�ӧޯ�

                if (enemy.enemySkillsPrefab[r] != null)
                {
                    enemySkillsThisTurn.Add(enemy.enemySkillsPrefab[r].GetComponent<EnemySkill>()); //�{���X1
                }
                else
                {
                    Debug.LogError("���~�A���ĤHPrefab�W�S���ޯ�");
                }
            }
        }
    }

    /// <summary>
    /// �^�X�}�l�ɡAĲ�o�C�ӧޯ઺��l�ƻP��ҤƮĪG
    /// </summary>
    private void InitializeAndInstantiateAllSkill(object sender, EventArgs e)
    {
        foreach (EnemySkill enemySkill in enemySkillsThisTurn)
        {
            enemySkill.InitializeSkill(); //��l�Ƨޯ�
            enemySkill.InstantiateSkill(); //��ҤƧޯ�
        }
    }

    /// <summary>
    /// ����Ҧ��Ĥ�ޯ�
    /// </summary>
    private void Settlement(object sender, EventArgs e)
    {
        foreach (EnemySkill enemySkill in enemySkillsThisTurn)
        {
            enemySkill.SettlementSkill();
        }
    }

    /// <summary>
    /// ����ϩ�m������
    /// </summary>
    private void PuzzlePlaceOver(object sender, EventArgs e)
    {
        foreach (EnemyPuzzleSkill enemyPuzzleSkill in enemySkillsThisTurn)
        {
            if (enemyPuzzleSkill.isBreak == false)
            {
                enemyPuzzleSkill.CheckIsBreak();
            }
        }
    }
}
