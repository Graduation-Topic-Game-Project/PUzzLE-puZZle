using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarController : MonoBehaviour
{
    public GameObject Hp_value;
    public bool reverse;

    void Start()
    {
        //PlayerBattleData.ResetPlayer();
    }
    private void Update()
    {
        Hp_value.GetComponent<Image>().fillAmount = ((float)PlayerBattleData.Hp / PlayerBattleData.MaxHP);

        if (reverse)
        {
            Hp_value.GetComponent<Image>().fillAmount = (1f - (float)PlayerBattleData.Hp / PlayerBattleData.MaxHP);
        }

        if (Input.GetKeyDown("h"))
        {
            PlayerBattleData.ResetPlayerHp();
        }
    }

}
