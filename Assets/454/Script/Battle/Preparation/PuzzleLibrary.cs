using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleLibrary : MonoBehaviour
{
    private BattleGameController battleGameController;
    private PuzzleMasterController puzzleMasterController;
    public GameObject puzzlePreparationsAllGameObject; //場景上的拼圖備戰區父物件

    public List<PuzzleData> puzzleLibrary; //拼圖庫
    public PuzzleData[] puzzlePreparations = new PuzzleData[6]; //拼圖備戰區

    private GameObject[] puzzlePreparationsGameObject = new GameObject[6]; //拼圖備戰區物件，用來對生成時的位置的

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (puzzleMasterController == null) //獲取場景上的PuzzleSpecifyController
        {
            puzzleMasterController = FindObjectOfType<PuzzleMasterController>();
        }


        Load_puzzlePreparationsTransform();  //獲取備戰區位置
        Array.Clear(puzzlePreparations, 0, puzzlePreparations.Length); //清空備戰區內拼圖資料

        battleGameController.Event_BattleStart += this.Load_PuzzleLibrary_ForParther; //把夥伴所持的拼圖填入拼圖庫
        battleGameController.Event_BattleStart += this.Load_All_Preparation; //刷新全部備戰區
        puzzleMasterController.Event_RemovePlacedPuzzle += this.ResetAllPreparationToNoSpecifying; //重製所有備戰區為非選擇
        puzzleMasterController.Event_RemovePlacedPuzzle += this.RemovePlacedPuzzle; //在放置後移除並刷新第number個備戰區
        battleGameController.Event_PuzzlePlaceCompleted += this.UpdatePreparationPuzzle; //重製所有備戰區

        for (int i = 0; i < puzzlePreparationsGameObject.Length; i++) //訂閱所有備戰區按鈕事件
        {
            puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>().ClickPreparationBotton += this.SpecifyPuzzle;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Debug.Log("手動刷新備戰區");
            Load_All_Preparation(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// 獲取備戰區位置
    /// </summary>
    public void Load_puzzlePreparationsTransform() //獲取備戰區位置
    {
        int PreLength = puzzlePreparationsGameObject.Length;

        for (int i = 0; i < PreLength; i++)
        {
            puzzlePreparationsGameObject[i] = puzzlePreparationsAllGameObject.transform.GetChild(i).gameObject;
            puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>().PreparationNumber = i;
        }
    }

    /// <summary>
    /// 把夥伴所持的拼圖填入拼圖庫
    /// </summary>
    public void Load_PuzzleLibrary_ForParther()
    {
        for (int i = 0; i < 4; i++)
        {
            //Debug.Log($"載入第{i + 1}個夥伴拼圖");
            if (battleGameController.partners[i] != null)
            {
                puzzleLibrary.AddRange(battleGameController.partners[i].partnerData.partnersPuzzle);
                //Debug.Log($"第{i + 1}個夥伴拼圖載入完成");
            }
            else
            {
                //Debug.Log($"第{i + 1}個夥伴為null");
            }
        }
    }
    public void Load_PuzzleLibrary_ForParther(object sender, EventArgs e)
    {
        Load_PuzzleLibrary_ForParther(); //把夥伴所持的拼圖填入拼圖庫
    }

    /// <summary>
    /// 刷新指定備戰區(移除並從拼圖庫填入)
    /// </summary>
    /// <param name="i">要ReLoad的備戰區(0~5)</param>
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
    /// 刷新指定備戰區(移除並隨機生成)
    /// </summary>
    /// <param name="i">要ReLoad的備戰區(0~5)</param>
    public void Load_Preparation_Randow(int i)
    {
        PuzzleData puzzle = new PuzzleData();
        puzzle.RandomlyGeneratedPuzzleData();
        puzzlePreparations[i] = puzzle;
    }

    /// <summary>
    /// 刷新全部備戰區
    /// </summary>
    public void Load_All_Preparation(object sender, EventArgs e)
    {
        int PreLength = puzzlePreparationsGameObject.Length; //備戰區長度

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
    /// 在放置後移除並刷新第number個備戰區
    /// </summary>
    /// <param name="number">要刷新的備戰區是第幾個</param>
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
    /// 更新並顯示全部備戰區拼圖
    /// </summary>
    public void UpdatePreparationPuzzle(object sender, EventArgs e)
    {
        int PreLength = puzzlePreparationsGameObject.Length; //備戰區長度

        //清空舊拼圖
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
    /// 選擇備戰區的拼圖
    /// </summary>
    /// <param name="number">第幾個備戰區格子</param>
    public void SpecifyPuzzle(int number)
    {
        if (puzzleMasterController.SpecifyPuzzleNumber != number)
        {
            ResetAllPreparationToNoSpecifying(); //重製所有備戰區按鈕顏色為預設
            puzzleMasterController.specifyPuzzle = puzzlePreparations[number];  //更改選擇的備戰區拼圖           
            puzzleMasterController.SpecifyPuzzleNumber = number;  // 更改選擇的備戰區編號(第幾格)
            puzzleMasterController.isSpecifyPuzzle = true;
            puzzlePreparationsGameObject[number].GetComponent<PuzzlePreparation>().SetToSpecifying(); //將備戰區切換成選擇時狀態

            battleGameController.CallEvent_SpecifyPuzzle(true); //發送選擇拼圖事件
        }
        else
        {
            //puzzleMasterController.SpecifyPuzzleNumber = -1;
            //puzzleMasterController.isSpecifyPuzzle = false;
            ResetAllPreparationToNoSpecifying(); //重製所有備戰區為非選擇

            battleGameController.CallEvent_SpecifyPuzzle(false); //發送選擇拼圖事件，注意!此事件呼叫可能導致Bug
        }
    }

    public void ResetAllPreparationToNoSpecifying()  //重製所有備戰區為非選擇
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

    /// <param name="noUse">沒有用處，只是為了符合事件格式</param>
    public void ResetAllPreparationToNoSpecifying(int noUse)
    {
        ResetAllPreparationToNoSpecifying();
    }
}
