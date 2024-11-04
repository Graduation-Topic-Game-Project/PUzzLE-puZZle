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
    /// 獲取備戰區位置
    /// </summary>
    public void Load_puzzlePreparationsTransform() //獲取備戰區位置
    {
        //puzzlePreparationsTransform[0] = puzzlePreparations.transform.GetChild(0).gameObject.transform.position;
        for (int i = 0; i < 6; i++)
        {
            puzzlePreparationsGameObject[i] = puzzlePreparationsAllGameObject.transform.GetChild(i).gameObject;
            puzzlePreparationsGameObject[i].GetComponent<PuzzlePreparation>().number = i;
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
            Load_Preparation(i);
        }
    }

    /// <summary>
    /// 刷新指定備戰區(移除並從拼圖庫填入)
    /// </summary>
    /// <param name="i">要ReLoad的備戰區(0~5)</param>
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
            Debug.Log("test更新備戰區");
            Load_All_Preparation(this, EventArgs.Empty);
        }
    }
    private void Update()
    {
        TestReloadPreparation();
    }
}
