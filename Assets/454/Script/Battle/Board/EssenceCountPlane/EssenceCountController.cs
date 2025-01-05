using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EssenceCountController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public SettlementBoardController settlementBoardController;
    public TextMeshProUGUI Red_CountText, Blue_CountText, Yellow_CountText, Purple_CountText;
    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        if (settlementBoardController == null) //獲取場景上的SettlementBoardController
            settlementBoardController = FindObjectOfType<SettlementBoardController>();

        battleGameController.Event_BattleStart += UpdateText;
        battleGameController.Event_PuzzlePlaceCompleted += UpdateText;
    }

    private void UpdateText(object sender, EventArgs e)
    {
        settlementBoardController.BillingEssencePointForBoard(out float Red, out float Blue, out float Yellow, out float Purple);
        Red_CountText.text = Red.ToString();
        Blue_CountText.text = Blue.ToString();
        Yellow_CountText.text = Yellow.ToString();
        Purple_CountText.text = Purple.ToString();
    }
}
