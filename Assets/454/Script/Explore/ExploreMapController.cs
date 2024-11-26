using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreMapController : MonoBehaviour
{
    public GameObject ExploreLayersGameObject;
    public GameObject PathLayersGameObject;

    public ExplorePoint[,] ExplorePoints = new ExplorePoint[4, 3];
    public PathPoint[,] PathPoints = new PathPoint[3, 3];


    private void Start()
    {
        int ExplorePointTransformX = 1;

        for (int i = 0; i < ExploreLayersGameObject.transform.childCount; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                ExplorePoints[i, j] = ExploreLayersGameObject.transform.GetChild(i).transform.GetChild(j).gameObject.GetComponent<ExplorePoint>();
                Debug.Log(ExplorePoints[i, j]);
                ExplorePoints[i, j].PointTrasform = (ExplorePointTransformX, j);
            }

            ExplorePointTransformX = ExplorePointTransformX + 2;
        }

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
