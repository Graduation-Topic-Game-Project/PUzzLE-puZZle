using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 選擇，放置，生成拼圖的總控制器
/// </summary>
public class PuzzleSpecifyController : MonoBehaviour
{
    BattleGameController battleGameController;

    public Puzzle puzzlePrefab; //預設拼圖Prefab

    [Header("當前選擇的拼圖")]
    public PuzzleData specifyPuzzle; //選擇的備戰區拼圖
    public int specifyPuzzleNumber = -1; //選擇的備戰區編號(第幾格)
    public bool isSpecifyPuzzle = false; //是否選擇備戰區拼圖
    [Header("隨機生成 or 從夥伴拼圖庫生成")]
    [Tooltip("(false:隨機生成 true:夥伴拼圖庫生成)")]
    public bool RandowOrForParnent = false; //隨機生成 or 從夥伴拼圖庫生成(默認隨機)

    public event Action<int> Event_RemovePlacedPuzzle; //移除已放置完畢的備戰區拼圖
    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
    }
    private void Start()
    {
        isSpecifyPuzzle = false;
    }

    /// <summary>
    /// 是否可放置拼圖
    /// </summary>
    public bool CanPlacePuzzle()
    {
        if (isSpecifyPuzzle == false) //如果未指定拼圖
        {
            MessageTextController.SetMessage("未指定拼圖");
            return false;
        }

        if (ActionPoint_Controller.ActionPoint <= 0) //如果行動值為零
        {
            MessageTextController.SetMessage("行動值不足");
            return false;
        }

        return true;
    }

    /// <summary>
    /// 刷新選擇的備戰區編號的備戰區
    /// </summary>
    public void CallEvent_RemovePlacedPuzzle()
    {
        Event_RemovePlacedPuzzle?.Invoke(specifyPuzzleNumber);
    }
}
