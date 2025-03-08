using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattlePartnerUiController : MonoBehaviour
{
    BattleGameController battleGameController;
    public GameObject[] PartnersGameObject = new GameObject[4];

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        battleGameController.Event_BattleStart += Load_Partner;
        //Load_Partner();
    }

    /// <summary>
    /// 依照夥伴資料載入戰鬥小人UI
    /// </summary>
    public void Load_Partner(object sender, EventArgs e)
    {
        for (int i = 0; i < 4; i++)
        {
            {
                BattlePartner partnerUI = PartnersGameObject[i].GetComponent<BattlePartner>();

                partnerUI.partner = battleGameController.partners[i];
                partnerUI.PartnerNumber = i;
                partnerUI.PartnerImage.sprite = battleGameController.partners[i].partnerData.PartnerCuteBattle;

                switch (battleGameController.partners[i].partnerData.Essence) //依照本質改變文字UI顏色
                {
                    case EssenceEnum.Essence.Strengthe_力量:
                        partnerUI.CombatPowerNumber.color = EssenceEnum.Strengthe_Color;
                        break;
                    case EssenceEnum.Essence.Wisdom_智慧:
                        partnerUI.CombatPowerNumber.color = EssenceEnum.Wisdom_Color;
                        break;
                    case EssenceEnum.Essence.Belief_信仰:
                        partnerUI.CombatPowerNumber.color = EssenceEnum.Belief_tColor;
                        break;
                    case EssenceEnum.Essence.Soul_靈魂:
                        partnerUI.CombatPowerNumber.color = EssenceEnum.Soul_Color;
                        break;
                    case EssenceEnum.Essence.None_無屬性:
                        partnerUI.CombatPowerNumber.color = new Color(255, 255, 255, 255);
                        break;
                    default:
                        Debug.LogWarning("錯誤，載入戰鬥小人UI屬性出錯");
                        break;
                }
            }

        }
    }
}
