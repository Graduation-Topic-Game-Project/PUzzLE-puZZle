using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InspirationController : MonoBehaviour
{
    public BattleGameController battleGameController;

    public int Inspiration; //�F�P��
    public int defaultInspirationValue = 6; //�F�P�ȹw�]��

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        battleGameController.Event_BattleStart += ResetInspiration;
    }


    /// <summary> ���m�F�P��</summary>
    public void ResetInspiration(object sender, EventArgs e)
    {
        Inspiration = defaultInspirationValue;
    }
}
