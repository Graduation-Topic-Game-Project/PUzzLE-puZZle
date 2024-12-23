using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorePlayerProgress : MonoBehaviour //�����a�Ϫ��a�i��
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

    // �x�s���a���y�� (int, int)
    public (int, int) PlayerTransform { get; private set; }

    // �]�w���a���y��
    public void SetPlayerTransform((int, int) Transform)
    {
        PlayerTransform = (Transform);
       // Debug.Log($"PlayerTransform updated to: ({Transform})");
    }

    // ���o���a���y��
    public (int, int) GetPlayerTransform()
    {
        return PlayerTransform;
    }

    // �x�s���a�����m
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
