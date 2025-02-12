using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EditPuzzleController : MonoBehaviour
{
    public PuzzleMasterController puzzleMasterController;
    public PuzzleLibrary puzzleLibrary;
    public EditPuzzle_SpecifyPuzzle editPuzzle_SpecifyPuzzle;
    public InspirationController inspirationController;

    public int rightRotateCost; //旋轉消耗靈感值
    public int leftRotateCost;
    public int destoryCost;

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
        if (inspirationController == null) //獲取場景上的InspirationController
        {
            inspirationController = FindObjectOfType<InspirationController>();
        }

        rightRotateCost = -1;
        leftRotateCost = -1;
        destoryCost = -1;
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
        if(num != 1 && num != -1)
        {
            Debug.Log("警告：EditPuzzleController選擇拼圖按鈕輸入值異常");
        }

        int newNum = puzzleMasterController.SpecifyPuzzleNumber + num;

        if (puzzleMasterController.SpecifyPuzzleNumber == -1)
        {
            BattleMainMessage.SetMessage("未選擇");
            return;
        }

        //Debug.Log(newNum);

        if (newNum < 0 || newNum > 5)
        {
            Debug.Log("超出範圍");
            BattleMainMessage.SetMessage("超出範圍");
            return;
        }

        puzzleLibrary.SpecifyPuzzle(puzzleMasterController.SpecifyPuzzleNumber + num);
    }


    public void RightRotating() //按鈕用右轉拼圖
    {
        int i = puzzleMasterController.SpecifyPuzzleNumber; //目前選擇的備戰區
        if(i <0 || i > 5)
        {
            BattleMainMessage.SetMessage("未選擇，無法旋轉");
            return;
        }
        
        if(inspirationController.Inspiration + rightRotateCost < 0) //若靈感值不足
        {
            BattleMainMessage.SetMessage("靈感值不足，無法旋轉");
            return;
        }

        inspirationController.Inspiration += rightRotateCost; //扣除消耗值

        PuzzleData newPuzzledata = puzzleLibrary.puzzlePreparations[i];
        newPuzzledata.RotatingPuzzleRight();
        puzzleLibrary.puzzlePreparations[i] = newPuzzledata;

        editPuzzle_SpecifyPuzzle.UpdateSpecifyPuzzleImage(); //更新編輯介面拼圖圖片
        puzzleLibrary.UpdatePreparationPuzzle(this, EventArgs.Empty); //更新備戰區拼圖圖片

        rightRotateCost--; //每次旋轉消耗+1
    }

    public void LeftRotating() //按鈕用左轉拼圖
    {
        int i = puzzleMasterController.SpecifyPuzzleNumber;
        if (i < 0 || i > 5)
        {
            BattleMainMessage.SetMessage("未選擇，無法旋轉");
            return;
        }

        if (inspirationController.Inspiration + leftRotateCost < 0) //若靈感值不足
        {
            BattleMainMessage.SetMessage("靈感值不足，無法旋轉");
            return;
        }

        inspirationController.Inspiration += leftRotateCost;

        PuzzleData newPuzzledata = puzzleLibrary.puzzlePreparations[i];
        newPuzzledata.RotatingPuzzleLeft();
        puzzleLibrary.puzzlePreparations[i] = newPuzzledata;

        editPuzzle_SpecifyPuzzle.UpdateSpecifyPuzzleImage(); //更新編輯介面拼圖圖片
        puzzleLibrary.UpdatePreparationPuzzle(this, EventArgs.Empty); //更新備戰區拼圖圖片

        leftRotateCost--; //每次旋轉消耗+1
    }

    public void DestoryPuzzle()
    {
        int i = puzzleMasterController.SpecifyPuzzleNumber; //目前選擇的備戰區編號
        if (i < 0 || i > 5)
        {
            BattleMainMessage.SetMessage("未選擇，無法旋轉");
            return;
        }

        if (inspirationController.Inspiration + destoryCost < 0) //若靈感值不足
        {
            BattleMainMessage.SetMessage("靈感值不足，無法破壞");
            return;
        }

        inspirationController.Inspiration += destoryCost;

        PuzzleData newPuzzledata = puzzleLibrary.puzzlePreparations[i];
        puzzleLibrary.RemovePlacedPuzzle(i);

        puzzleLibrary.ResetAllPreparationToNoSpecifying(); //重製所有備戰區為非選擇
        editPuzzle_SpecifyPuzzle.UpdateSpecifyPuzzleImage(); //更新編輯介面拼圖圖片

        destoryCost--; //每次破壞消耗+1
    }
}
