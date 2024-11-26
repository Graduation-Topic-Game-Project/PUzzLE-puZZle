using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorePlayerMove : MonoBehaviour
{
    static ExplorePlayerMove explorePlayerMove;
    public GameObject player;
    /// <summary>是否可以執行PlayerMove協程</summary>
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
            Debug.Log("協程進行中，玩家還在移動");
        }
    }


    private IEnumerator PlayerMove(Transform target)
    {
        float speed = 1000f; //速度
        GameObject player = explorePlayerMove.player;

        Vector3 targetPosition = target.position;

        // 當物件未到達目標位置時持續移動
        while (Vector3.Distance(player.transform.position, targetPosition) > 0.01f)
        {
            // 移動物件
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);

            // 等待下一幀
            yield return null;
        }

        // 確保最終位置精確為目標位置
        player.transform.position = targetPosition;
        isPlayerMove = false;
        Debug.Log("Reached the target position!");

        yield return null;
    }
}
