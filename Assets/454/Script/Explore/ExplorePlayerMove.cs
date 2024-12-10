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


    public static bool IsCanMove(MapPoint mapPoint)
    {
        (int playX, int playY) = explorePlayerMove.exploreMapController.PlayerTransform; //������a��m��X

        (int tragetX, int tragetY) = mapPoint.PointTrasform; //����I������l��X

        if (tragetX != playX + 1)
        {
            Debug.Log("�ӻ��F�A�٤��ਫ�쨺��");
            return false;
        }

        if(playX != 0 && playY != tragetY)
        {
            Debug.Log("�L�k�q������");
            return false;
        }

        return true;
    }


    private IEnumerator PlayerMove(MapPoint targetMapPoint)
    {
        float speed = 2f; //�t��
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

        yield return new WaitForSeconds(0.5f);

        ExploreMapController.isCanClickExploreMapUI = true; //���s���}UI����
        targetMapPoint.MapPointEvent();

        yield return null;
    }
}
