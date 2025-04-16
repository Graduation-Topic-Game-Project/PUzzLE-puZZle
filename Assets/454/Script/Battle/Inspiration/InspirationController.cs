using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InspirationController : MonoBehaviour
{
    public BattleGameController battleGameController;

    public int Inspiration; //靈感值
    public int defaultInspirationValue = 6; //靈感值預設值

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        battleGameController.Event_BattleStart += ResetInspiration;

        battleGameController.Event_EndTurn += Increase_Inspiration_to_ActionValue;
    }


    /// <summary> 重置靈感值</summary>
    public void ResetInspiration(object sender, EventArgs e)
    {
        Inspiration = defaultInspirationValue;
    }

    /// <summary> 依行動值增加靈感值</summary>
    public void Increase_Inspiration_to_ActionValue(object sender, EventArgs e)
    {
        Inspiration = Inspiration + ActionPoint_Controller.ActionPoint;
    }
}
