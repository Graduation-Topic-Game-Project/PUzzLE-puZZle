using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorePlayerProgress : MonoBehaviour //探索地圖玩家進度
{
    private static ExplorePlayerProgress _instance;

    public static ExplorePlayerProgress Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singleton = new GameObject();
                _instance = singleton.AddComponent<ExplorePlayerProgress>();
                singleton.name = "[Singleton] ExplorePlayerProgress";

                DontDestroyOnLoad(singleton);
            }

            return _instance;
        }
    }

    // 儲存玩家的座標 (int, int)
    public (int, int) PlayerTransform { get; private set; }

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
