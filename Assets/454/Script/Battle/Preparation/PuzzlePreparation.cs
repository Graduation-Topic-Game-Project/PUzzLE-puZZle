using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class PuzzlePreparation : MonoBehaviour
{
    [SerializeField]
    private int _preparationNumber; //�ĴX�ӳƾ԰�
    public GameObject _puzzleInstance; //���ϹϤ��ͦ��ϰ�
    private Animator animator;

    public event Action<int> ClickPreparationBotton;

    Button _button;
    private Color32 _buttonDefaultColor = new Color32(255, 255, 255, 255); //���s�w�]�C��
    private Color32 _buttonClickColor = new Color32(200, 200, 200, 255); //���s��h���C��


    public int PreparationNumber { get => _preparationNumber; set { _preparationNumber = value; } }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ClickPreparation);

        animator = GetComponent<Animator>();
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
    /// ���s�ƾ԰Ϭ��D��ܮɪ��A
    /// </summary>
    public void ResetToNoSpecifying()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color = _buttonDefaultColor;
        animator.SetBool("isSpecify", false);
    }

    /// <summary>
    /// �N�ƾ԰Ϥ�������ܮɪ��A(�ʵe&�C��)
    /// </summary>
    public void SetToSpecifying()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color = _buttonClickColor;
        animator.SetBool("isSpecify", true);
    }


}
