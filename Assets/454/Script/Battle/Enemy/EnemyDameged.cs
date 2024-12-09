using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDameged : MonoBehaviour
{
    public BattleGameController battleGameController;
    //public BattleEnemyController battleEnemyController;

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();
        /*if (battleEnemyController == null) //��������W��BattleEnemyController      
            battleEnemyController = FindObjectOfType<BattleEnemyController>();*/
    }
    void Start()
    {
        SettlementBoardController.Event_Damage += this.DamageForAllEnemy;
    }

    void DamageForAllEnemy(int R, int B, int Y, int P)
    {
       // Debug.Log("test EnemyDameged");
        foreach (Enemy enemy in battleGameController.InstancedEnemy)
        {
            battleGameController.enemies[0].Damage(R, B, Y, P);
        }
    }

}
