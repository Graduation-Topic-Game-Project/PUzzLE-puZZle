using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorePlayerMove : MonoBehaviour
{
    ExploreMapController exploreMapController;
    static ExplorePlayerMove explorePlayerMove;

    /// <summary>玩家是否正在移動&是否可以執行PlayerMove協程</summary>
    bool isPlayerMove;

    private void Awake()
    {
        if (exploreMapController == null) //獲取場景上的ExploreMapController
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
    /// 開始協程[玩家移動]
    /// </summary>
    /// <param name="target">移動位置</param>
    public static void StartCoroutine_PlayerMove(MapPoint target)
    {
        ExploreMapController.isCanClickExploreMapUI = false; //暫時關閉UI互動

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


    public static bool IsCanMove(MapPoint mapPoint)
    {
        (int playX, int playY) = explorePlayerMove.exploreMapController.PlayerTransform; //獲取玩家位置的X

        (int tragetX, int tragetY) = mapPoint.PointTrasform; //獲取點擊的格子的X

        if (tragetX != playX + 1)
        {
            Debug.Log("太遠了，還不能走到那裏");
            return false;
        }

        if(playX != 0 && playY != tragetY)
        {
            Debug.Log("無法通往那裏");
            return false;
        }

        return true;
    }


    private IEnumerator PlayerMove(MapPoint targetMapPoint)
    {
        float speed = 2f; //速度
        GameObject player = exploreMapController.player;

        Vector3 targetPosition = targetMapPoint.gameObject.transform.position;

        // 當物件未到達目標位置時持續移動
        while (Vector3.Distance(player.transform.position, targetPosition) > 0.01f)
        {
            // 移動物件
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null; // 等待下一幀
        }

        player.transform.position = targetPosition; // 確保最終位置精確為目標位置
        isPlayerMove = false; // 移動完畢 
        exploreMapController.PlayerTransform = targetMapPoint.PointTrasform; // 玩家位置設置為移動目標位置

        yield return new WaitForSeconds(0.5f);

        ExploreMapController.isCanClickExploreMapUI = true; //重新打開UI互動
        targetMapPoint.MapPointEvent();

        yield return null;
    }
}
