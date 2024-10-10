using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGameController : MonoBehaviour
{
    public Puzzle[,] puzzles = new Puzzle[7, 6];
    public GameObject puzzlesGrids; //場景上的
    public GameObject[,] puzzlesGridGameObject = new GameObject[7, 6];
    public Puzzle puzzlePrefab;
    public GameObject puzzleInstanceTransform; //拼圖物件生成資料夾


    private void Start()
    {
        puzzles[0, 5] = puzzlePrefab;
        Load_puzzlesGrids();
        //Debug.Log(puzzlesGridGameObject[0, 5]);
        UpdatePuzzleDisk();

    }

    public void UpdatePuzzleDisk() //更新盤面上拼圖
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (puzzles[i, j] != null)
                {
                    Debug.Log(puzzles[i, j]);
                    Debug.Log(puzzlesGridGameObject[i, j]);
                    Puzzle nowPuzzle = puzzles[i, j];
                    //                                                                                         //拼圖物件生成的資料夾
                    Instantiate(nowPuzzle, puzzlesGridGameObject[i, j].transform.position, transform.rotation, puzzleInstanceTransform.transform);
                }
            }
        }
    }
    public void Load_puzzlesGrids() //將場景的puzzlesGrid存進2維陣列
    {
        int childNum = 0;

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {

                if (puzzlesGridGameObject[i, j] == null)
                {
                    puzzlesGridGameObject[i, j] = puzzlesGrids.transform.GetChild(childNum).gameObject;
                    //Debug.Log(puzzlesGrids.transform.GetChild(childNum).gameObject);
                    Debug.Log(puzzlesGridGameObject[i, j]);
                    childNum++;
                }
            }
        }
        //UpdatePuzzleDisk(); //更新盤面上拼圖
    }
}
