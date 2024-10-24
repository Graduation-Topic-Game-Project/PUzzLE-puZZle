using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public Puzzle[,] puzzles = new Puzzle[6, 7];
    public GameObject puzzlesGrids; //�����W���L����l������
    public GameObject[,] puzzlesGridGameObject = new GameObject[6, 7]; //���ϽL���ئ�m�A�Ψӹ�ͦ��ɪ���m��


    public Puzzle puzzlePrefab; //�w�]����
    //public GameObject puzzleInstanceTransform; //���Ϫ���ͦ���Ƨ�

    private void Awake()
    {
        puzzles[0, 5] = puzzlePrefab;
        puzzles[3, 3] = new Puzzle(PuzzleData.PuzzleEssence.Strengthe_�O�q);

        battleGameController.BattleAwake += this.Load_puzzlesGrids;
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
                    Debug.Log(puzzles[i, j]);
                    //Debug.Log(puzzlesGridTransform[i, j]);
                    Puzzle nowPuzzle = puzzles[i, j];
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
        puzzles[1, 5] = puzzlePrefab;
        UpdatePuzzleBoard();
    }
}
