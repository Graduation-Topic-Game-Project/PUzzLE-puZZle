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
        if (battleGameController == null) //��������W��BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        battleGameController.Event_BattleStart += Load_Partner;
        //Load_Partner();
    }

    /// <summary>
    /// �̷ӹ٦��Ƹ��J�԰��p�HUI
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

                switch (battleGameController.partners[i].partnerData.Essence) //�̷ӥ�����ܤ�rUI�C��
                {
                    case EssenceEnum.Essence.Strengthe_�O�q:
                        partnerUI.CombatPowerNumber.color = EssenceEnum.Strengthe_Color;
                        break;
                    case EssenceEnum.Essence.Wisdom_���z:
                        partnerUI.CombatPowerNumber.color = EssenceEnum.Wisdom_Color;
                        break;
                    case EssenceEnum.Essence.Belief_�H��:
                        partnerUI.CombatPowerNumber.color = EssenceEnum.Belief_tColor;
                        break;
                    case EssenceEnum.Essence.Soul_�F��:
                        partnerUI.CombatPowerNumber.color = EssenceEnum.Soul_Color;
                        break;
                    case EssenceEnum.Essence.None_�L�ݩ�:
                        partnerUI.CombatPowerNumber.color = new Color(255, 255, 255, 255);
                        break;
                    default:
                        Debug.LogWarning("���~�A���J�԰��p�HUI�ݩʥX��");
                        break;
                }
            }

        }
    }
}
