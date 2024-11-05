using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PuzzleGrid : MonoBehaviour
{
    BattleGameController battleGameController;
    [SerializeField]
    private int[] _puzzleGridNumber = new int[2]; //第幾個備戰區，第一個數字為X，第二個數字為Y，

    public event Action<int,int> ClickPuzzleGridBotton;
    private Button button;


    public int[] PuzzleGridNumber { get => _puzzleGridNumber; set { _puzzleGridNumber = value; } }
    public int PuzzleGridNumberX { get => _puzzleGridNumber[0]; set { _puzzleGridNumber[0] = value; } }
    public int PuzzleGridNumberY { get => _puzzleGridNumber[1]; set { _puzzleGridNumber[1] = value; } }

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        button = GetComponent<Button>();
        button.onClick.AddListener(ClickPuzzleGrid);
    }

    private void ClickPuzzleGrid()
    {
        //Debug.Log("ClickPuzzleGrid");
        ClickPuzzleGridBotton?.Invoke(_puzzleGridNumber[0], _puzzleGridNumber[1]);
    }

}
