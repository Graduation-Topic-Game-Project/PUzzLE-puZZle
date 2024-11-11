using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ActionPoint_Controller : MonoBehaviour
{
    public BattleGameController battleGameController;

    public TextMeshProUGUI actionPoint_Number;

    static public int ActionPoint; //行動值
    public int maxActionPoint;


    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        battleGameController.Event_PuzzlePlaceCompleted += this.PuzzlePlaceCompleted_ActionPoint; //放置拼圖後減少行動值
        battleGameController.Event_EndTurn += this.Reset_ActionPoint;
    }
    void Start()
    {
        Reset_ActionPoint(this, EventArgs.Empty); //將行動值提升至最大值
    }

    void Update()
    {
        actionPoint_Number.text = ActionPoint.ToString();
    }

    /// <summary>
    /// 放置拼圖後減少行動值
    /// </summary>
    void PuzzlePlaceCompleted_ActionPoint(object sender, EventArgs e)
    {
        ActionPoint--;
    }

    /// <summary>
    /// 將行動值回復至最大值
    /// </summary>
    private void Reset_ActionPoint(object sender, EventArgs e)
    {
        ActionPoint = maxActionPoint;
    }
}
