using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//<--重要

public class ExplorePoint : MonoBehaviour
{
    private Button button;

    public ExploreType exploreType = ExploreType.Battle_戰鬥;

    public (int, int) PointTrasform;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }

    private void Click()
    {
        ExplorePlayerMove.StartCoroutine_PlayerMove(this.gameObject.transform);

        //ExplareEventJudge();
    }


    /// <summary>
    /// 依照探索點類型執行事件
    /// </summary>
    private void ExplareEventJudge()
    {
        //按鈕執行事件
        switch (exploreType)
        {
            case ExploreType.None_無:
                Debug.Log("無");
                break;
            case ExploreType.Battle_戰鬥:
                BattleEnter();
                Debug.Log("戰鬥");
                break;
            case ExploreType.Event_事件:
                Debug.Log("事件");
                break;
        }
    }

    private void BattleEnter()
    {
        SceneManager.LoadScene("Battle");
    }

    public enum ExploreType
    {
        None_無 = 0,
        Battle_戰鬥 = 1,
        Event_事件 = 2,
    }
}
