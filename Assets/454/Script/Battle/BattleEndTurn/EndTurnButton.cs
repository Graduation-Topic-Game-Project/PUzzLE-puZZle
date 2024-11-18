using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    public BattleGameController battleGameController;
    Button _button;
    //public GameObject EndTurnButton;


    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        _button = GetComponent<Button>(); //�q�\�����I���ƥ�
        _button.onClick.AddListener(EndTurnButtonOnClick);
    }

    private void EndTurnButtonOnClick()
    {
        battleGameController.CallEvent_SettlementBoard(); //����L��
        battleGameController.CallEvent_SettlementEnemySkill(); //����ĤH�ޯ�
        battleGameController.CallEvent_EndTurn(); //�����^�X
        //Event_EndTurn?.Invoke(this, EventArgs.Empty);
    }
}
