using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleData : MonoBehaviour
{
    public static PlayerBattleData playerBattleData;

    static bool FirstInitialized = false;

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

        if (!FirstInitialized)
        {
            FirstInitialized = true;
            Hp = MaxHP;
        }
    }

    static int _hp;
    int _maxHp = 100;

    public static int MaxHP { get => playerBattleData._maxHp; set => PlayerBattleData._hp = value; }

    public static int Hp { get => PlayerBattleData._hp; set => PlayerBattleData._hp = value; }

    public static void ResetPlayer()
    {
        Hp = MaxHP;
    }

    /// <summary>
    /// ���a����ˮ`
    /// </summary>
    /// <param name="damage">����ˮ`��</param>
    public static void Damage(int damage)
    {
        Hp = Hp - damage;
        Debug.Log($"����{damage}�I�ˮ`�A�Ѿl{Hp}Hp");

        BattleAudioController.PlayAudio_PlayerAttacked();
    }
}
