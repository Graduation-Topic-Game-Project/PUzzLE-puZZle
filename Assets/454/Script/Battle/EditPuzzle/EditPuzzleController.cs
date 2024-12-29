using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPuzzleController : MonoBehaviour
{
    public PuzzleMasterController puzzleMasterController;
    public PuzzleLibrary puzzleLibrary;


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

        if(puzzleMasterController.specifyPuzzleNumber == -1)
        {
            BattleMainMessage.SetMessage("未選擇");
            return;
        }

        if (newNum == 0 && newNum == 5)
        {
            Debug.Log("超出範圍");
            BattleMainMessage.SetMessage("超出範圍");
            return;
        }


        puzzleLibrary.SpecifyPuzzle(puzzleMasterController.specifyPuzzleNumber + num);
    }
}
