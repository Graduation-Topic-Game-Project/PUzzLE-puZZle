using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleLibrary : MonoBehaviour
{
    private BattleGameController battleGameController;
    private PuzzleMasterController puzzleMasterController;
    public GameObject puzzlePreparationsAllGameObject; //�����W�����ϳƾ԰Ϥ�����

    public List<PuzzleData> puzzleLibrary; //���Ϯw
    public PuzzleData[] puzzlePreparations = new PuzzleData[6]; //���ϳƾ԰�

    private GameObject[] puzzlePreparationsGameObject = new GameObject[6]; //���ϳƾ԰Ϫ���A�Ψӹ�ͦ��ɪ���m��

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


        Load_puzzlePreparationsTransform();  //����ƾ԰Ϧ�m
        Array.Clear(puzzlePreparations, 0, puzzlePreparations.Length); //�M�ųƾ԰Ϥ����ϸ��

        battleGameController.Event_BattleStart += this.Load_PuzzleLibrary_ForParther;
        battleGameController.Event_BattleStart += this.Load_All_Preparation;
        puzzleMasterController.Event_RemovePlacedPuzzle += this.RemovePlacedPuzzle;
        battleGameController.Event_PuzzlePlaceCompleted += this.ResetAllPreparationButtonColor;

        for (int i = 0; i < puzzlePreparationsGameObject.Length; i++) //�q�\�Ҧ��ƾ԰ϫ��s�ƥ�
        {
            puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>().ClickPreparationBotton += this.SpecifyPuzzle;
        }
    }

    /// <summary>
    /// ����ƾ԰Ϧ�m
    /// </summary>
    public void Load_puzzlePreparationsTransform() //����ƾ԰Ϧ�m
    {
        int PreLength = puzzlePreparationsGameObject.Length;

        for (int i = 0; i < PreLength; i++)
        {
            puzzlePreparationsGameObject[i] = puzzlePreparationsAllGameObject.transform.GetChild(i).gameObject;
            puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>().PreparationNumber = i;
        }
    }

    /// <summary>
    /// ��٦�ҫ������϶�J���Ϯw
    /// </summary>
    public void Load_PuzzleLibrary_ForParther()
    {
        for (int i = 0; i < 4; i++)
        {
            //Debug.Log($"���J��{i + 1}�ӹ٦����");
            if (battleGameController.partners[i] != null)
            {
                puzzleLibrary.AddRange(battleGameController.partners[i].thisPartner.partnersPuzzle);
                //Debug.Log($"��{i + 1}�ӹ٦���ϸ��J����");
            }
            else
            {
                //Debug.Log($"��{i + 1}�ӹ٦�null");
            }
        }
    }
    public void Load_PuzzleLibrary_ForParther(object sender, EventArgs e)
    {
        Load_PuzzleLibrary_ForParther(); //��٦�ҫ������϶�J���Ϯw
    }

    /// <summary>
    /// ��s���w�ƾ԰�(�����ñq���Ϯw��J)
    /// </summary>
    /// <param name="i">�nReLoad���ƾ԰�(0~5)</param>
    public void Load_Preparation_ForParner(int i)
    {
        if (puzzleLibrary.Count == 0)
        {
            Load_PuzzleLibrary_ForParther();
        }

        PuzzleData puzzle = puzzleLibrary[0];
        puzzlePreparations[i] = puzzle;
        puzzleLibrary.Remove(puzzle);
    }

    /// <summary>
    /// ��s���w�ƾ԰�(�������H���ͦ�)
    /// </summary>
    /// <param name="i">�nReLoad���ƾ԰�(0~5)</param>
    public void Load_Preparation_Randow(int i)
    {
        PuzzleData puzzle = new PuzzleData();
        puzzle.RandomlyGeneratedPuzzleData();
        puzzlePreparations[i] = puzzle;
    }

    /// <summary>
    /// ��s�����ƾ԰�
    /// </summary>
    public void Load_All_Preparation(object sender, EventArgs e)
    {
        int PreLength = puzzlePreparationsGameObject.Length; //�ƾ԰Ϫ���

        for (int i = 0; i < PreLength; i++)
        {
            if (puzzleMasterController.RandowOrForParnent == true)
            {
                Load_Preparation_ForParner(i);
            }
            else
            {
                Load_Preparation_Randow(i);
            }
        }
        UpdatePreparationPuzzle(this, EventArgs.Empty);
    }

    /// <summary>
    /// �b��m�Ჾ���è�s��number�ӳƾ԰�
    /// </summary>
    /// <param name="number">�n��s���ƾ԰ϬO�ĴX��</param>
    public void RemovePlacedPuzzle(int number)
    {
        //Debug.Log("RemovePlacedPuzzle");
        if (puzzleMasterController.RandowOrForParnent == true)
        {
            Load_Preparation_ForParner(number);
        }
        else
        {
            Load_Preparation_Randow(number);
        }
        UpdatePreparationPuzzle(this, EventArgs.Empty);
    }

    /// <summary>
    /// ��s����ܳƾ԰ϫ���
    /// </summary>
    public void UpdatePreparationPuzzle(object sender, EventArgs e)
    {
        int PreLength = puzzlePreparationsGameObject.Length; //�ƾ԰Ϫ���

        //�M���«���
        for (int i = 0; i < PreLength; i++)
        {
            for (int childCount = 0; childCount < puzzlePreparationsGameObject[i].transform.GetChild(1).childCount; childCount++)
            {
                Destroy(puzzlePreparationsGameObject[i].transform.GetChild(1).GetChild(childCount).gameObject);
            }
        }

        for (int i = 0; i < PreLength; i++)
        {
            if (puzzlePreparations[i] == null)
                Debug.Log("errortest_puzzlePreparations" + i);

            if (puzzlePreparationsGameObject[i] == null)
                Debug.Log("errortest_puzzlePreparationsGameObject" + i);


            //Puzzle nowPuzzle = battleGameController.puzzlePrefab;

            Puzzle nowPuzzle = Instantiate(puzzleMasterController.puzzlePrefab, puzzlePreparationsGameObject[i].transform.position, transform.rotation, puzzlePreparationsGameObject[i].transform.GetChild(1));
            nowPuzzle.puzzleData = puzzlePreparations[i];
            nowPuzzle.ReUpdate_PuzzleEssence_Image();
        }
    }

    /// <summary>
    /// ��ܳƾ԰Ϫ�����
    /// </summary>
    /// <param name="number">�ĴX�ӳƾ԰Ϯ�l</param>
    public void SpecifyPuzzle(int number)
    {
        if (puzzleMasterController.specifyPuzzleNumber != number)
        {
            ResetAllPreparationButtonColor(); //���s�Ҧ��ƾ԰ϫ��s�C�⬰�w�]
            puzzleMasterController.specifyPuzzle = puzzlePreparations[number];  //����ܪ��ƾ԰ϫ���
            puzzleMasterController.specifyPuzzleNumber = number;  // ����ܪ��ƾ԰Ͻs��(�ĴX��)
            puzzleMasterController.isSpecifyPuzzle = true;
            puzzlePreparationsGameObject[number].GetComponent<PuzzlePreparation>().SetColorForSpecifying(); //�N�I�����s�C�⬰ClickColor

            battleGameController.CallEvent_SpecifyPuzzle(); //�o�e��ܫ��Ϩƥ�
        }
        else
        {
            puzzleMasterController.specifyPuzzleNumber = -1;
            puzzleMasterController.isSpecifyPuzzle = false;
            ResetAllPreparationButtonColor(); //���s�Ҧ��ƾ԰ϫ��s�C�⬰�w�]
        }
    }

    public void ResetAllPreparationButtonColor()  //���s�Ҧ��ƾ԰ϫ��s�C�⬰�w�]
    {
        for (int i = 0; i < puzzlePreparationsGameObject.Length; i++)
        {
            puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>().ResetColor();
        }
    }
    public void ResetAllPreparationButtonColor(object sender, EventArgs e)
    {
        ResetAllPreparationButtonColor();
    }


    /*public void TestReloadPreparation()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("test��s�ƾ԰�");
            Load_All_Preparation(this, EventArgs.Empty);
        }
    }
    private void Update()
    {
        TestReloadPreparation();
    }*/
}
