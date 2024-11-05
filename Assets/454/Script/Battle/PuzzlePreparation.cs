using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class PuzzlePreparation : MonoBehaviour
{
    public BattleGameController battleGameController;
    [SerializeField]
    private int _preparationNumber; //第幾個備戰區

    public event Action<int> ClickPreparationBotton;

    private Button _button;
    private Color32 _buttonDefaultColor = new Color32(255, 255, 255, 255); //按鈕預設顏色
    private Color32 _buttonClickColor = new Color32(200, 200, 200, 255); //按鈕選則時顏色


    public int PreparationNumber { get => _preparationNumber; set { _preparationNumber = value; } }

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        _button = GetComponent<Button>();
        _button.onClick.AddListener(ClickPreparation);
    }

    /// <summary>
    /// 點擊備戰區
    /// </summary>
    private void ClickPreparation()
    {
        //battleGameController.otherPuzzle = PuzzleLibrary.puzzlePreparations[number];
        ClickPreparationBotton?.Invoke(_preparationNumber);
        SetClickColor();
    }

    /// <summary>
    /// 重製按鈕顏色為預設顏色
    /// </summary>
    public void ResetColor()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color = _buttonDefaultColor;
    }

    /// <summary>
    /// 將按鈕顏色變成選則時顏色
    /// </summary>
    public void SetClickColor()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color = _buttonClickColor;
    }


}
