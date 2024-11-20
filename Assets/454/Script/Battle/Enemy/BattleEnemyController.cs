using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemyController : MonoBehaviour
{
    private BattleGameController battleGameController;

    public GameObject EnemyPlane;
    public GameObject[] EnemyPositionGameObject = new GameObject[3]; //依照敵方總數來選擇生成位置
    GameObject NowEnemyPosition;
    public int EnemiesNumber; //敵方總數



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
    }
    void Start()
    {
        CheckTheNumberOfEnemies();
    }

    /// <summary>
    /// 檢查敵人數量，並啟用對應EnemyPosition
    /// </summary>
    void CheckTheNumberOfEnemies()
    {
        int enemiesNum = battleGameController.battleInformation.Enemies.Count;
        switch (enemiesNum)
        {
            case 1:
                //Debug.Log("1位敵人");
                //NowEnemyPosition = Instantiate(EnemyPositionPrefab[0], transform.position, transform.rotation, EnemyPlane.transform);
                NowEnemyPosition = EnemyPositionGameObject[0];
                NowEnemyPosition.SetActive(true);
                break;
            case 2:
                //Debug.Log("2位敵人");
                NowEnemyPosition = EnemyPositionGameObject[1];
                NowEnemyPosition.SetActive(true);
                break;
            case 3:
                //Debug.Log("3位敵人");
                NowEnemyPosition = EnemyPositionGameObject[2];
                NowEnemyPosition.SetActive(true);
                break;
            default:  //以上都不符合走這個
                Debug.LogError("錯誤：目前敵人數量不支援超過3隻");
                break;
        }

        EnemiesNumber = enemiesNum;
        InstantiateEnemies(enemiesNum); // 生成敵人Prefab
    }
    /// <summary>
    /// 生成敵人Prefab
    /// </summary>
    /// <param name="enemiesNum">敵人數量</param>
    void InstantiateEnemies(int enemiesNum)
    {
        for (int i = 0; i < enemiesNum; i++)
            Instantiate(battleGameController.battleInformation.Enemies[i], NowEnemyPosition.transform.GetChild(i).transform.position, transform.rotation, NowEnemyPosition.transform.GetChild(i));
    }
}
