using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class PuzzlePreparation : MonoBehaviour
{
    public BattleGameController battleGameController;
    [SerializeField]
    private int _preparationNumber; //�ĴX�ӳƾ԰�

    public event Action<int> ClickPreparationBotton;

    private Button _button;
    private Color32 _buttonDefaultColor = new Color32(255, 255, 255, 255); //���s�w�]�C��
    private Color32 _buttonClickColor = new Color32(200, 200, 200, 255); //���s��h���C��


    public int PreparationNumber { get => _preparationNumber; set { _preparationNumber = value; } }

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        _button = GetComponent<Button>();
        _button.onClick.AddListener(ClickPreparation);
    }

    /// <summary>
    /// �I���ƾ԰�
    /// </summary>
    private void ClickPreparation()
    {
        //battleGameController.otherPuzzle = PuzzleLibrary.puzzlePreparations[number];
        ClickPreparationBotton?.Invoke(_preparationNumber);
        SetClickColor();
    }

    /// <summary>
    /// ���s���s�C�⬰�w�]�C��
    /// </summary>
    public void ResetColor()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color = _buttonDefaultColor;
    }

    /// <summary>
    /// �N���s�C���ܦ���h���C��
    /// </summary>
    public void SetClickColor()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color = _buttonClickColor;
    }


}
