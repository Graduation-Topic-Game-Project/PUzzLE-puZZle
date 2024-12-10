using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreMapController : MonoBehaviour
{
    public ExploreInformation exploreInformation;

    public GameObject ExploreLayersGameObject; //�ƥ�hPrefab����
    public GameObject PathLayersGameObject; //�D���hPrefab����

    public ExplorePoint[,] ExplorePoints;//�����I
    public PathPoint[,] PathPoints; //�D���I

    public GameObject player;
    public (int, int) PlayerTransform; //���a��m

    /// <summary>�O�_�i���ʱ����a��</summary>
    static public bool isCanClickExploreMapUI; //�O�_�i���ʱ����a��

    private void Awake()
    {
        ExplorePoints = new ExplorePoint[exploreInformation.Layers, exploreInformation.LayerWidth]; //�����榳�|�h
        PathPoints = new PathPoint[exploreInformation.Layers - 1, exploreInformation.LayerWidth]; //�D���榳�T�h

        //Debug.Log(PlayerTransform);
    }
    private void Start()
    {
        GetAllExplorePoint(); // ����Ҧ�������üаO�y��
        GetAllPathPoint(); // ����Ҧ��D����üаO�y��
        PlayerTransform = (0, 0);
        isCanClickExploreMapUI = true;
    }

    /// <summary>
    /// ����Ҧ�������üаO�y��
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
    /// ����Ҧ��D����üаO�y��
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
