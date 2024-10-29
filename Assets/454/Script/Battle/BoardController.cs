using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public PuzzleData[,] puzzles = new PuzzleData[6, 7];
    public GameObject puzzlesGrids; //�����W���L����l������
    public GameObject[,] puzzlesGridGameObject = new GameObject[6, 7]; //���ϽL���ئ�m�A�Ψӹ�ͦ��ɪ���m��


    
    //public GameObject puzzleInstanceTransform; //���Ϫ���ͦ���Ƨ�

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

        // Load_puzzlesGrids(this, EventArgs.Empty);  //�N������puzzlesGrid�s�i2���}�C
    }
    private void Start()
    {

    }
    public void UpdatePuzzleBoard() //��s��ܽL���W����
    {
        //�M���«���
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
                    //Debug.Log($"��ܧ�s���Ϯ�{i}�A{j}");
                    Puzzle nowPuzzle = battleGameController.puzzlePrefab;
                    nowPuzzle.puzzleData = puzzles[i, j];
                    //                                                                                         //���Ϫ���ͦ�����Ƨ�
                    Instantiate(nowPuzzle, puzzlesGridGameObject[i, j].transform.position, transform.rotation, puzzlesGridGameObject[i, j].transform.GetChild(1));
                }
            }
        }
    }

    /// <summary>
    /// �N������puzzlesGrid�s�i2���}�C
    /// </summary>
    public void Load_puzzlesGrids(object sender, EventArgs e) //�N������puzzlesGrid�s�i2���}�C
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
        UpdatePuzzleBoard(); //��s�L���W����
    }



    public void TestUpdatePuzzleBoard(object sender, EventArgs e)
    {
        Debug.Log("test��s�L��");
        puzzles[1, 5] = battleGameController.puzzlePrefab.puzzleData;
        UpdatePuzzleBoard();
    }
}
