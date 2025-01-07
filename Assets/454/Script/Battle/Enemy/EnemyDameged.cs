using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary> �����Ĥ�ˮ` </summary>
public class EnemyDameged : MonoBehaviour
{
    public BattleGameController battleGameController;

    /// <summary>
    /// �����Ĥ�ˮ`
    /// </summary>
    public static event Action<int, int, int, int> Event_DamageToEnemy; //�����Ĥ�ˮ`

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();
    }
    void Start()
    {
        EnemyDameged.Event_DamageToEnemy += this.DamageForAllEnemy;
    }

    public static void Call_Event_DamageToEnemy(int Red, int Blue, int Yellow, int Purple)
    {
        Event_DamageToEnemy?.Invoke(Red, Blue, Yellow, Purple);
        //DamageForAllEnemy(Red, Blue, Yellow, Purple);
    }

    void DamageForAllEnemy(int R, int B, int Y, int P)
    {
        Debug.Log("test EnemyDameged");
        foreach (Enemy enemy in battleGameController.InstancedEnemy)
        {
            enemy.Damage(R, B, Y, P);
        }
    }

}
