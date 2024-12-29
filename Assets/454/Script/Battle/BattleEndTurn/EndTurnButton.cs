using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    public BattleGameController battleGameController;
    public EndTurnController endTurnController;
    public InspirationButtonController inspirationButtonController;
    Button _button;

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (endTurnController == null) //��������W��EndTurnController
        {
            endTurnController = FindObjectOfType<EndTurnController>();
        }
        if (inspirationButtonController == null) //��������W��InspirationButtonController
        {
            inspirationButtonController = FindObjectOfType<InspirationButtonController>();
        }

        _button = GetComponent<Button>(); //�q�\�����I���ƥ�
        _button.onClick.AddListener(EndTurnButtonOnClick);
    }

    private void EndTurnButtonOnClick()
    {
        endTurnController.StartEndTurn();
        inspirationButtonController.CloseButton();
    }


}
