using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploreMapController : MonoBehaviour
{
    [Header("探索關卡資料")]
    public ExploreInformation exploreInformation;

    public GameObject ExploreLayersGameObject; //事件層Prefab物件
    public GameObject PathLayersGameObject; //道路層Prefab物件

    public ExplorePoint[,] ExplorePoints;//探索點
    public PathPoint[,] PathPoints; //道路點

    public GameObject player; //玩家物件
    public (int, int) PlayerTransform; //玩家位置
    public GameObject ScrollPanel;
    public ScrollRect scrollRect;

    /// <summary>是否可互動探索地圖</summary>
    static public bool isCanClickExploreMapUI; //是否可互動探索地圖

    private void Awake()
    {
        //定義大小(x = 幾層, y = 一層有幾格)
        ExplorePoints = new ExplorePoint[exploreInformation.Layers, exploreInformation.LayerWidth]; //探索格有四層
        PathPoints = new PathPoint[exploreInformation.Layers - 1, exploreInformation.LayerWidth]; //道路格有三層

        //Debug.Log(PlayerTransform);
    }
    private void Start()
    {
        GetAllExplorePoint(); // 獲取所有探索格並標記座標
        GetAllPathPoint(); // 獲取所有道路格並標記座標

        PlayerSetProgress(); //將玩家資料位置等依儲存資料來設置

        isCanClickExploreMapUI = true;
    }

    private void Update()
    {
        ExplorePlayerProgress.Instance.SetScrollPanelTransform(ScrollPanel.transform.position);

        //ScrollRectUseSwitch();
    }

    private void PlayerSetProgress() //將玩家資料依儲存資料來設置
    {
        //將ScrollPanel的座標設定為儲存時
        Vector3 scrollPanelPosition = ScrollPanel.transform.position;
        scrollPanelPosition.x = ExplorePlayerProgress.Instance.GetScrollPanelTransform().x;
        scrollPanelPosition.y = ExplorePlayerProgress.Instance.GetScrollPanelTransform().y;
        ScrollPanel.transform.position = scrollPanelPosition;



        PlayerTransform = (ExplorePlayerProgress.Instance.GetPlayerTransform()); //玩家座標設定為儲存的座標
        Debug.Log(PlayerTransform);

        Vector3 playerGameObjectTransform = ExplorePlayerProgress.Instance.GetPlayerGameObjectPosition();
        if (playerGameObjectTransform != null && PlayerTransform != (0, 0))
        {
            player.transform.position = playerGameObjectTransform;
        }
        else
        {
            Debug.Log("回到起點");
        }


    }

    /// <summary>
    /// 獲取所有探索格並標記座標
    /// </summary>
    public void GetAllExplorePoint()
    {
        int ExplorePointTransformX = 1; //從第一層開始

        for (int i = 0; i < ExploreLayersGameObject.transform.childCount; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                ExplorePoints[i, j] = ExploreLayersGameObject.transform.GetChild(i).transform.GetChild(j).gameObject.GetComponent<ExplorePoint>();
                //Debug.Log(ExplorePoints[i, j]);
                ExplorePoints[i, j].PointTrasform = (ExplorePointTransformX, j);
                ExplorePoints[i, j].TestXY();
            }

            ExplorePointTransformX = ExplorePointTransformX + 2;
        }
    }
    /// <summary>
    /// 獲取所有道路格並標記座標
    /// </summary>
    public void GetAllPathPoint()
    {
        int PathPointTransformX = 2;

        for (int i = 0; i < PathLayersGameObject.transform.childCount; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                PathPoints[i, j] = PathLayersGameObject.transform.GetChild(i).GetComponent<PathLayer>().GetPathPoints(j);
                //PathPoints[i, j].Get
                PathPoints[i, j].PointTrasform = (PathPointTransformX, j);
                PathPoints[i, j].TestXY();
            }

            PathPointTransformX = PathPointTransformX + 2;
        }
    }

    /// <summary>
    /// ScrollRect開關
    /// </summary>
    public void ScrollRectUseSwitch()
    {
        scrollRect.enabled = isCanClickExploreMapUI;
    }
}
