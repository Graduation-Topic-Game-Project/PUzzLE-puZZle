using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public PuzzleData[,] puzzles = new PuzzleData[6, 7];
    public GameObject puzzlesGrids; //場景上的盤面格子父物件
    public GameObject[,] puzzlesGridGameObject = new GameObject[6, 7]; //拼圖盤面框物件，用來對生成時的位置的

    public event Func<int, int, PuzzleData, bool> Event_CheckPuzzleIsCanBePlace; //檢查拼圖是否可被放置

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        battleGameController.Event_BattleStart += this.Load_puzzlesGrids; //將場景的puzzlesGrid存進2維陣列
        battleGameController.Event_EndTurn += this.ClearBoard; //回合結束時清空盤面

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

                    nowPuzzle.ReUpdate_PuzzleEssence_Image();
                    //                                                                                         //拼圖物件生成的資料夾
                    Instantiate(nowPuzzle, puzzlesGridGameObject[i, j].transform.position, transform.rotation, puzzlesGridGameObject[i, j].transform.GetChild(1));
                }
                /*else
                    Debug.Log($"error_UpdatePuzzleBoard_puzzles[{i}, {j}] == null");*/
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

                puzzlesGridGameObject[i, j].GetComponent<PuzzleGrid>().PuzzleGridNumber[0] = i;
                puzzlesGridGameObject[i, j].GetComponent<PuzzleGrid>().PuzzleGridNumber[1] = j;

                puzzlesGridGameObject[i, j].GetComponent<PuzzleGrid>().ClickPuzzleGridBotton += this.PlacePuzzle;

                childNum++;
            }
        }
        UpdatePuzzleBoard(); //更新盤面上拼圖
    }

    /// <summary>
    /// 放置拼圖
    /// </summary>
    /// <param name="i">放置位置座標X(橫行)</param>
    /// <param name="j">放置位置座標Y(直列)</param>
    public void PlacePuzzle(int i, int j)
    {
        if (battleGameController.CanPlacePuzzle() == true) //如果目前可放置拼圖
        {
            if (Event_CheckPuzzleIsCanBePlace.Invoke(i, j, battleGameController.specifyPuzzle) == true) //檢查拼圖是否可被放置
            {
                //Debug.Log("拼圖可放置");
                puzzles[i, j] = battleGameController.specifyPuzzle;
                //Debug.Log($"已在{i}，{j}處放置{puzzles[i, j]._essence}拼圖");

                battleGameController.CallEvent_RemovePlacedPuzzle();
                UpdatePuzzleBoard();
                battleGameController.CallEvent_PlacedPuzzle(); //BattleGameController發送放置拼圖結束事件
            }
            else
            {
                Debug.Log("與周圍拼圖衝突，拼圖不可放置");
            }
        }
    }
    void ClearBoard(object sender, EventArgs e)
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                puzzles[i, j] = null;
            }
        }
        UpdatePuzzleBoard();
    }
}
