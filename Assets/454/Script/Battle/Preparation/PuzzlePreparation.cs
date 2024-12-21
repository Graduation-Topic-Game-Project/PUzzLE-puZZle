using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class PuzzlePreparation : MonoBehaviour
{
    [SerializeField]
    private int _preparationNumber; //第幾個備戰區
    public GameObject _puzzleInstance; //拼圖圖片生成區域
    private Animator animator;

    public event Action<int> ClickPreparationBotton;

    Button _button;
    private Color32 _buttonDefaultColor = new Color32(255, 255, 255, 255); //按鈕預設顏色
    private Color32 _buttonClickColor = new Color32(200, 200, 200, 255); //按鈕選則時顏色


    public int PreparationNumber { get => _preparationNumber; set { _preparationNumber = value; } }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ClickPreparation);

        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// 點擊備戰區
    /// </summary>
    private void ClickPreparation()
    {
        ClickPreparationBotton?.Invoke(_preparationNumber);
        //SetColorForSpecifying(); //將按鈕顏色變成選擇時顏色
    }

    /// <summary>
    /// 重製備戰區為非選擇時狀態
    /// </summary>
    public void ResetToNoSpecifying()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color = _buttonDefaultColor;
        animator.SetBool("isSpecify", false);
    }

    /// <summary>
    /// 將備戰區切換成選擇時狀態(動畫&顏色)
    /// </summary>
    public void SetToSpecifying()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color = _buttonClickColor;
        animator.SetBool("isSpecify", true);
    }


}
