using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorePlayerMove : MonoBehaviour
{
    ExploreMapController exploreMapController;
    static ExplorePlayerMove explorePlayerMove;

    /// <summary>���a�O�_���b����&�O�_�i�H����PlayerMove��{</summary>
    bool isPlayerMove;

    private void Awake()
    {
        if (exploreMapController == null) //��������W��ExploreMapController
        {
            exploreMapController = FindObjectOfType<ExploreMapController>();
        }

        if (explorePlayerMove == null)
        {
            explorePlayerMove = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        isPlayerMove = false;
    }

    /// <summary>
    /// �}�l��{[���a����]
    /// </summary>
    /// <param name="target">���ʦ�m</param>
    public static void StartCoroutine_PlayerMove(MapPoint target)
    {
        ExploreMapController.isCanClickExploreMapUI = false; //�Ȯ�����UI����


        if (explorePlayerMove.isPlayerMove != true)
        {
            explorePlayerMove.StartCoroutine(explorePlayerMove.PlayerMove(target));
            explorePlayerMove.isPlayerMove = true;
        }
        else
        {
            Debug.Log("��{�i�椤�A���a�٦b����");
        }
    }


    public static bool IsCanMove(MapPoint tragetPoint)
    {
        (int playX, int playY) = explorePlayerMove.exploreMapController.PlayerTransform; //������a��m��X

        (int tragetX, int tragetY) = tragetPoint.PointTrasform; //����I������l��X

        if (tragetX > playX + 1)
        {
            Debug.Log("�ӻ��F�A�٤��ਫ�쨺��");
            return false;
        }
        if (tragetX < playX)
        {
            Debug.Log("�L�k�^�Y");
            return false;
        }

        if (playX == 0 && tragetX == 1)
        {
            Debug.Log("�q�_�I�X�o");
            return true;
        }

        if (playX != 0 && playY != tragetY && playX != tragetX)
        {
            Debug.Log("�L�k�q������");
            return false;
        }

        if (playY == tragetY && playX + 1 == tragetX) //���e����@��
        {
            Debug.Log("����@��test");
            return true;
        }

        PathPoint tragetPathPoint = tragetPoint.GetComponent<PathPoint>();

        if (tragetPathPoint != null && playX == tragetX)
        {
            if (playY < tragetY && tragetPathPoint.BranchPoint_L != null)
            {
                tragetPathPoint.BranchPoint_L.GetComponent<BranchPoint>().isHaveRoad = true; //�Y�ؼЪ����ø����q
                Debug.Log("�ø��V�k");
                return true;
            }
            if (playY > tragetY && tragetPathPoint.BranchPoint_R != null)
            {
                tragetPathPoint.BranchPoint_R.GetComponent<BranchPoint>().isHaveRoad = true;
                Debug.Log("�ø��V��");
                return true;
            }

            Debug.Log("�ø�test");
            return false;
        }


        Debug.Log("PlayerIsCanMoveMove��Ltest");
        return true;
    }


    private IEnumerator PlayerMove(MapPoint targetMapPoint)
    {
        exploreMapController.scrollRect.enabled = false;//�Ȯ�����scrollRect����

        float speed = 3f; //�t��
        GameObject player = exploreMapController.player;

        Vector3 targetPosition = targetMapPoint.gameObject.transform.position;

        // ���󥼨�F�ؼЦ�m�ɫ��򲾰�
        while (Vector3.Distance(player.transform.position, targetPosition) > 0.01f)
        {
            // ���ʪ���
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null; // ���ݤU�@�V
        }

        player.transform.position = targetPosition; // �T�O�̲צ�m��T���ؼЦ�m
        isPlayerMove = false; // ���ʧ��� 
        exploreMapController.PlayerTransform = targetMapPoint.PointTrasform; // ���a��m�]�m�����ʥؼЦ�m

        exploreMapController.scrollRect.enabled = true; //���s���}scrollRect����

        yield return new WaitForSeconds(0.2f);

        ExploreMapController.isCanClickExploreMapUI = true; //���s���}UI����
        targetMapPoint.MapPointEvent();

        yield return null;
    }
}
