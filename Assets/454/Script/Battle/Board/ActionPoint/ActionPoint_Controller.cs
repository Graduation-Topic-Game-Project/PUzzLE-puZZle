using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ActionPoint_Controller : MonoBehaviour
{
    public BattleGameController battleGameController;


    [SerializeField]
    static public int ActionPoint; //��ʭ�
    public int maxActionPoint; //�̤j��ʭ�







    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        battleGameController.Event_PuzzlePlaceCompleted += this.PuzzlePlaceCompleted_ActionPoint; //��m���ϫ��֦�ʭ�
        battleGameController.Event_StartTurn += this.Reset_ActionPoint; //�^�X�}�l���s��ʭ�
        Reset_ActionPoint(this, EventArgs.Empty); //�N��ʭȴ��ɦ̤ܳj��

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
