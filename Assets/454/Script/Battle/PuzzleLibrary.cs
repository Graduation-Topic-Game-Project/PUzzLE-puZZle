using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleLibrary : MonoBehaviour
{
    public BattleGameController battleGameController;
    public GameObject puzzlePreparationsAllGameObject; //場景上的拼圖備戰區父物件
    public List<PuzzleData> puzzleLibrary; //拼圖庫
    public PuzzleData[] puzzlePreparations = new PuzzleData[6]; //拼圖備戰區

    public Parther[] parthers = new Parther[4]; //要戰鬥的夥伴
    public GameObject[] puzzlePreparationsGameObject = new GameObject[6]; //拼圖備戰區物件位置，用來對生成時的位置的

    private void Awake()
    {
        Load_puzzlePreparationsTransform();  //獲取備戰區位置
        Array.Clear(puzzlePreparations, 0, 6); //獲取備戰區位置
        battleGameController.Event_BattleStart += this.Load_PuzzleLibrary_ForParther;
        battleGameController.Event_BattleStart += this.Load_All_Preparation;
        battleGameController.Event_RemovePlacedPuzzle += this.RemovePlacedPuzzle;

        for (int i = 0; i < puzzlePreparationsGameObject.Length; i++) //訂閱所有備戰區按鈕事件
        {
            puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>().ClickPreparationBotton += this.SpecifyPuzzle;
        }
        //battleGameController.BattleStart += UpdatePreparationPuzzle;
    }

    /// <summary>
    /// 獲取備戰區位置
    /// </summary>
    public void Load_puzzlePreparationsTransform() //獲取備戰區位置
    {
        //puzzlePreparationsTransform[0] = puzzlePreparations.transform.GetChild(0).gameObject.transform.position;
        for (int i = 0; i < 6; i++)
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
            if (parthers[i] != null)
            {
                puzzleLibrary.AddRange(parthers[i].thisParther.parthersPuzzle);
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
    /// 刷新全部備戰區
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
    /// 在放置後移除並刷新第number個備戰區
    /// </summary>
    /// <param name="number">要刷新的備戰區是第幾個</param>
    public void RemovePlacedPuzzle(int number)
    {
        Debug.Log("RemovePlacedPuzzle");
        Load_Preparation_ForParner(number);
        UpdatePreparationPuzzle(this, EventArgs.Empty);
    }

    /// <summary>
    /// 更新並顯示備戰區拼圖
    /// </summary>
    public void UpdatePreparationPuzzle(object sender, EventArgs e)
    {
        //清空舊拼圖
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
    /// 選擇備戰區的拼圖
    /// </summary>
    /// <param name="number">第幾個備戰區格子</param>
    public void SpecifyPuzzle(int number)
    {
        battleGameController.specifyPuzzle = puzzlePreparations[number];
        battleGameController.specifyPuzzleNumber = number;
        battleGameController.isSpecifyPuzzle = true;

        for (int i = 0; i < puzzlePreparationsGameObject.Length; i++) //重製所有按鈕顏色為預設
        {
            puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>().ResetColor();
        }
        //puzzlePreparationsGameObject[number].GetComponent<PuzzlePreparation>().SetClickColor(); //將點擊按鈕顏色為ClickColor
    }


    public void TestReloadPreparation()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("test更新備戰區");
            Load_All_Preparation(this, EventArgs.Empty);
        }
    }
    private void Update()
    {
        TestReloadPreparation();
    }
}
