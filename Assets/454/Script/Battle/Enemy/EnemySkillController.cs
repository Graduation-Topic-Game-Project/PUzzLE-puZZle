using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySkillController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public BoardController boardController;

    /// <summary> ���^�X���Ĥ�ޯ� </summary>
    public List<EnemySkill> enemySkillsThisTurn; //���^�X���Ĥ�ޯ�
    /// <summary> ���^�X�Ĥ�ޯ��ҥͦ���m </summary>
    public GameObject EnemySkillThisTurnInstanceGameObject; //���^�X�Ĥ�ޯ��ҥͦ���m

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
        foreach (Transform child in EnemySkillThisTurnInstanceGameObject.transform)  //�M�ŤW�^�X�ޯ���
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Enemy enemy in battleGameController.InstancedEnemy) //�C��ĤHĲ�o�@��
        {
            for (int i = 0; i < enemy._attackNum; i++)
            {
                int r = UnityEngine.Random.Range(0, enemy.enemySkillsPrefab.Count);  //�H���D�@�ӧޯ�

                if (enemy.enemySkillsPrefab[r] != null)
                {
                    //enemySkillsThisTurn.Add(enemy.enemySkillsPrefab[r].GetComponent<EnemySkill>()); //�{���Xold

                    GameObject skillInstance = Instantiate(enemy.enemySkillsPrefab[r], EnemySkillThisTurnInstanceGameObject.transform);
                    EnemySkill skill = skillInstance.GetComponent<EnemySkill>();

                    if (skill != null)
                    {
                        enemySkillsThisTurn.Add(skill);
                    }
                    else
                    {
                        Debug.LogError("���~�A��Ҥƪ��ޯફ��S�� EnemySkill �ե�I");
                    }
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
        if (battleGameController.IsWin == false) //�p�G�٨SĹ
        {
            foreach (EnemySkill enemySkill in enemySkillsThisTurn)
            {
                enemySkill.SettlementSkill();
            }
        }
    }

    /// <summary>
    /// ����ϩ�m������
    /// </summary>
    private void PuzzlePlaceOver(object sender, EventArgs e)
    {
        foreach (EnemyPuzzleSkill enemyPuzzleSkill in enemySkillsThisTurn) //�ˬd�Ĥ���ϬO�_�}�a
        {
            if (enemyPuzzleSkill.isBreak == false)
            {
                enemyPuzzleSkill.CheckIsBreak(); //���榳���D�A�ӧ諸�O��ҤƩ�L��������
            }
        }

       /*foreach (Board board in boardController.board) //�ˬd�Ĥ���ϬO�_�}�a
         {
             if (board.Puzzle.Type == PuzzleData.PuzzleType.EnemyPuzzle_�Ĥ����)
             {
                EnemyPuzzleSkill enemyPuzzleSkill = (EnemyPuzzle)board.Puzzle;

                 if (enemyPuzzleSkill.isBreak == false)
                 {
                     enemyPuzzleSkill.CheckIsBreak();
                 }
             }
         }*/
    }
}
