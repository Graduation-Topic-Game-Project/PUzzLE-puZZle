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
        Hp_value.GetComponent<Image>().fillAmount = ((float)PlayerBattleData.Instance.Hp / PlayerBattleData.Instance.MaxHP);

        if (reverse)
        {
            Hp_value.GetComponent<Image>().fillAmount = (1f - (float)PlayerBattleData.Instance.Hp / PlayerBattleData.Instance.MaxHP);
        }

        if (Input.GetKeyDown("h"))
        {
            PlayerBattleData.Instance.ResetPlayerHp();
        }
    }

}
