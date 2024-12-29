using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPuzzleController : MonoBehaviour
{
    public PuzzleMasterController puzzleMasterController;
    public PuzzleLibrary puzzleLibrary;


    private void Awake()
    {
        if (puzzleLibrary == null) //��������W��PuzzleLibrary
        {
            puzzleLibrary = FindObjectOfType<PuzzleLibrary>();
        }
        if (puzzleMasterController == null) //��������W��PuzzleMasterController
        {
            puzzleMasterController = FindObjectOfType<PuzzleMasterController>();
        }
    }

    /// <summary> ���s�ΡA��ܤW�@�ӫ��� </summary>
    public void SpecifyPrevious()
    {
        Specify(-1);    
    }

    /// <summary>���s�ΡA��ܤU�@�ӫ��� </summary>
    public void SpecifyNext()
    {
        Specify(1);
    }

    /// <summary>
    /// ������ܫ���(num = 1 ��ܤW�@�� num = -1 ��ܤU�@��)
    /// </summary>
    private void Specify(int num)
    {
        int newNum = puzzleMasterController.specifyPuzzleNumber + num;

        if(puzzleMasterController.specifyPuzzleNumber == -1)
        {
            MessageTextController.SetMessage("�����");
            return;
        }

        if (newNum == 0 && newNum == 5)
        {
            Debug.Log("�W�X�d��");
            MessageTextController.SetMessage("�W�X�d��");
            return;
        }


        puzzleLibrary.SpecifyPuzzle(puzzleMasterController.specifyPuzzleNumber + num);
    }
}