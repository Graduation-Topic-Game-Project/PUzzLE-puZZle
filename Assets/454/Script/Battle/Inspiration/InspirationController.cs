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
    }


    /// <summary> 重置靈感值</summary>
    public void ResetInspiration(object sender, EventArgs e)
    {
        Inspiration = defaultInspirationValue;
    }
}
