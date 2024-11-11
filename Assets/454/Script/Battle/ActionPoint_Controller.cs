using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ActionPoint_Controller : MonoBehaviour
{
    public BattleGameController battleGameController;

    public TextMeshProUGUI actionPoint_Number;

    static public int ActionPoint; //��ʭ�
    public int maxActionPoint;


    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        battleGameController.Event_PuzzlePlaceCompleted += this.PuzzlePlaceCompleted_ActionPoint; //��m���ϫ��֦�ʭ�
        battleGameController.Event_EndTurn += this.Reset_ActionPoint;
    }
    void Start()
    {
        Reset_ActionPoint(this, EventArgs.Empty); //�N��ʭȴ��ɦ̤ܳj��
    }

    void Update()
    {
        actionPoint_Number.text = ActionPoint.ToString();
    }

    /// <summary>
    /// ��m���ϫ��֦�ʭ�
    /// </summary>
    void PuzzlePlaceCompleted_ActionPoint(object sender, EventArgs e)
    {
        ActionPoint--;
    }

    /// <summary>
    /// �N��ʭȦ^�_�̤ܳj��
    /// </summary>
    private void Reset_ActionPoint(object sender, EventArgs e)
    {
        ActionPoint = maxActionPoint;
    }
}
