using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    public BattleGameController battleGameController;
    public EndTurnController endTurnController;
    Button _button;


    public event Action Event_CloseInspiration;

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (endTurnController == null) //獲取場景上的EndTurnController
        {
            endTurnController = FindObjectOfType<EndTurnController>();
        }

        _button = GetComponent<Button>(); //訂閱按紐點擊事件
        _button.onClick.AddListener(EndTurnButtonOnClick);
    }

    private void EndTurnButtonOnClick()
    {
        endTurnController.StartEndTurn();
        Event_CloseInspiration?.Invoke();
    }


}
