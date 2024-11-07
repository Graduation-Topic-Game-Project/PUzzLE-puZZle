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
    }
    void Start()
    {
        ActionPoint = maxActionPoint; //�N��ʭȴ��ɦ̤ܳj��
    }

    // Update is called once per frame
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
}
