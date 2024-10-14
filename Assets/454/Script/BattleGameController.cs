using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class BattleGameController : MonoBehaviour
{
    public Puzzle[,] puzzles = new Puzzle[7, 6];
    public GameObject puzzlesGrids; //�����W���L����l������
    public Vector3[,] puzzlesGridTransform = new Vector3[7, 6]; //���ϽL���ئ�m�A�Ψӹ�ͦ��ɪ���m��


    public Puzzle puzzlePrefab; //�w�]����
    public GameObject puzzleInstanceTransform; //���Ϫ���ͦ���Ƨ�

    public event EventHandler BattleStart;


    private void Awake()
    {

        puzzles[0, 5] = puzzlePrefab;
        puzzles[3, 3] = new Puzzle(PuzzleData.PuzzleEssence.Strengthe_�O�q);

        Load_puzzlesGrids();  //�N������puzzlesGrid�s�i2���}�C
    }
    private void Update()
    {
        Test();
    }

    public void UpdatePuzzleField() //��s��ܽL���W����
    {
        for (int i = 0; i < puzzleInstanceTransform.transform.childCount; i++)
        {   //�M���«���
            Destroy(puzzleInstanceTransform.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (puzzles[i, j] != null)
                {
                    Debug.Log(puzzles[i, j]);
                    //Debug.Log(puzzlesGridTransform[i, j]);
                    Puzzle nowPuzzle = puzzles[i, j];
                    //                                                                                         //���Ϫ���ͦ�����Ƨ�
                    Instantiate(nowPuzzle, puzzlesGridTransform[i, j], transform.rotation, puzzleInstanceTransform.transform);
                }
            }
        }
    }
    /// <summary>
    /// �N������puzzlesGrid�s�i2���}�C
    /// </summary>
    public void Load_puzzlesGrids() //�N������puzzlesGrid�s�i2���}�C
    {
        int childNum = 0;

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                puzzlesGridTransform[i, j] = puzzlesGrids.transform.GetChild(childNum).gameObject.transform.position;
                //Debug.Log(puzzlesGrids.transform.GetChild(childNum).gameObject);
                //Debug.Log(puzzlesGridGameObject[i, j]);
                childNum++;
            }
        }
        UpdatePuzzleField(); //��s�L���W����
    }

    public void Test()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("test��s�L��");
            puzzles[1, 5] = puzzlePrefab;
            UpdatePuzzleField();
        }
    }
}
