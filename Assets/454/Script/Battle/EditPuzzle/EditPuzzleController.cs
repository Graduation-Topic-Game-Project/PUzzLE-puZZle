using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EditPuzzleController : MonoBehaviour
{
    public PuzzleMasterController puzzleMasterController;
    public PuzzleLibrary puzzleLibrary;
    public EditPuzzle_SpecifyPuzzle editPuzzle_SpecifyPuzzle;


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
        if (editPuzzle_SpecifyPuzzle == null) //��������W��EditPuzzle_SpecifyPuzzle
        {
            editPuzzle_SpecifyPuzzle = FindObjectOfType<EditPuzzle_SpecifyPuzzle>();
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
        int newNum = puzzleMasterController.SpecifyPuzzleNumber + num;

        if (puzzleMasterController.SpecifyPuzzleNumber == -1)
        {
            BattleMainMessage.SetMessage("�����");
            return;
        }

        Debug.Log(newNum);

        if (newNum < 0 || newNum > 5)
        {
            Debug.Log("�W�X�d��");
            BattleMainMessage.SetMessage("�W�X�d��");
            return;
        }

        puzzleLibrary.SpecifyPuzzle(puzzleMasterController.SpecifyPuzzleNumber + num);
    }


    public void RightRotating() //���s�Υk�����
    {
        int i = puzzleMasterController.SpecifyPuzzleNumber;
        if(i <0 || i > 5)
        {
            BattleMainMessage.SetMessage("����ܡA�L�k����");
            return;
        }

        PuzzleData newPuzzledata = puzzleLibrary.puzzlePreparations[i];
        newPuzzledata.RotatingPuzzleRight();
        puzzleLibrary.puzzlePreparations[i] = newPuzzledata;

        editPuzzle_SpecifyPuzzle.UpdateSpecifyPuzzleImage(); //��s�s�褶�����ϹϤ�
        puzzleLibrary.UpdatePreparationPuzzle(this, EventArgs.Empty); //��s�ƾ԰ϫ��ϹϤ�
    }

    public void LeftRotating() //���s�Υ������
    {
        int i = puzzleMasterController.SpecifyPuzzleNumber;
        if (i < 0 || i > 5)
        {
            BattleMainMessage.SetMessage("����ܡA�L�k����");
            return;
        }

        PuzzleData newPuzzledata = puzzleLibrary.puzzlePreparations[i];
        newPuzzledata.RotatingPuzzleLeft();
        puzzleLibrary.puzzlePreparations[i] = newPuzzledata;

        editPuzzle_SpecifyPuzzle.UpdateSpecifyPuzzleImage(); //��s�s�褶�����ϹϤ�
        puzzleLibrary.UpdatePreparationPuzzle(this, EventArgs.Empty); //��s�ƾ԰ϫ��ϹϤ�
    }

    public void DestoryPuzzle()
    {
        int i = puzzleMasterController.SpecifyPuzzleNumber; //�ثe��ܪ��ƾ԰Ͻs��
        if (i < 0 || i > 5)
        {
            BattleMainMessage.SetMessage("����ܡA�L�k����");
            return;
        }

        PuzzleData newPuzzledata = puzzleLibrary.puzzlePreparations[i];
        puzzleLibrary.RemovePlacedPuzzle(i);

        puzzleLibrary.ResetAllPreparationToNoSpecifying(); //���s�Ҧ��ƾ԰Ϭ��D���
        editPuzzle_SpecifyPuzzle.UpdateSpecifyPuzzleImage(); //��s�s�褶�����ϹϤ�
    }
}
