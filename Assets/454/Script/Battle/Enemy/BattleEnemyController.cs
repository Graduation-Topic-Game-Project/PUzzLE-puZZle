using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleEnemyController : MonoBehaviour
{
    private BattleGameController battleGameController;

    //public GameObject EnemyPlane;

    public GameObject[] EnemyPositionGameObject = new GameObject[3]; //依照敵方總數來選擇生成位置
    public EnemyBattleUI[] enemyBattleUI = new EnemyBattleUI[3];  //右方敵方資訊
    [Tooltip("是否顯示右方敵方資訊UI")]
    public bool isEnemyBattleUI; //是否顯示右方UI
    GameObject NowEnemyPosition;
    public int EnemiesNumber; //敵方總數

    public List<GameObject> InstanceEnemyObject = new List<GameObject>(); //實例化的敵人物件

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        // 確保 enemies 清空
        battleGameController.enemies.Clear();

        // 動態添加敵人
        for (int i = 0; i < battleGameController.battleInformation.Enemies.Count; i++)
        {
            Enemy enemyComponent = battleGameController.battleInformation.Enemies[i].GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                battleGameController.enemies.Add(enemyComponent);
            }
            else
            {
                Debug.LogWarning($"敵人物件 {i} 缺少 Enemy 元件");
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
    /// 檢查敵人數量，並啟用對應EnemyPosition
    /// </summary>
    void CheckTheNumberOfEnemies(object sender, EventArgs e)
    {
        int enemiesNum = battleGameController.battleInformation.Enemies.Count;
        switch (enemiesNum)
        {
            case 1:
                //Debug.Log("1位敵人");
                NowEnemyPosition = EnemyPositionGameObject[0];
                SetActiceEnemyBattleUI(1);
                NowEnemyPosition.SetActive(true);
                break;
            case 2:
                //Debug.Log("2位敵人");
                NowEnemyPosition = EnemyPositionGameObject[1];
                SetActiceEnemyBattleUI(2);
                NowEnemyPosition.SetActive(true);
                break;
            case 3:
                //Debug.Log("3位敵人");
                NowEnemyPosition = EnemyPositionGameObject[2];
                SetActiceEnemyBattleUI(3);
                NowEnemyPosition.SetActive(true);
                break;
            default:  //以上都不符合走這個
                Debug.LogError("錯誤：目前敵人數量不支援超過3隻");
                break;
        }

        EnemiesNumber = enemiesNum;
        InstantiateEnemies(enemiesNum); // 生成敵人Prefab
    }

    /// <summary> 開啟敵人戰鬥資訊UI  </summary>
    /// <param name="EnemyAmount">敵人數量(1~3)</param>
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
    /// 生成敵人Prefab
    /// </summary>
    /// <param name="enemiesNum">敵人數量</param>
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

    public void IsAllEnemyDead() //檢查是否全部敵方皆死亡
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
