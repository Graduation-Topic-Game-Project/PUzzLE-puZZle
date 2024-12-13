using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;//<--���n

public class BattleLose : MonoBehaviour
{
    public BattleGameController battleGameController;

    public GameObject LosePlane;

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }


        LosePlane.SetActive(false);

        battleGameController.Event_EndTurn += IsLose;
    }


    private void IsLose(object sender, EventArgs e)
    {
        if (PlayerBattleData.Hp <= 0)
        {
            Lose();
        }
    }

    private void Lose()
    {
        //battleGameController.IsWin = true;
        Debug.Log("Lose");
        LosePlane.SetActive(true);
    }

    public void LoadExplore()
    {
        SceneManager.LoadScene("Main");
    }
}
