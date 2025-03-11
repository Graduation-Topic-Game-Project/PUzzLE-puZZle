using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLayer : MonoBehaviour
{
    public ExploreMapController exploreMapController;

    public GameObject PathPoints; //放路(PathPoint)的GameObject
    public GameObject BranchPoints; //放岔路(BranchPoint)的GameObject

    private void Awake()
    {
        if (exploreMapController == null) //獲取場景上的ExploreMapController
        {
            exploreMapController = FindObjectOfType<ExploreMapController>();
        }

        for (int i = 0; i <= exploreMapController.exploreInformation.LayerWidth - 1; i++)
        {
            PathPoint pathPoint = GetPathPoints(i);
            GetNeighborhoodBranchPoints(pathPoint, i);
        }
    }

    /// <summary>
    /// 獲取此PathLayer的第N個道路點
    /// </summary>
    public PathPoint GetPathPoints(int num)
    {
        PathPoint pathPoint = PathPoints.transform.GetChild(num).GetComponent<PathPoint>();

        return pathPoint;
    }

    /// <summary>
    /// 獲取此PathPoint的兩旁的BranchPoint
    /// </summary>
    public void GetNeighborhoodBranchPoints(PathPoint pathPoint, int num)
    {
        if (num - 1 >= 0)
        {
            pathPoint.BranchPoint_L = BranchPoints.transform.GetChild(num - 1).GetComponent<BranchPoint>();
        }

        if (num < exploreMapController.exploreInformation.LayerWidth - 1)
            pathPoint.BranchPoint_R = BranchPoints.transform.GetChild(num).GetComponent<BranchPoint>();
    }

}
