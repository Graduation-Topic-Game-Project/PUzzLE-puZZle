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

    // �x�s���a���y�� (int, int)
    public (int, int) PlayerTransform { get; private set; }

    // �]�w���a���y��
    public void SetPlayerTransform(int x, int y)
    {
        PlayerTransform = (x, y);
        Debug.Log($"PlayerTransform updated to: ({x}, {y})");
    }

    // ���o���a���y��
    public (int, int) GetPlayerTransform()
    {
        return PlayerTransform;
    }
}
