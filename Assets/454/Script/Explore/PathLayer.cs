using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLayer : MonoBehaviour
{
    public GameObject PathPoints; //放路(PathPoint)的GameObject
    public GameObject BranchPoints; //放岔路(BranchPoint)的GameObject

    /// <summary>
    /// 獲取此PathLayer的第N個道路點
    /// </summary>
    public PathPoint GetPathPoints(int num)
    {
        PathPoint pathPoint = PathPoints.transform.GetChild(num).GetComponent<PathPoint>();

        return pathPoint;
    }

}
