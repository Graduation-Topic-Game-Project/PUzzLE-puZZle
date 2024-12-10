using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreMapController : MonoBehaviour
{
    public ExploreInformation exploreInformation;

    public GameObject ExploreLayersGameObject; //事件層Prefab物件
    public GameObject PathLayersGameObject; //道路層Prefab物件

    public ExplorePoint[,] ExplorePoints;//探索點
    public PathPoint[,] PathPoints; //道路點

    public GameObject player;
    public (int, int) PlayerTransform; //玩家位置

    /// <summary>是否可互動探索地圖</summary>
    static public bool isCanClickExploreMapUI; //是否可互動探索地圖

    private void Awake()
    {
        ExplorePoints = new ExplorePoint[exploreInformation.Layers, exploreInformation.LayerWidth]; //探索格有四層
        PathPoints = new PathPoint[exploreInformation.Layers - 1, exploreInformation.LayerWidth]; //道路格有三層

        //Debug.Log(PlayerTransform);
    }
    private void Start()
    {
        GetAllExplorePoint(); // 獲取所有探索格並標記座標
        GetAllPathPoint(); // 獲取所有道路格並標記座標
        PlayerTransform = (0, 0);
        isCanClickExploreMapUI = true;
    }

    /// <summary>
    /// 獲取所有探索格並標記座標
    /// </summary>
    public void GetAllExplorePoint()
    {
        int ExplorePointTransformX = 1;

        for (int i = 0; i < ExploreLayersGameObject.transform.childCount; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                ExplorePoints[i, j] = ExploreLayersGameObject.transform.GetChild(i).transform.GetChild(j).gameObject.GetComponent<ExplorePoint>();
                //Debug.Log(ExplorePoints[i, j]);
                ExplorePoints[i, j].PointTrasform = (ExplorePointTransformX, j);
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
                PathPoints[i, j].PointTrasform = (PathPointTransformX, j);
            }

            PathPointTransformX = PathPointTransformX + 2;
        }
    }
}
