using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BoardController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public PuzzleData[,] puzzles = new PuzzleData[6, 7];
    public GameObject puzzlesGrids; //�����W���L����l������
    public GameObject[,] puzzlesGridGameObject = new GameObject[6, 7]; //���ϽL���ت���A�Ψӹ�ͦ��ɪ���m��
    public GameObject puzzleInstanceGameObject;

    public event Func<int, int, PuzzleData, bool> Event_CheckPuzzleIsCanBePlace; //�ˬd���ϬO�_�i�Q��m

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        battleGameController.Event_BattleStart += this.Load_puzzlesGrids; //�N������puzzlesGrid�s�i2���}�C && �q�\ClickPuzzleGridBotton�ƥ�
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
                for (int childCount = 0; childCount < puzzleInstanceGameObject.transform.childCount; childCount++)
                {
                    Destroy(puzzleInstanceGameObject.transform.GetChild(childCount).gameObject);

                }

            }
        }

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (puzzles[i, j] != null)
                {
                    //                                                                                                                                    //���Ϫ���ͦ�����Ƨ�
                    Puzzle nowPuzzle = Instantiate(battleGameController.puzzlePrefab, puzzlesGridGameObject[i, j].transform.position, transform.rotation, puzzlesGridGameObject[i, j].transform.GetChild(1));
                    nowPuzzle.puzzleData = puzzles[i, j];
                    nowPuzzle.ReUpdate_PuzzleEssence_Image();


                    Puzzle nowPuzzle2 = Instantiate(battleGameController.puzzlePrefab, puzzlesGridGameObject[i, j].transform.position, transform.rotation, puzzleInstanceGameObject.transform);
                    nowPuzzle2.puzzleData = puzzles[i, j];
                    nowPuzzle2.ReUpdate_PuzzleEssence_Image();
                    nowPuzzle2.Hide_BgImage_and_MidImage();
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
                puzzles[i, j] = battleGameController.specifyPuzzle;
                MessageTextController.SetMessage("��m����");

                battleGameController.CallEvent_RemovePlacedPuzzle(); //�����ƾ԰Ϩ����w�g�Q��W�h������
                battleGameController.isSpecifyPuzzle = false; //������ܳƾ԰ϫ���
                UpdatePuzzleBoard();
                battleGameController.CallEvent_PlacedPuzzle(); //BattleGameController�o�e��m���ϵ����ƥ�
            }
            else
            {
                MessageTextController.SetMessage("�P�P����ϽĬ�A���Ϥ��i��m");
                //Debug.Log("�P�P����ϽĬ�A���Ϥ��i��m");
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
