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
            return;
        }
        if (ExplorePlayerMove.IsCanMove(this) == false)
        {           
            return;
        }
        ExplorePlayerMove.StartCoroutine_PlayerMove(this);
    }


    /// <summary>
    /// 執行探索點事件
    /// </summary>
    public virtual void MapPointEvent()
    {

    }
}
