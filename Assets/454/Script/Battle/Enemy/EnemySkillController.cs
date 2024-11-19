using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySkillController : MonoBehaviour
{
    public BattleGameController battleGameController;

    public List<EnemySkill> enemySkills;

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        battleGameController.Event_StartTurn += this.RamdomSkill;
    }

    /// <summary>
    /// �^�X�}�l�ɡA�q�C�ӼĤH�W�H����@�ӧޯ�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RamdomSkill(object sender, EventArgs e)
    {
        foreach (Enemy enemy in battleGameController.enemies)
        {
            int r = UnityEngine.Random.Range(0, enemy.enemySkillsPrefab.Count);

            if (enemy.enemySkillsPrefab[r] != null)
            {
                enemySkills.Add(enemy.enemySkillsPrefab[r].GetComponent<EnemySkill>());
                Debug.Log("testRamdomSkil");
            }
            else
            {
                //Debug.LogError("���~�A���ĤHPrefab�W�S���ޯ�");
            }
        }
    }
}
