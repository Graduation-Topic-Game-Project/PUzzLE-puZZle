using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleLibrary : MonoBehaviour
{
    public BattleGameController battleGameController;
    public GameObject puzzlePreparationsAllGameObject; //�����W�����ϳƾ԰Ϥ�����
    public List<PuzzleData> puzzleLibrary; //���Ϯw
    public PuzzleData[] puzzlePreparations = new PuzzleData[6]; //���ϳƾ԰�

    public Parther[] parthers = new Parther[4]; //�n�԰����٦�
    public GameObject[] puzzlePreparationsGameObject = new GameObject[6]; //���ϳƾ԰Ϫ����m�A�Ψӹ�ͦ��ɪ���m��

    private void Awake()
    {
        Load_puzzlePreparationsTransform();  //����ƾ԰Ϧ�m
        Array.Clear(puzzlePreparations, 0, 6); //����ƾ԰Ϧ�m
        battleGameController.Event_BattleStart += this.Load_PuzzleLibrary_ForParther;
        battleGameController.Event_BattleStart += this.Load_All_Preparation;
        battleGameController.Event_RemovePlacedPuzzle += this.RemovePlacedPuzzle;

        for (int i = 0; i < puzzlePreparationsGameObject.Length; i++) //�q�\�Ҧ��ƾ԰ϫ��s�ƥ�
        {
            puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>().ClickPreparationBotton += this.SpecifyPuzzle;
        }
        //battleGameController.BattleStart += UpdatePreparationPuzzle;
    }

    /// <summary>
    /// ����ƾ԰Ϧ�m
    /// </summary>
    public void Load_puzzlePreparationsTransform() //����ƾ԰Ϧ�m
    {
        //puzzlePreparationsTransform[0] = puzzlePreparations.transform.GetChild(0).gameObject.transform.position;
        for (int i = 0; i < 6; i++)
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
            if (parthers[i] != null)
            {
                puzzleLibrary.AddRange(parthers[i].thisParther.parthersPuzzle);
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
    /// ��s�����ƾ԰�
    /// </summary>
    public void Load_All_Preparation(object sender, EventArgs e)
    {
        for (int i = 0; i < 6; i++)
        {
            Load_Preparation_ForParner(i);
        }
        UpdatePreparationPuzzle(this, EventArgs.Empty);
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
    /// �b��m�Ჾ���è�s��number�ӳƾ԰�
    /// </summary>
    /// <param name="number">�n��s���ƾ԰ϬO�ĴX��</param>
    public void RemovePlacedPuzzle(int number)
    {
        Debug.Log("RemovePlacedPuzzle");
        Load_Preparation_ForParner(number);
        UpdatePreparationPuzzle(this, EventArgs.Empty);
    }

    /// <summary>
    /// ��s����ܳƾ԰ϫ���
    /// </summary>
    public void UpdatePreparationPuzzle(object sender, EventArgs e)
    {
        //�M���«���
        for (int i = 0; i < 6; i++)
        {
            for (int childCount = 0; childCount < puzzlePreparationsGameObject[i].transform.GetChild(1).childCount; childCount++)
            {
                Destroy(puzzlePreparationsGameObject[i].transform.GetChild(1).GetChild(childCount).gameObject);
            }
        }

        for (int i = 0; i < 6; i++)
        {
            if (puzzlePreparations[i] == null)
                Debug.Log("errortest_puzzlePreparations" + i);

            if (puzzlePreparationsGameObject[i] == null)
                Debug.Log("errortest_puzzlePreparationsGameObject" + i);


            Puzzle nowPuzzle = battleGameController.puzzlePrefab;
            nowPuzzle.puzzleData = puzzlePreparations[i];

            nowPuzzle.ReUpdate_PuzzleEssence_Image();
            Instantiate(nowPuzzle, puzzlePreparationsGameObject[i].transform.position, transform.rotation, puzzlePreparationsGameObject[i].transform.GetChild(1));
            //nowPuzzle.ReUpdate_PuzzleEssence_Image();
        }
    }

    /// <summary>
    /// ��ܳƾ԰Ϫ�����
    /// </summary>
    /// <param name="number">�ĴX�ӳƾ԰Ϯ�l</param>
    public void SpecifyPuzzle(int number)
    {
        battleGameController.specifyPuzzle = puzzlePreparations[number];
        battleGameController.specifyPuzzleNumber = number;
        battleGameController.isSpecifyPuzzle = true;

        for (int i = 0; i < puzzlePreparationsGameObject.Length; i++) //���s�Ҧ����s�C�⬰�w�]
        {
            puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>().ResetColor();
        }
        //puzzlePreparationsGameObject[number].GetComponent<PuzzlePreparation>().SetClickColor(); //�N�I�����s�C�⬰ClickColor
    }


    public void TestReloadPreparation()
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
    }
}
