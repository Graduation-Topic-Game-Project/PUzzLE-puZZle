using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarController : MonoBehaviour
{
    public GameObject Hp_value;

    /*int maxHP = Player.MaxHP;
    int hP = Player.Hp;*/

    void Start()
    {
        Player.ResetPlayer();
    }
    private void Update()
    {
        Hp_value.GetComponent<Image>().fillAmount = ((float)Player.Hp / Player.MaxHP);
        //Debug.Log((float)Player.Hp / Player.MaxHP);
    }
}
