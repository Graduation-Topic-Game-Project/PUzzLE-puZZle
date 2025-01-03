using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorePlayerProgress : MonoBehaviour //探索地圖玩家進度
{
    public static ExplorePlayerProgress Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// 重製探索地圖存檔
    /// </summary>
    public void ResetPlayerProgress()
    {
        PlayerTransform = (0, 0);
        ScrollPanelTransform = new Vector3(0, 400, 0);
        PlayerGameObjectPosition = new Vector3(0, -400, 0);
    }

    /// <summary>
    /// 儲存玩家的座標 (int, int) (第幾行, 左邊數來第幾個)
    /// </summary>
    public (int playerTransform_x, int playerTransform_y) PlayerTransform { get; private set; }

    // 設定玩家的座標
    public void SetPlayerTransform((int, int) Transform)
    {
        PlayerTransform = (Transform);
       // Debug.Log($"PlayerTransform updated to: ({Transform})");
    }

    // 取得玩家的座標
    public (int, int) GetPlayerTransform()
    {
        return PlayerTransform;
    }

    // 儲存玩家物件位置
    public Vector3 PlayerGameObjectPosition { get; private set; }

    // 
    public void SetPlayerGameObjectPosition(Vector3 transform)
    {
        PlayerGameObjectPosition = (transform);
        Debug.Log($"PlayerGameObjectTransform updated to: ({transform})");
    }

    // 
    public Vector3 GetPlayerGameObjectPosition()
    {
        return PlayerGameObjectPosition;
    }

    // 儲存ScrollPanel位置
    public Vector3 ScrollPanelTransform { get; private set; }

    // 
    public void SetScrollPanelTransform(Vector3 transform)
    {
        ScrollPanelTransform = (transform);      
    }

    // 
    public Vector3 GetScrollPanelTransform()
    {
        return ScrollPanelTransform;
    }
}
