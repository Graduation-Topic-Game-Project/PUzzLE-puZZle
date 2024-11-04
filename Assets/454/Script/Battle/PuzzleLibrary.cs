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
        Array.Clear(puzzlePreparations, 0, 6);
        battleGameController.BattleStart += this.Load_PuzzleLibrary_ForParther;
        battleGameController.BattleStart += this.Load_All_Preparation;

        for (int i = 0; i < puzzlePreparationsGameObject.Length; i++)
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
            puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>().number = i;
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
            Load_Preparation(i);
        }
    }

    /// <summary>
    /// ��s���w�ƾ԰�(�����ñq���Ϯw��J)
    /// </summary>
    /// <param name="i">�nReLoad���ƾ԰�(0~5)</param>
    public void Load_Preparation(int i)
    {
        if (puzzleLibrary.Count == 0)
        {
            Load_PuzzleLibrary_ForParther();
        }

        PuzzleData puzzle = puzzleLibrary[0];
        puzzlePreparations[i] = puzzle;
        puzzleLibrary.Remove(puzzle);

        UpdatePreparationPuzzle(this, EventArgs.Empty);
        UpdatePreparationPuzzle(this, EventArgs.Empty);
        //UpdatePreparationPuzzle(this, EventArgs.Empty);
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
            if (puzzlePreparations[i] == null || puzzlePreparationsGameObject[i] == null)
            {
                Debug.Log("errortest");
            }

            Puzzle nowPuzzle = battleGameController.puzzlePrefab;
            nowPuzzle.puzzleData = puzzlePreparations[i];

            nowPuzzle.ReUpdate_PuzzleEssence_Image();
            Instantiate(nowPuzzle, puzzlePreparationsGameObject[i].transform.position, transform.rotation, puzzlePreparationsGameObject[i].transform.GetChild(1));
            //nowPuzzle.ReUpdate_PuzzleEssence_Image();
        }
    }

    public void SpecifyPuzzle(int number)
    {
        battleGameController.specifyPuzzle = puzzlePreparations[number];
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
