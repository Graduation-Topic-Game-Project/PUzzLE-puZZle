using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public PuzzleData[,] puzzles = new PuzzleData[6, 7];
    public GameObject puzzlesGrids; //場景上的盤面格子父物件
    public GameObject[,] puzzlesGridGameObject = new GameObject[6, 7]; //拼圖盤面框位置，用來對生成時的位置的


    
    //public GameObject puzzleInstanceTransform; //拼圖物件生成資料夾

    private void Awake()
    {
        if (battleGameController == null)
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }


        puzzles[0, 5] = battleGameController.puzzlePrefab.GetComponent<Puzzle>().puzzleData;
        puzzles[3, 3] = new PuzzleData();

        battleGameController.BattleStart += this.Load_puzzlesGrids;
        battleGameController.TestUpdatePuzzleBoard += this.TestUpdatePuzzleBoard;

        // Load_puzzlesGrids(this, EventArgs.Empty);  //將場景的puzzlesGrid存進2維陣列
    }
    private void Start()
    {

    }
    public void UpdatePuzzleBoard() //更新顯示盤面上拼圖
    {
        //清空舊拼圖
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                for (int childCount = 0; childCount < puzzlesGridGameObject[i, j].transform.GetChild(1).childCount; childCount++)
                {
                    Destroy(puzzlesGridGameObject[i, j].transform.GetChild(1).GetChild(childCount).gameObject);
                }
            }
        }

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (puzzles[i, j] != null)
                {
                    //Debug.Log($"顯示更新拼圖格{i}，{j}");
                    Puzzle nowPuzzle = battleGameController.puzzlePrefab;
                    nowPuzzle.puzzleData = puzzles[i, j];
                    //                                                                                         //拼圖物件生成的資料夾
                    Instantiate(nowPuzzle, puzzlesGridGameObject[i, j].transform.position, transform.rotation, puzzlesGridGameObject[i, j].transform.GetChild(1));
                }
            }
        }
    }

    /// <summary>
    /// 將場景的puzzlesGrid存進2維陣列
    /// </summary>
    public void Load_puzzlesGrids(object sender, EventArgs e) //將場景的puzzlesGrid存進2維陣列
    {
        int childNum = 0;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                puzzlesGridGameObject[i, j] = puzzlesGrids.transform.GetChild(childNum).gameObject;
                //Debug.Log(puzzlesGrids.transform.GetChild(childNum).gameObject);
                //Debug.Log(puzzlesGridGameObject[i, j]);
                childNum++;
            }
        }
        UpdatePuzzleBoard(); //更新盤面上拼圖
    }



    public void TestUpdatePuzzleBoard(object sender, EventArgs e)
    {
        Debug.Log("test更新盤面");
        puzzles[1, 5] = battleGameController.puzzlePrefab.puzzleData;
        UpdatePuzzleBoard();
    }
}
