using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorePlayerProgress : MonoBehaviour
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
                singleton.name = "[Singleton] PlayerDataManager";

                DontDestroyOnLoad(singleton);
            }

            return _instance;
        }
    }

    // 儲存玩家的座標 (int, int)
    public (int, int) PlayerTransform { get; private set; }

    // 設定玩家的座標
    public void SetPlayerTransform(int x, int y)
    {
        PlayerTransform = (x, y);
        Debug.Log($"PlayerTransform updated to: ({x}, {y})");
    }

    // 取得玩家的座標
    public (int, int) GetPlayerTransform()
    {
        return PlayerTransform;
    }
}
