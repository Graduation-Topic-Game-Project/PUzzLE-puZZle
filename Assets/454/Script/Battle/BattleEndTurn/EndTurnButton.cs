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
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        _button = GetComponent<Button>(); //訂閱按紐點擊事件
        _button.onClick.AddListener(EndTurnButtonOnClick);
    }

    private void EndTurnButtonOnClick()
    {
        battleGameController.CallEvent_SettlementBoard(); //結算盤面
        battleGameController.CallEvent_SettlementEnemySkill(); //結算敵人技能
        battleGameController.CallEvent_EndTurn(); //結束回合
        //Event_EndTurn?.Invoke(this, EventArgs.Empty);
    }
}
