using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorePlayerProgress : MonoBehaviour //�����a�Ϫ��a�i��
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

    public void ResetPlayerProgress()
    {
        
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

    // �x�sScrollPanel��m
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
