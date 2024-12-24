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

    public GameObject player; //���a����
    public (int, int) PlayerTransform; //���a��m
    public GameObject ScrollPanel;

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

        PlayerSetProgress(); //�N���a��Ʀ�m�����x�s��ƨӳ]�m

        isCanClickExploreMapUI = true;
    }

    private void Update()
    {
        ExplorePlayerProgress.Instance.SetScrollPanelTransform(ScrollPanel.transform.position);
    }

    private void PlayerSetProgress() //�N���a��ƨ��x�s��ƨӳ]�m
    {
        //�NScrollPanel���y�г]�w���x�s��
        Vector3 scrollPanelPosition = ScrollPanel.transform.position;
        scrollPanelPosition.x = ExplorePlayerProgress.Instance.GetScrollPanelTransform().x;
        scrollPanelPosition.y = ExplorePlayerProgress.Instance.GetScrollPanelTransform().y;
        ScrollPanel.transform.position = scrollPanelPosition;



        PlayerTransform = (ExplorePlayerProgress.Instance.GetPlayerTransform()); //���a�y�г]�w���x�s���y��
        Debug.Log(PlayerTransform);

        Vector3 playerGameObjectTransform = ExplorePlayerProgress.Instance.GetPlayerGameObjectPosition();
        if (playerGameObjectTransform != null && PlayerTransform != (0, 0))
        {
            player.transform.position = playerGameObjectTransform;
        }
        else
        {
            Debug.Log("�^��_�I");
        }

 
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
