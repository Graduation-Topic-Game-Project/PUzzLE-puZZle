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

    public static void Damage(int damage)
    {
        Hp = Hp - damage;
        Debug.Log($"¨ü¨ì{damage}ÂI¶Ë®`¡A³Ñ¾l{Hp}Hp");
    }
}
