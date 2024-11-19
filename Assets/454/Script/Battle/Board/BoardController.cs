using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BoardController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public PuzzleMasterController puzzleMasterController;

    public Board[,] board = new Board[PuzzleMasterController.BoardX, PuzzleMasterController.BoardY]; //盤面[6,7]
    public GameObject puzzlesGrids; //場景上的盤面格子父物件
    public GameObject[,] puzzlesGridGameObject = new GameObject[PuzzleMasterController.BoardX, PuzzleMasterController.BoardY]; //拼圖盤面框物件，用來對生成時的位置的
    public GameObject puzzleInstanceGameObject;

    public event Func<int, int, PuzzleData, bool> Event_CheckPuzzleIsCanBePlace; //檢查拼圖是否可被放置

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (puzzleMasterController == null) //獲取場景上的PuzzleSpecifyController
        {
            puzzleMasterController = FindObjectOfType<PuzzleMasterController>();
        }


        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                board[i, j] = new Board();
            }
        }

        battleGameController.Event_BattleStart += this.Load_puzzlesGrids; //將場景的puzzlesGrid存進2維陣列 && 訂閱ClickPuzzleGridBotton事件
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
                for (int childCount = 0; childCount < puzzleInstanceGameObject.transform.childCount; childCount++)
                {
                    Destroy(puzzleInstanceGameObject.transform.GetChild(childCount).gameObject);

                }
            }
        }
        // 依照Puzzles的資料，將拼圖Prefab生成到盤面上，
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (board[i, j].puzzle != null)
                {
                    //                                                                                                                                    //拼圖物件生成的資料夾
                    Puzzle nowPuzzle = Instantiate(puzzleMasterController.puzzlePrefab, puzzlesGridGameObject[i, j].transform.position, transform.rotation, puzzlesGridGameObject[i, j].transform.GetChild(1));
                    nowPuzzle.puzzleData = board[i, j].puzzle;
                    nowPuzzle.ReUpdate_PuzzleEssence_Image();


                    Puzzle nowPuzzle2 = Instantiate(puzzleMasterController.puzzlePrefab, puzzlesGridGameObject[i, j].transform.position, transform.rotation, puzzleInstanceGameObject.transform);
                    nowPuzzle2.puzzleData = board[i, j].puzzle;
                    nowPuzzle2.ReUpdate_PuzzleEssence_Image();
                    nowPuzzle2.Hide_BgImage_and_MidImage();
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

                puzzlesGridGameObject[i, j].GetComponent<PuzzleGrid>().ClickPuzzleGridBotton += this.PlacePuzzle; //訂閱按鈕的點擊事件

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
        if (puzzleMasterController.CanPlacePuzzle() == true) //如果目前可放置拼圖
        {
            Debug.Log($"PlacePuzzle座標位置{i},{j}");
            if (Event_CheckPuzzleIsCanBePlace.Invoke(i, j, puzzleMasterController.specifyPuzzle) == true) //檢查拼圖是否可被放置
            {
                board[i, j].puzzle = puzzleMasterController.specifyPuzzle;
                board[i, j].puzzle.puzzlePosition = (i, j); //更新PuzzleData內的拼圖位置
                MessageTextController.SetMessage("放置拼圖");

                puzzleMasterController.CallEvent_RemovePlacedPuzzle(); //移除備戰區那塊已經被放上去的拼圖
                puzzleMasterController.isSpecifyPuzzle = false; //取消選擇備戰區拼圖
                UpdatePuzzleBoard();
                battleGameController.CallEvent_PlacedPuzzle(); //BattleGameController發送放置拼圖結束事件
            }
        }
    }
    void ClearBoard(object sender, EventArgs e)
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                board[i, j].puzzle = null;
            }
        }
        UpdatePuzzleBoard();
    }
}
