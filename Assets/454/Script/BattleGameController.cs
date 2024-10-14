using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class BattleGameController : MonoBehaviour
{
    public Puzzle[,] puzzles = new Puzzle[7, 6];
    public GameObject puzzlesGrids; //場景上的盤面格子父物件
    public Vector3[,] puzzlesGridTransform = new Vector3[7, 6]; //拼圖盤面框位置，用來對生成時的位置的


    public Puzzle puzzlePrefab; //預設拼圖
    public GameObject puzzleInstanceTransform; //拼圖物件生成資料夾

    public event EventHandler BattleStart;


    private void Awake()
    {

        puzzles[0, 5] = puzzlePrefab;
        puzzles[3, 3] = new Puzzle(PuzzleData.PuzzleEssence.Strengthe_力量);

        Load_puzzlesGrids();  //將場景的puzzlesGrid存進2維陣列
    }
    private void Update()
    {
        Test();
    }

    public void UpdatePuzzleField() //更新顯示盤面上拼圖
    {
        for (int i = 0; i < puzzleInstanceTransform.transform.childCount; i++)
        {   //清空舊拼圖
            Destroy(puzzleInstanceTransform.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (puzzles[i, j] != null)
                {
                    Debug.Log(puzzles[i, j]);
                    //Debug.Log(puzzlesGridTransform[i, j]);
                    Puzzle nowPuzzle = puzzles[i, j];
                    //                                                                                         //拼圖物件生成的資料夾
                    Instantiate(nowPuzzle, puzzlesGridTransform[i, j], transform.rotation, puzzleInstanceTransform.transform);
                }
            }
        }
    }
    /// <summary>
    /// 將場景的puzzlesGrid存進2維陣列
    /// </summary>
    public void Load_puzzlesGrids() //將場景的puzzlesGrid存進2維陣列
    {
        int childNum = 0;

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                puzzlesGridTransform[i, j] = puzzlesGrids.transform.GetChild(childNum).gameObject.transform.position;
                //Debug.Log(puzzlesGrids.transform.GetChild(childNum).gameObject);
                //Debug.Log(puzzlesGridGameObject[i, j]);
                childNum++;
            }
        }
        UpdatePuzzleField(); //更新盤面上拼圖
    }

    public void Test()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("test更新盤面");
            puzzles[1, 5] = puzzlePrefab;
            UpdatePuzzleField();
        }
    }
}
