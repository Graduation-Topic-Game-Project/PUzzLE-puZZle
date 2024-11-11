using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public PuzzleData[,] puzzles = new PuzzleData[6, 7];
    public GameObject puzzlesGrids; //�����W���L����l������
    public GameObject[,] puzzlesGridGameObject = new GameObject[6, 7]; //���ϽL���ت���A�Ψӹ�ͦ��ɪ���m��

    public event Func<int, int, PuzzleData, bool> Event_CheckPuzzleIsCanBePlace; //�ˬd���ϬO�_�i�Q��m

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        battleGameController.Event_BattleStart += this.Load_puzzlesGrids; //�N������puzzlesGrid�s�i2���}�C
        battleGameController.Event_EndTurn += this.ClearBoard; //�^�X�����ɲM�ŽL��

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

                    nowPuzzle.ReUpdate_PuzzleEssence_Image();
                    //                                                                                         //���Ϫ���ͦ�����Ƨ�
                    Instantiate(nowPuzzle, puzzlesGridGameObject[i, j].transform.position, transform.rotation, puzzlesGridGameObject[i, j].transform.GetChild(1));
                }
                /*else
                    Debug.Log($"error_UpdatePuzzleBoard_puzzles[{i}, {j}] == null");*/
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

                puzzlesGridGameObject[i, j].GetComponent<PuzzleGrid>().PuzzleGridNumber[0] = i;
                puzzlesGridGameObject[i, j].GetComponent<PuzzleGrid>().PuzzleGridNumber[1] = j;

                puzzlesGridGameObject[i, j].GetComponent<PuzzleGrid>().ClickPuzzleGridBotton += this.PlacePuzzle;

                childNum++;
            }
        }
        UpdatePuzzleBoard(); //��s�L���W����
    }

    /// <summary>
    /// ��m����
    /// </summary>
    /// <param name="i">��m��m�y��X(���)</param>
    /// <param name="j">��m��m�y��Y(���C)</param>
    public void PlacePuzzle(int i, int j)
    {
        if (battleGameController.CanPlacePuzzle() == true) //�p�G�ثe�i��m����
        {
            if (Event_CheckPuzzleIsCanBePlace.Invoke(i, j, battleGameController.specifyPuzzle) == true) //�ˬd���ϬO�_�i�Q��m
            {
                //Debug.Log("���ϥi��m");
                puzzles[i, j] = battleGameController.specifyPuzzle;
                //Debug.Log($"�w�b{i}�A{j}�B��m{puzzles[i, j]._essence}����");

                battleGameController.CallEvent_RemovePlacedPuzzle();
                UpdatePuzzleBoard();
                battleGameController.CallEvent_PlacedPuzzle(); //BattleGameController�o�e��m���ϵ����ƥ�
            }
            else
            {
                Debug.Log("�P�P����ϽĬ�A���Ϥ��i��m");
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
