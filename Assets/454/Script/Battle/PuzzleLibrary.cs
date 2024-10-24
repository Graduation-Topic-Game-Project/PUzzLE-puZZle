using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleLibrary : MonoBehaviour
{
    public BattleGameController battleGameController;
    public List<PuzzleData> puzzleLibrary; //���Ϯw
    public PuzzleData[] puzzlePreparations = new PuzzleData[6]; //���ϳƾ԰�

    public Parther[] parthers = new Parther[4]; //�n�԰����٦�
    public GameObject puzzlePreparationsGameObject; //�����W�����ϳƾ԰Ϥ�����
    public Vector3[] puzzlePreparationsTransform = new Vector3[6]; //���ϳƾ԰Ϫ����m�A�Ψӹ�ͦ��ɪ���m��

    private void Awake()
    {
        Load_puzzlePreparations();  //����ƾ԰Ϧ�m
        Array.Clear(puzzlePreparations, 0, 6);
        battleGameController.BattleStart += this.Load_PuzzleLibrary;
        battleGameController.BattleStart += this.Load_All_Preparation;
    }


    /// <summary>
    /// ����ƾ԰Ϧ�m
    /// </summary>
    public void Load_puzzlePreparations() //����ƾ԰Ϧ�m
    {
        //puzzlePreparationsTransform[0] = puzzlePreparations.transform.GetChild(0).gameObject.transform.position;
        for (int i = 0; i < 6; i++)
        {
            puzzlePreparationsTransform[i] = puzzlePreparationsGameObject.transform.GetChild(i).gameObject.transform.position;
        }
    }

    /// <summary>
    /// ��٦�ҫ������϶�J���Ϯw
    /// </summary>
    public void Load_PuzzleLibrary()
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log($"���J��{i + 1}�ӹ٦����");
            if (parthers[i] != null)
            {
                puzzleLibrary.AddRange(parthers[i].thisParther.parthersPuzzle);
                //parthers[i].thisParther.parthersPuzzle.
                Debug.Log($"��{i + 1}�ӹ٦���ϸ��J����");
            }
            else
                Debug.Log($"��{i + 1}�ӹ٦�null");
        }
    }
    public void Load_PuzzleLibrary(object sender, EventArgs e)
    {
        Load_PuzzleLibrary();
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
    /// ��s���w�ƾ԰�
    /// </summary>
    /// <param name="i">�nReLoad���ƾ԰�(0~5)</param>
    public void Load_Preparation(int i)
    {
        if (puzzleLibrary.Count == 0)
        {
            Load_PuzzleLibrary();
        }

        PuzzleData puzzle = puzzleLibrary[0];
        puzzlePreparations[i] = puzzle;
        puzzleLibrary.Remove(puzzle);
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
