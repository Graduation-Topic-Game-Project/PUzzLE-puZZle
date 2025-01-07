using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarController : MonoBehaviour
{
    public GameObject Hp_value;
    float maxHpUIProportion = 1f; //滿血時UI比例
    public bool reverse; //反轉(滿血時為空)

    void Start()
    {
        //PlayerBattleData.ResetPlayer();
    }
    private void Update()
    {
        Hp_value.GetComponent<Image>().fillAmount = ((float)PlayerBattleData.Instance.Hp / PlayerBattleData.Instance.MaxHP) * maxHpUIProportion;

        if (reverse)
        {
            Hp_value.GetComponent<Image>().fillAmount = (1f - (float)PlayerBattleData.Instance.Hp / PlayerBattleData.Instance.MaxHP) * maxHpUIProportion;
        }

        if (Input.GetKeyDown("h"))
        {
            PlayerBattleData.Instance.ResetPlayerHp();
        }
    }

}
