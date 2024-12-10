using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//<--���n

public class BattleWin : MonoBehaviour
{
    public BattleGameController battleGameController;

    public GameObject WinPlane;

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        battleGameController.IsWin = false;
        WinPlane.SetActive(false);

        battleGameController.Event_Win += Win;
    }

    /// <summary>
    /// �ӧQ
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
