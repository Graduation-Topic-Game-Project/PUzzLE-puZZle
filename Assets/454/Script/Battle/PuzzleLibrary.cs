using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleLibrary : MonoBehaviour
{
    public BattleGameController battleGameController;
    public List<PuzzleData> puzzleLibrary; //拼圖庫
    public PuzzleData[] puzzlePreparations = new PuzzleData[6]; //拼圖備戰區

    public Parther[] parthers = new Parther[4]; //要戰鬥的夥伴
    public GameObject puzzlePreparationsGameObject; //場景上的拼圖備戰區父物件
    public Vector3[] puzzlePreparationsTransform = new Vector3[6]; //拼圖備戰區物件位置，用來對生成時的位置的

    private void Awake()
    {
        Load_puzzlePreparations();  //獲取備戰區位置
        Array.Clear(puzzlePreparations, 0, 6);
        battleGameController.BattleStart += this.Load_PuzzleLibrary;
        battleGameController.BattleStart += this.Load_All_Preparation;
    }


    /// <summary>
    /// 獲取備戰區位置
    /// </summary>
    public void Load_puzzlePreparations() //獲取備戰區位置
    {
        //puzzlePreparationsTransform[0] = puzzlePreparations.transform.GetChild(0).gameObject.transform.position;
        for (int i = 0; i < 6; i++)
        {
            puzzlePreparationsTransform[i] = puzzlePreparationsGameObject.transform.GetChild(i).gameObject.transform.position;
        }
    }

    /// <summary>
    /// 把夥伴所持的拼圖填入拼圖庫
    /// </summary>
    public void Load_PuzzleLibrary()
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log($"載入第{i + 1}個夥伴拼圖");
            if (parthers[i] != null)
            {
                puzzleLibrary.AddRange(parthers[i].thisParther.parthersPuzzle);
                //parthers[i].thisParther.parthersPuzzle.
                Debug.Log($"第{i + 1}個夥伴拼圖載入完成");
            }
            else
                Debug.Log($"第{i + 1}個夥伴為null");
        }
    }
    public void Load_PuzzleLibrary(object sender, EventArgs e)
    {
        Load_PuzzleLibrary();
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
    /// 刷新指定備戰區
    /// </summary>
    /// <param name="i">要ReLoad的備戰區(0~5)</param>
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
            Debug.Log("test更新備戰區");
            Load_All_Preparation(this, EventArgs.Empty);
        }
    }
    private void Update()
    {
        TestReloadPreparation();
    }
}
