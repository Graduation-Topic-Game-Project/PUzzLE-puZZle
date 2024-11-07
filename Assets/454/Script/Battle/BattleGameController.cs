using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class BattleGameController : MonoBehaviour
{
    public event EventHandler Event_BattleStart;
    public event EventHandler Event_BattleAwake;
    public event EventHandler Event_TestUpdatePuzzleBoard;
    public event Action<int> Event_RemovePlacedPuzzle; //移除已放置拼圖
    public event EventHandler Event_PuzzlePlaceCompleted; //拼圖放置完成
    public event Func<int> Event_CheckActionPoint; //移除已放置拼圖
    public event EventHandler Event_EndTurn;


    public Puzzle puzzlePrefab; //預設拼圖Prefab

    public PuzzleData specifyPuzzle; //選擇的備戰區拼圖
    public int specifyPuzzleNumber; //選擇的備戰區拼圖編號
    public bool isSpecifyPuzzle = false; //是否選擇備戰區拼圖


    private void Awake()
    {
        Event_BattleAwake?.Invoke(this, EventArgs.Empty);
    }

    private void Start()
    {
        Event_BattleStart?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Event_TestUpdatePuzzleBoard?.Invoke(this, EventArgs.Empty);
        }
    }

    public void RemovePlacedPuzzle()
    {
        Event_RemovePlacedPuzzle?.Invoke(specifyPuzzleNumber); //刷新選擇的備戰區編號的備戰區
        isSpecifyPuzzle = false;
    }

    /// <summary>
    /// 發送拼圖放置完成事件
    /// </summary>
    public void PlacedPuzzle()
    {
        Event_PuzzlePlaceCompleted?.Invoke(this, EventArgs.Empty);
    }

    public void EndTurn()
    {
        Event_EndTurn?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 是否可放置拼圖
    /// </summary>
    public bool CanPlacePuzzle()
    {
        if (isSpecifyPuzzle == false) //如果未指定拼圖
        {
            Debug.Log("未指定拼圖");
            return false;
        }

        if (ActionPoint_Controller.ActionPoint <= 0) //如果行動值為零
        {
            Debug.Log("行動值不足");
            return false;
        }

        return true;
    }


}
