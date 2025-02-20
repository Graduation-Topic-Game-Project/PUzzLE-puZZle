using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary> �����Ĥ�ˮ` </summary>
public class EnemyDameged : MonoBehaviour
{
    public BattleGameController battleGameController;

    /// <summary>�����Ĥ�ˮ`</summary>
    public static event Action<int> Event_DamageToEnemy; //�����Ĥ�ˮ`

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();
    }
    void Start()
    {
        EnemyDameged.Event_DamageToEnemy += this.DamageForAllEnemy;
    }

    public static void Call_Event_DamageToEnemy(int damage)
    {
        Event_DamageToEnemy?.Invoke(damage);
        //DamageForAllEnemy(Red, Blue, Yellow, Purple);
    }

    void DamageForAllEnemy(int damage)
    {
        //Debug.Log("test EnemyDameged");
        foreach (Enemy enemy in battleGameController.InstancedEnemy)
        {
            enemy.Damage(damage);
        }
    }

}
