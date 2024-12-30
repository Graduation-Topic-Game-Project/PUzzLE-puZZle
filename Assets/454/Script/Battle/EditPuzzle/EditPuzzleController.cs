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
        if (puzzleLibrary == null) //獲取場景上的PuzzleLibrary
        {
            puzzleLibrary = FindObjectOfType<PuzzleLibrary>();
        }
        if (puzzleMasterController == null) //獲取場景上的PuzzleMasterController
        {
            puzzleMasterController = FindObjectOfType<PuzzleMasterController>();
        }
        if (editPuzzle_SpecifyPuzzle == null) //獲取場景上的EditPuzzle_SpecifyPuzzle
        {
            editPuzzle_SpecifyPuzzle = FindObjectOfType<EditPuzzle_SpecifyPuzzle>();
        }
    }

    /// <summary> 按鈕用，選擇上一個拼圖 </summary>
    public void SpecifyPrevious()
    {
        Specify(-1);
    }

    /// <summary>按鈕用，選擇下一個拼圖 </summary>
    public void SpecifyNext()
    {
        Specify(1);
    }

    /// <summary>
    /// 切換選擇拼圖(num = 1 選擇上一個 num = -1 選擇下一個)
    /// </summary>
    private void Specify(int num)
    {
        int newNum = puzzleMasterController.specifyPuzzleNumber + num;

        if (puzzleMasterController.specifyPuzzleNumber == -1)
        {
            BattleMainMessage.SetMessage("未選擇");
            return;
        }

        Debug.Log(newNum);

        if (newNum < 0 || newNum > 5)
        {
            Debug.Log("超出範圍");
            BattleMainMessage.SetMessage("超出範圍");
            return;
        }

        puzzleLibrary.SpecifyPuzzle(puzzleMasterController.specifyPuzzleNumber + num);
    }


    public void RightRotating() //按鈕用右轉拼圖
    {
        int i = puzzleMasterController.specifyPuzzleNumber;
        PuzzleData newPuzzledata = puzzleLibrary.puzzlePreparations[i];

        newPuzzledata.RotatingPuzzleRight();
        puzzleLibrary.puzzlePreparations[i] = newPuzzledata;

        editPuzzle_SpecifyPuzzle.UpdateSpecifyPuzzleImage(); //更新編輯介面拼圖圖片
        puzzleLibrary.UpdatePreparationPuzzle(this, EventArgs.Empty); //更新備戰區拼圖圖片
    }

    public void LeftRotating() //按鈕用左轉拼圖
    {
        int i = puzzleMasterController.specifyPuzzleNumber;
        PuzzleData newPuzzledata = puzzleLibrary.puzzlePreparations[i];

        newPuzzledata.RotatingPuzzleLeft();
        puzzleLibrary.puzzlePreparations[i] = newPuzzledata;

        editPuzzle_SpecifyPuzzle.UpdateSpecifyPuzzleImage(); //更新編輯介面拼圖圖片
        puzzleLibrary.UpdatePreparationPuzzle(this, EventArgs.Empty); //更新備戰區拼圖圖片
    }
}
