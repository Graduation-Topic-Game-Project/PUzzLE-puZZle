using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class PuzzlePreparation : MonoBehaviour
{
    [SerializeField]
    private int _preparationNumber; //�ĴX�ӳƾ԰�

    public event Action<int> ClickPreparationBotton;

    Button _button;
    private Color32 _buttonDefaultColor = new Color32(255, 255, 255, 255); //���s�w�]�C��
    private Color32 _buttonClickColor = new Color32(200, 200, 200, 255); //���s��h���C��


    public int PreparationNumber { get => _preparationNumber; set { _preparationNumber = value; } }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ClickPreparation);
    }

    /// <summary>
    /// �I���ƾ԰�
    /// </summary>
    private void ClickPreparation()
    {
        ClickPreparationBotton?.Invoke(_preparationNumber);
        //SetColorForSpecifying(); //�N���s�C���ܦ���ܮ��C��
    }

    /// <summary>
    /// ���s���s�C�⬰�w�]�C��
    /// </summary>
    public void ResetColor()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color = _buttonDefaultColor;
    }

    /// <summary>
    /// �N���s�C���ܦ���ܮ��C��
    /// </summary>
    public void SetColorForSpecifying()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color = _buttonClickColor;
    }


}
