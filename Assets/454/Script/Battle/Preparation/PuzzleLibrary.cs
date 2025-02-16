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

        battleGameController.Event_BattleStart += this.Load_PuzzleLibrary_ForParther; //��٦�ҫ������϶�J���Ϯw
        battleGameController.Event_BattleStart += this.Load_All_Preparation; //��s�����ƾ԰�
        puzzleMasterController.Event_RemovePlacedPuzzle += this.ResetAllPreparationToNoSpecifying; //���s�Ҧ��ƾ԰Ϭ��D���
        puzzleMasterController.Event_RemovePlacedPuzzle += this.RemovePlacedPuzzle; //�b��m�Ჾ���è�s��number�ӳƾ԰�
        battleGameController.Event_PuzzlePlaceCompleted += this.UpdatePreparationPuzzle; //���s�Ҧ��ƾ԰�

        for (int i = 0; i < puzzlePreparationsGameObject.Length; i++) //�q�\�Ҧ��ƾ԰ϫ��s�ƥ�
        {
            puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>().ClickPreparationBotton += this.SpecifyPuzzle;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Debug.Log("��ʨ�s�ƾ԰�");
            Load_All_Preparation(this, EventArgs.Empty);
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
                puzzleLibrary.AddRange(battleGameController.partners[i].partnerData.partnersPuzzle);
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
    /// ��s����ܥ����ƾ԰ϫ���
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

            Puzzle nowPuzzle = Instantiate(puzzleMasterController.puzzlePrefab, puzzlePreparationsGameObject[i].transform.position, transform.rotation, puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>()._puzzleInstance.transform);
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
        if (puzzleMasterController.SpecifyPuzzleNumber != number)
        {
            ResetAllPreparationToNoSpecifying(); //���s�Ҧ��ƾ԰ϫ��s�C�⬰�w�]
            puzzleMasterController.specifyPuzzle = puzzlePreparations[number];  //����ܪ��ƾ԰ϫ���           
            puzzleMasterController.SpecifyPuzzleNumber = number;  // ����ܪ��ƾ԰Ͻs��(�ĴX��)
            puzzleMasterController.isSpecifyPuzzle = true;
            puzzlePreparationsGameObject[number].GetComponent<PuzzlePreparation>().SetToSpecifying(); //�N�ƾ԰Ϥ�������ܮɪ��A

            battleGameController.CallEvent_SpecifyPuzzle(true); //�o�e��ܫ��Ϩƥ�
        }
        else
        {
            //puzzleMasterController.SpecifyPuzzleNumber = -1;
            //puzzleMasterController.isSpecifyPuzzle = false;
            ResetAllPreparationToNoSpecifying(); //���s�Ҧ��ƾ԰Ϭ��D���

            battleGameController.CallEvent_SpecifyPuzzle(false); //�o�e��ܫ��Ϩƥ�A�`�N!���ƥ�I�s�i��ɭPBug
        }
    }

    public void ResetAllPreparationToNoSpecifying()  //���s�Ҧ��ƾ԰Ϭ��D���
    {
        puzzleMasterController.SpecifyPuzzleNumber = -1;
        puzzleMasterController.isSpecifyPuzzle = false;

        for (int i = 0; i < puzzlePreparationsGameObject.Length; i++)
        {
            puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>().ResetToNoSpecifying();
        }
    }
    public void ResetAllPreparationToNoSpecifying(object sender, EventArgs e)
    {
        ResetAllPreparationToNoSpecifying();
    }

    /// <param name="noUse">�S���γB�A�u�O���F�ŦX�ƥ�榡</param>
    public void ResetAllPreparationToNoSpecifying(int noUse)
    {
        ResetAllPreparationToNoSpecifying();
    }
}
