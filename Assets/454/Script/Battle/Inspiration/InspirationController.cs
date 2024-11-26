using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InspirationController : MonoBehaviour
{
    BattleGameController battleGameController;
    Button _button;

    int InspirationValue; //�F�P��
    public int defaultInspirationValue = 3; //�F�P�ȹw�]��

    public TextMeshProUGUI inspirationValue_Number; //�F�P�Ȥ�r
    public GameObject EndTurnButton;
    public GameObject Bal_And_Sword_Button;

    private void Awake()
    {
        _button = GetComponent<Button>(); //�q�\�����I���ƥ�
        //_button.onClick.AddListener(EndTurnButtonOnClick);
    }

    private void Start()
    {
        InspirationValue = defaultInspirationValue;
    }
    void Update()
    {
        inspirationValue_Number.text = InspirationValue.ToString();
    }

}
