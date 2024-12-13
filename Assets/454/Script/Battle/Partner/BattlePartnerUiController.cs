using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePartnerUiController : MonoBehaviour
{
    BattleGameController battleGameController;
    public GameObject[] PartnersGameObject = new GameObject[4];

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        Load_Partner();
    }
    public void Load_Partner()
    {
        for(int i = 0; i < 4; i++)
        {
            if (this.gameObject.transform.GetChild(i).gameObject != null)
            {
                PartnersGameObject[i] = this.gameObject.transform.GetChild(i).gameObject;
                PartnersGameObject[i].GetComponent<BattlePartner>().PartnerNumber = i;
                PartnersGameObject[i].GetComponent<BattlePartner>().PartnerImage.sprite = battleGameController.partners[i].thisPartner.PartnerCuteBattle;
            }

        }
    }
}
