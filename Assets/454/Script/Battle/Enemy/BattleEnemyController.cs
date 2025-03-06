using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleEnemyController : MonoBehaviour
{
    private BattleGameController battleGameController;

    //public GameObject EnemyPlane;

    public GameObject[] EnemyPositionGameObject = new GameObject[3]; //�̷ӼĤ��`�ƨӿ�ܥͦ���m
    public EnemyBattleUI[] enemyBattleUI = new EnemyBattleUI[3];  //�k��Ĥ��T
    [Tooltip("�O�_��ܥk��Ĥ��TUI")]
    public bool isEnemyBattleUI; //�O�_��ܥk��UI
    GameObject NowEnemyPosition;
    public int EnemiesNumber; //�Ĥ��`��

    public List<GameObject> InstanceEnemyObject = new List<GameObject>(); //��Ҥƪ��ĤH����

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        // �T�O enemies �M��
        battleGameController.enemies.Clear();

        // �ʺA�K�[�ĤH
        for (int i = 0; i < battleGameController.battleInformation.Enemies.Count; i++)
        {
            Enemy enemyComponent = battleGameController.battleInformation.Enemies[i].GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                battleGameController.enemies.Add(enemyComponent);
            }
            else
            {
                Debug.LogWarning($"�ĤH���� {i} �ʤ� Enemy ����");
            }
        }

        battleGameController.Event_BattleStart += CheckTheNumberOfEnemies;
        battleGameController.Event_IsAllEnemyDead += IsAllEnemyDead; //
    }
    void Start()
    {
        //CheckTheNumberOfEnemies();
    }

    /// <summary>
    /// �ˬd�ĤH�ƶq�A�ñҥι���EnemyPosition
    /// </summary>
    void CheckTheNumberOfEnemies(object sender, EventArgs e)
    {
        int enemiesNum = battleGameController.battleInformation.Enemies.Count;
        switch (enemiesNum)
        {
            case 1:
                //Debug.Log("1��ĤH");
                NowEnemyPosition = EnemyPositionGameObject[0];
                SetActiceEnemyBattleUI(1);
                NowEnemyPosition.SetActive(true);
                break;
            case 2:
                //Debug.Log("2��ĤH");
                NowEnemyPosition = EnemyPositionGameObject[1];
                SetActiceEnemyBattleUI(2);
                NowEnemyPosition.SetActive(true);
                break;
            case 3:
                //Debug.Log("3��ĤH");
                NowEnemyPosition = EnemyPositionGameObject[2];
                SetActiceEnemyBattleUI(3);
                NowEnemyPosition.SetActive(true);
                break;
            default:  //�H�W�����ŦX���o��
                Debug.LogError("���~�G�ثe�ĤH�ƶq���䴩�W�L3��");
                break;
        }

        EnemiesNumber = enemiesNum;
        InstantiateEnemies(enemiesNum); // �ͦ��ĤHPrefab
    }

    /// <summary> �}�ҼĤH�԰���TUI  </summary>
    /// <param name="EnemyAmount">�ĤH�ƶq(1~3)</param>
    void SetActiceEnemyBattleUI(int EnemyAmount)
    {
        if (isEnemyBattleUI == true)
        {
            for (int i = 0; i < EnemyAmount; i++)
            {
                enemyBattleUI[i].gameObject.SetActive(true);

            }
        }
    }

    /// <summary>
    /// �ͦ��ĤHPrefab
    /// </summary>
    /// <param name="enemiesNum">�ĤH�ƶq</param>
    void InstantiateEnemies(int enemiesNum)
    {
        for (int i = 0; i < enemiesNum; i++)
        {
            GameObject enemyObject = Instantiate(battleGameController.battleInformation.Enemies[i],
             NowEnemyPosition.transform.GetChild(i).transform.position,
             transform.rotation,
             NowEnemyPosition.transform.GetChild(i));
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            enemy.enemyBattleUI = enemyBattleUI[i];
            enemyBattleUI[i].EnemyImage.sprite = enemy.Avatar;

            InstanceEnemyObject.Add(enemyObject);
            battleGameController.InstancedEnemy.Add(enemy);
        }
    }

    public void IsAllEnemyDead() //�ˬd�O�_�����Ĥ�Ҧ��`
    {
        foreach (Enemy enemy in battleGameController.InstancedEnemy)
        {
            Debug.Log(enemy);
            if (enemy._LifeOrDead == true)
                return;
        }

        battleGameController.CallEvent_Win();
    }
}
