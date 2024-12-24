using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleData : MonoBehaviour
{
    public static PlayerBattleData Instance { get; private set; }

    static bool FirstInitialized = false;

   

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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

    public  int MaxHP { get => Instance._maxHp; set => PlayerBattleData._hp = value; }

    public  int Hp { get => PlayerBattleData._hp; set => PlayerBattleData._hp = value; }

    public  void ResetPlayerHp()
    {
        Hp = MaxHP;
    }

    /// <summary>
    /// ���a����ˮ`
    /// </summary>
    /// <param name="damage">����ˮ`��</param>
    public  void Damage(int damage)
    {
        Hp = Hp - damage;
        Debug.Log($"����{damage}�I�ˮ`�A�Ѿl{Hp}Hp");

        BattleAudioController.PlayAudio_PlayerAttacked();
    }
}
