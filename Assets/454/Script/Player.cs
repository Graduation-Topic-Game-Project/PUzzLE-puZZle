using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static int _hp;
    static int _maxHp = 100;
    
    public static int MaxHP { get => _maxHp; set => _hp = value; }

    public static int Hp { get => _hp; set => _hp = value; }

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
