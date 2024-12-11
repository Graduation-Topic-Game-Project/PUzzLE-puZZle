using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BoardController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public PuzzleMasterController puzzleMasterController;

    public Board[,] board = new Board[PuzzleMasterController.BoardX, PuzzleMasterController.BoardY]; //�L��[6,7]
    public GameObject puzzlesGrids; //�����W���L����l������
    public GameObject[,] puzzlesGridGameObject = new GameObject[PuzzleMasterController.BoardX, PuzzleMasterController.BoardY]; //���ϽL���ت���A�Ψӹ�ͦ��ɪ���m��
    public GameObject puzzleInstanceGameObject; //���ϥͦ���m
    public GameObject puzzleSideInstanceGameObject; //���ϥd�g�ͦ���m

    public event Func<int, int, PuzzleData, bool> Event_CheckPuzzleIsCanBePlace; //�ˬd���ϬO�_�i�Q��m
    public event Action<int, int> Event_CheckPuzzleLinkage; //�ˬd���ϳs��
    //public static event Func<PuzzleData, bool> Event_CheckEnemyPuzzleAround; //�ˬd�Ĥ���ϬO�_�]��


    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (puzzleMasterController == null) //��������W��PuzzleSpecifyController
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

        battleGameController.Event_BattleStart += this.Load_puzzlesGrids; //�N������puzzlesGrid�s�i2���}�C && �q�\ClickPuzzleGridBotton�ƥ�
        battleGameController.Event_EndTurn += this.ClearBoard; //�^�X�����ɲM�ŽL��
    }

    public void UpdatePuzzleBoard() //��s��ܽL���W����
    {
        foreach (Transform child in puzzleInstanceGameObject.transform)
        {         
            Destroy(child.gameObject);
        }

        //�M���«���
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                for (int childCount = 0; childCount < puzzlesGridGameObject[i, j].transform.GetChild(1).childCount; childCount++)
                {
                    Destroy(puzzlesGridGameObject[i, j].transform.GetChild(1).GetChild(childCount).gameObject);
                }
                for (int childCount = 0; childCount < puzzleSideInstanceGameObject.transform.childCount; childCount++)
                {
                    Destroy(puzzleSideInstanceGameObject.transform.GetChild(childCount).gameObject);
                }
            }
        }
        // �̷�Puzzles����ơA�N����Prefab�ͦ���L���W�A
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (board[i, j].Puzzle != null)
                {
                    switch (board[i, j].Puzzle.Type)
                    {
                        case PuzzleData.PuzzleType.Puzzle_���q����: //���q���ϡA���q�ͦ�
                            InstantiatePuzzle(i, j);
                            break;
                        case PuzzleData.PuzzleType.EnemyPuzzle_�Ĥ����:
                            InstantiateEnemyPuzzle(i, j);
                            break;
                        default://�H�W�����ŦX���o��
                            Debug.Log("���~�Apuzzle�����٦����");
                            break;
                    }
                }
            }
        }
    }

    /// <summary>��Ҥƫ���(���)</summary>
    void InstantiatePuzzle(int i, int j)
    {
        //                                                                                                                                    //���Ϫ���ͦ�����Ƨ�
        Puzzle nowPuzzle = Instantiate(puzzleMasterController.puzzlePrefab, puzzlesGridGameObject[i, j].transform.position, transform.rotation, puzzleInstanceGameObject.transform);
        nowPuzzle.puzzleData = board[i, j].Puzzle;
        nowPuzzle.ReUpdate_PuzzleEssence_Image();

        //�ͦ��u���d�g������Prefab�b�t�@��
        Puzzle nowPuzzleSide = Instantiate(puzzleMasterController.puzzlePrefab, puzzlesGridGameObject[i, j].transform.position, transform.rotation, puzzleSideInstanceGameObject.transform);
        nowPuzzleSide.puzzleData = board[i, j].Puzzle;
        nowPuzzleSide.ReUpdate_PuzzleEssence_Image();
        nowPuzzleSide.Hide_BgImage_and_MidImage();
    }

    /// <summary>��ҤƼĤ����(���)</summary>
    void InstantiateEnemyPuzzle(int i, int j)
    {
        //                                                                                                                                    //���Ϫ���ͦ�����Ƨ�
        EnemyPuzzle nowPuzzle = Instantiate(puzzleMasterController.EnemyPuzzlePrefab, puzzlesGridGameObject[i, j].transform.position, transform.rotation, puzzleInstanceGameObject.transform);
        nowPuzzle.puzzleData = board[i, j].Puzzle;
        nowPuzzle.ReUpdate_PuzzleEssence_Image();
        EnemyPuzzleSkill enemyPuzzleSkill = nowPuzzle.GetComponent<EnemyPuzzleSkill>();
        enemyPuzzleSkill.enabled = false;

        //�ͦ��u���d�g������Prefab�b�t�@��
        Puzzle nowPuzzleSide = Instantiate(puzzleMasterController.puzzlePrefab, puzzlesGridGameObject[i, j].transform.position, transform.rotation, puzzleSideInstanceGameObject.transform);
        nowPuzzleSide.puzzleData = board[i, j].Puzzle;
        nowPuzzleSide.ReUpdate_PuzzleEssence_Image();
        nowPuzzleSide.Hide_BgImage_and_MidImage();
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

                puzzlesGridGameObject[i, j].GetComponent<PuzzleGrid>().ClickPuzzleGridBotton += this.PlacePuzzle; //�q�\���s���I���ƥ�

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
        if (puzzleMasterController.CanPlacePuzzle() == true) //�p�G�ثe�i��m����
        {

            if (Event_CheckPuzzleIsCanBePlace?.Invoke(i, j, puzzleMasterController.specifyPuzzle) == true) //�ˬd���ϬO�_�i�Q��m
            {
                board[i, j].Puzzle = puzzleMasterController.specifyPuzzle;
                board[i, j].Puzzle.puzzlePosition = (i, j); //��sPuzzleData�������Ϯy��
                MessageTextController.SetMessage("��m����");

                Event_CheckPuzzleLinkage?.Invoke(i, j);

                puzzleMasterController.CallEvent_RemovePlacedPuzzle(); //�����ƾ԰Ϩ����w�g�Q��W�h������
                puzzleMasterController.isSpecifyPuzzle = false; //������ܳƾ԰ϫ���
                puzzleMasterController.specifyPuzzleNumber = -1; 
                UpdatePuzzleBoard();
                battleGameController.CallEvent_PlacedPuzzle(); //BattleGameController�o�e��m���ϵ����ƥ�
            }
        }
    }


    void ClearBoard(object sender, EventArgs e)
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                board[i, j].Puzzle = null;
            }
        }
        UpdatePuzzleBoard();
    }
}
