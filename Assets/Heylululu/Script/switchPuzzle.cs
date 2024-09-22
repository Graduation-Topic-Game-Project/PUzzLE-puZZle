using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchPuzzle : MonoBehaviour
{
   public enum PuzzlePrefab
    {
        None,
        Red,
        Yellow,
        Blue, 
        Pink,
        Gray 
    }

    public PuzzlePrefab topPrefab;
    public PuzzlePrefab bottomPrefab;
    public PuzzlePrefab leftPrefab;
    public PuzzlePrefab rightPrefab;
    public PuzzlePrefab centerPrefab;

    public GameObject redPrefab;
    public GameObject yellowPrefab;
    public GameObject bluePrefab;
    public GameObject pinkPrefab;
    public GameObject grayPrefab;

    public Transform topPosition;
    public Transform bottomPosition;
    public Transform leftPosition;
    public Transform rightPosition;
    public Transform centerPosition;

    void Start()
    {
        SetPrefabAtPosition(topPrefab, topPosition);
        SetPrefabAtPosition(bottomPrefab, bottomPosition);
        SetPrefabAtPosition(leftPrefab, leftPosition);
        SetPrefabAtPosition(rightPrefab, rightPosition);
        SetPrefabAtPosition(centerPrefab, centerPosition);
    }

    void SetPrefabAtPosition(PuzzlePrefab prefabChoice, Transform position)
    {
        GameObject prefabToInstantiate = null;

        switch (prefabChoice)
        {
            case PuzzlePrefab.Red:
                prefabToInstantiate = redPrefab;
                break;
            case PuzzlePrefab.Yellow:
                prefabToInstantiate = yellowPrefab;
                break;
            case PuzzlePrefab.Blue:
                prefabToInstantiate = bluePrefab;
                break;
            case PuzzlePrefab.Pink:
                prefabToInstantiate = pinkPrefab;
                break;
            case PuzzlePrefab.Gray:
                prefabToInstantiate = grayPrefab;
                break;
        }

        if (prefabToInstantiate != null)
        {
            Instantiate(prefabToInstantiate, position.position, Quaternion.identity, position);
        }
    }
    void Update()
    {
        SetPrefabAtPosition(topPrefab, topPosition);
        SetPrefabAtPosition(bottomPrefab, bottomPosition);
        SetPrefabAtPosition(leftPrefab, leftPosition);
        SetPrefabAtPosition(rightPrefab, rightPosition);
        SetPrefabAtPosition(centerPrefab, centerPosition);
    }
}
