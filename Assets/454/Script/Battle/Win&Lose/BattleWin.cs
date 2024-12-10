using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//<--重要

public class BattleWin : MonoBehaviour
{
    public BattleGameController battleGameController;

    public GameObject WinPlane;

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        battleGameController.IsWin = false;
        WinPlane.SetActive(false);

        battleGameController.Event_Win += Win;
    }

    /// <summary>
    /// 勝利
    /// </summary>
    private void Win()
    {
        battleGameController.IsWin = true;
        Debug.Log("Win");
        WinPlane.SetActive(true);
    }

    public void LoadExplore()
    {
        SceneManager.LoadScene("Explore");
    }
}
