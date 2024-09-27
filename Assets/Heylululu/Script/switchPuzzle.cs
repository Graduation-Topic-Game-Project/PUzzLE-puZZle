using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchPuzzle : MonoBehaviour
{
    public enum PuzzlePrefab
    {
        None,
        RedGem,
        YellowGem,
        BlueGem,
        PinkGem,
        GrayGem,
        RedGroove,
        YellowGroove,
        BlueGroove,
        PinkGroove,
        GrayGroove
    }

    public PuzzlePrefab topPrefab;
    public PuzzlePrefab bottomPrefab;
    public PuzzlePrefab leftPrefab;
    public PuzzlePrefab rightPrefab;
    public PuzzlePrefab centerPrefab;

    // Gem 和 Groove 的 Prefab
    public GameObject redGemPrefab;
    public GameObject yellowGemPrefab;
    public GameObject blueGemPrefab;
    public GameObject pinkGemPrefab;
    public GameObject grayGemPrefab;

    public GameObject redGroovePrefab;
    public GameObject yellowGroovePrefab;
    public GameObject blueGroovePrefab;
    public GameObject pinkGroovePrefab;
    public GameObject grayGroovePrefab;

    private GameObject topPrefabInstance;
    private GameObject bottomPrefabInstance;
    private GameObject leftPrefabInstance;
    private GameObject rightPrefabInstance;
    private GameObject centerPrefabInstance;

    public Transform topPosition;
    public Transform bottomPosition;
    public Transform leftPosition;
    public Transform rightPosition;
    public Transform centerPosition;

    void Start()
    {
        UpdatePuzzle();
    }

    void Update()
    {
        UpdatePuzzle();
    }

    void UpdatePuzzle()
    {
        UpdatePrefabPosition(ref topPrefabInstance, topPrefab, topPosition, 180f);
        UpdatePrefabPosition(ref bottomPrefabInstance, bottomPrefab, bottomPosition, 0f);
        UpdatePrefabPosition(ref leftPrefabInstance, leftPrefab, leftPosition, 270f);
        UpdatePrefabPosition(ref rightPrefabInstance, rightPrefab, rightPosition, 90f);
        UpdatePrefabPosition(ref centerPrefabInstance, centerPrefab, centerPosition, 0f);
    }

    void UpdatePrefabPosition(ref GameObject currentPrefab, PuzzlePrefab prefabChoice, Transform position, float rotationAngle)
    {
        if (position.childCount > 0)
        {
            // 確認現有物件是否與當前選擇的 prefab 相同
            if (currentPrefab != null && prefabChoice != GetPrefabType(currentPrefab))
            {
                Destroy(currentPrefab); // 刪除舊物件
                currentPrefab = null; // 清空引用
            }
        }

        GameObject prefabToInstantiate = GetPrefabToInstantiate(prefabChoice);

        if (prefabToInstantiate != null && prefabChoice != PuzzlePrefab.None)
        {
            if (currentPrefab == null) // 如果當前沒有 prefab，則實例化
            {
                Vector3 spawnPosition = position.position; // 根據位置進行偏移
                currentPrefab = Instantiate(prefabToInstantiate, spawnPosition, Quaternion.Euler(0, 0, rotationAngle));
                currentPrefab.transform.SetParent(position); // 將新生成的物件設置為位置的子物件
                currentPrefab.transform.SetAsLastSibling(); // 確保其在拼圖的上方

                // 設置標籤
                currentPrefab.tag = prefabToInstantiate.tag; // 確保標籤與預置物件相同
            }
        }
    }

    GameObject GetPrefabToInstantiate(PuzzlePrefab prefabChoice)
    {
        switch (prefabChoice)
        {
            case PuzzlePrefab.RedGem:
                return redGemPrefab;
            case PuzzlePrefab.YellowGem:
                return yellowGemPrefab;
            case PuzzlePrefab.BlueGem:
                return blueGemPrefab;
            case PuzzlePrefab.PinkGem:
                return pinkGemPrefab;
            case PuzzlePrefab.GrayGem:
                return grayGemPrefab;
            case PuzzlePrefab.RedGroove:
                return redGroovePrefab;
            case PuzzlePrefab.YellowGroove:
                return yellowGroovePrefab;
            case PuzzlePrefab.BlueGroove:
                return blueGroovePrefab;
            case PuzzlePrefab.PinkGroove:
                return pinkGroovePrefab;
            case PuzzlePrefab.GrayGroove:
                return grayGroovePrefab;
            default:
                return null;
        }
    }

    PuzzlePrefab GetPrefabType(GameObject prefab)
    {
        // 根據標籤返回對應的預置物件類型
        switch (prefab.tag)
        {
            case "GemRed":
                return PuzzlePrefab.RedGem;
            case "GemYellow":
                return PuzzlePrefab.YellowGem;
            case "GemBlue":
                return PuzzlePrefab.BlueGem;
            case "GemPink":
                return PuzzlePrefab.PinkGem;
            case "GemGray":
                return PuzzlePrefab.GrayGem;
            case "GrooveRed":
                return PuzzlePrefab.RedGroove;
            case "GrooveYellow":
                return PuzzlePrefab.YellowGroove;
            case "GrooveBlue":
                return PuzzlePrefab.BlueGroove;
            case "GroovePink":
                return PuzzlePrefab.PinkGroove;
            case "GrooveGray":
                return PuzzlePrefab.GrayGroove;
            default:
                return PuzzlePrefab.None;
        }
    }

    void SetPrefabAtPosition(PuzzlePrefab prefabChoice, Transform position)
    {
        if (position.childCount > 0 && prefabChoice == PuzzlePrefab.None)
        {
            Destroy(position.GetChild(0).gameObject); // 如果選擇為 None，刪除現有的物件
        }
    }
}
