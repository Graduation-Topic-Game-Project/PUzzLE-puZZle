using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPoint : MonoBehaviour
{
    private Button button;

    public (int, int) PointTrasform;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }

    protected virtual void Click()
    {
        if(ExploreMapController.isCanClickExploreMapUI == false)
        {
            Debug.Log("UI互動關閉中");
            return;
        }
        if (ExplorePlayerMove.IsCanMove(this) == false)
        {           
            return;
        }
        ExplorePlayerMove.StartCoroutine_PlayerMove(this);
        Debug.Log(PointTrasform);
    }


    /// <summary>
    /// 執行探索點事件
    /// </summary>
    public virtual void MapPointEvent()
    {

    }
}
