using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemyController : MonoBehaviour
{
    private BattleGameController battleGameController;

    public GameObject EnemyPlane;
    public GameObject[] EnemyPositionGameObject = new GameObject[3]; //�̷ӼĤ��`�ƨӿ�ܥͦ���m
    GameObject NowEnemyPosition;
    public int EnemiesNumber; //�Ĥ��`��



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
    }
    void Start()
    {
        CheckTheNumberOfEnemies();
    }

    /// <summary>
    /// �ˬd�ĤH�ƶq�A�ñҥι���EnemyPosition
    /// </summary>
    void CheckTheNumberOfEnemies()
    {
        int enemiesNum = battleGameController.battleInformation.Enemies.Count;
        switch (enemiesNum)
        {
            case 1:
                //Debug.Log("1��ĤH");
                //NowEnemyPosition = Instantiate(EnemyPositionPrefab[0], transform.position, transform.rotation, EnemyPlane.transform);
                NowEnemyPosition = EnemyPositionGameObject[0];
                NowEnemyPosition.SetActive(true);
                break;
            case 2:
                //Debug.Log("2��ĤH");
                NowEnemyPosition = EnemyPositionGameObject[1];
                NowEnemyPosition.SetActive(true);
                break;
            case 3:
                //Debug.Log("3��ĤH");
                NowEnemyPosition = EnemyPositionGameObject[2];
                NowEnemyPosition.SetActive(true);
                break;
            default:  //�H�W�����ŦX���o��
                Debug.LogError("���~�G�ثe�ĤH�ƶq���䴩�W�L3��");
                break;
        }

        EnemiesNumber = enemiesNum;
        InstantiateEnemies(enemiesNum); // �ͦ��ĤHPrefab
    }
    /// <summary>
    /// �ͦ��ĤHPrefab
    /// </summary>
    /// <param name="enemiesNum">�ĤH�ƶq</param>
    void InstantiateEnemies(int enemiesNum)
    {
        for (int i = 0; i < enemiesNum; i++)
            Instantiate(battleGameController.battleInformation.Enemies[i], NowEnemyPosition.transform.GetChild(i).transform.position, transform.rotation, NowEnemyPosition.transform.GetChild(i));
    }
}
