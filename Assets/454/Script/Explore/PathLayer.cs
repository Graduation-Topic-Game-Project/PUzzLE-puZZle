using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLayer : MonoBehaviour
{
    public ExploreMapController exploreMapController;

    public GameObject PathPoints; //���(PathPoint)��GameObject
    public GameObject BranchPoints; //��ø�(BranchPoint)��GameObject

    private void Awake()
    {
        if (exploreMapController == null) //��������W��ExploreMapController
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
    /// �����PathLayer����N�ӹD���I
    /// </summary>
    public PathPoint GetPathPoints(int num)
    {
        PathPoint pathPoint = PathPoints.transform.GetChild(num).GetComponent<PathPoint>();

        return pathPoint;
    }

    /// <summary>
    /// �����PathPoint����Ǫ�BranchPoint
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
