using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLayer : MonoBehaviour
{
    public GameObject PathPoints; //���(PathPoint)��GameObject
    public GameObject BranchPoints; //��ø�(BranchPoint)��GameObject

    /// <summary>
    /// �����PathLayer����N�ӹD���I
    /// </summary>
    public PathPoint GetPathPoints(int num)
    {
        PathPoint pathPoint = PathPoints.transform.GetChild(num).GetComponent<PathPoint>();

        return pathPoint;
    }

}
