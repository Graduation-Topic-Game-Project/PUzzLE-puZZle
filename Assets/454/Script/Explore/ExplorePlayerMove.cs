using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorePlayerMove : MonoBehaviour
{
    static ExplorePlayerMove explorePlayerMove;
    public GameObject player;
    /// <summary>�O�_�i�H����PlayerMove��{</summary>
    bool isPlayerMove;

    private void Awake()
    {
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

    public static void StartCoroutine_PlayerMove(Transform target)
    {

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


    private IEnumerator PlayerMove(Transform target)
    {
        float speed = 1000f; //�t��
        GameObject player = explorePlayerMove.player;

        Vector3 targetPosition = target.position;

        // ���󥼨�F�ؼЦ�m�ɫ��򲾰�
        while (Vector3.Distance(player.transform.position, targetPosition) > 0.01f)
        {
            // ���ʪ���
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);

            // ���ݤU�@�V
            yield return null;
        }

        // �T�O�̲צ�m��T���ؼЦ�m
        player.transform.position = targetPosition;
        isPlayerMove = false;
        Debug.Log("Reached the target position!");

        yield return null;
    }
}
