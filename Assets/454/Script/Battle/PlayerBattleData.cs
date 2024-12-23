using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleData : MonoBehaviour
{
    static PlayerBattleData @this;

    static bool FirstInitialized = false;

    /*public static PlayerBattleData Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singleton = new GameObject();
                _instance = singleton.AddComponent<PlayerBattleData>();
                singleton.name = "[Singleton] PlayerBattleData";

                DontDestroyOnLoad(singleton);
            }

            return _instance;
        }
    }*/

    private void Awake()
    {
        if (@this == null)
        {
            @this = this;
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

    public static int MaxHP { get => @this._maxHp; set => PlayerBattleData._hp = value; }

    public static int Hp { get => PlayerBattleData._hp; set => PlayerBattleData._hp = value; }

    public static void ResetPlayerHp()
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
