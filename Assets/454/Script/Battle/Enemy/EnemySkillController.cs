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
        battleGameController.Event_StartTurn += this.InstantiateAllSkill;  // �^�X�}�l�ɡAĲ�o�C�ӧޯ઺��ҤƮĪG
        battleGameController.Event_PuzzlePlaceCompleted += this.PuzzlePlaceOver;
        battleGameController.Event_SettlementEnemySkill += this.Settlement; //�^�X������Ĳ�o����ƥ�
    }

    /// <summary>
    /// �^�X�}�l�ɡA�q�C�ӼĤH�W�H����@�ӧޯ�
    /// </summary>
    private void RamdomSkill(object sender, EventArgs e)
    {
        enemySkillsThisTurn.Clear(); //�M�ŤW�^�X���ޯ�

        foreach (Enemy enemy in battleGameController.enemies) //�C��ĤHĲ�o�@��
        {
            int r = UnityEngine.Random.Range(0, enemy.enemySkillsPrefab.Count);  //�H���D�@�ӧޯ�

            if (enemy.enemySkillsPrefab[r] != null)
            {               
                enemySkillsThisTurn.Add(enemy.enemySkillsPrefab[r].GetComponent<EnemySkill>()); //�{���X1

                /*EnemySkill enemySkill = enemy.enemySkillsPrefab[r].GetComponent<EnemySkill>(); //�{���X2
                enemySkillsThisTurn.Add(enemySkill);*/
            }
            else
            {
                Debug.LogError("���~�A���ĤHPrefab�W�S���ޯ�");
            }
        }
    }

    /// <summary>
    /// �^�X�}�l�ɡAĲ�o�C�ӧޯ઺��ҤƮĪG
    /// </summary>
    private void InstantiateAllSkill(object sender, EventArgs e)
    {
        foreach (EnemySkill enemySkill in enemySkillsThisTurn)
        {
            enemySkill.InstantiateSkill();
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
