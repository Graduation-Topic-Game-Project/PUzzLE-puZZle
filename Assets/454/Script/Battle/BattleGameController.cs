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


}
