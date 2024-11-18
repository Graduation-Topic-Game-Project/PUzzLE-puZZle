using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleData : MonoBehaviour
{
    public static PlayerBattleData playerBattleData;

    private void Awake()
    {
        if (playerBattleData == null)
        {
            playerBattleData = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    int _hp;
    int _maxHp = 100;

    public static int MaxHP { get => playerBattleData._maxHp; set => playerBattleData._hp = value; }

    public static int Hp { get => playerBattleData._hp; set => playerBattleData._hp = value; }

    public static void ResetPlayer()
    {
        Hp = MaxHP;
    }

    /// <summary>
    /// 玩家受到傷害
    /// </summary>
    /// <param name="damage">受到傷害值</param>
    public static void Damage(int damage)
    {
        Hp = Hp - damage;
        Debug.Log($"受到{damage}點傷害，剩餘{Hp}Hp");
    }
}
