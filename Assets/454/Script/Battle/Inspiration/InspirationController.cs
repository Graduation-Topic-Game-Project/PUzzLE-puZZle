using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InspirationController : MonoBehaviour
{
    BattleGameController battleGameController;
    Button _button;

    int InspirationValue; //靈感值
    public int defaultInspirationValue = 3; //靈感值預設值

    public TextMeshProUGUI inspirationValue_Number; //靈感值文字
    public GameObject EndTurnButton;
    public GameObject Bal_And_Sword_Button;
    public bool isOpen;

    private void Awake()
    {
        _button = GetComponent<Button>(); //訂閱按紐點擊事件
        _button.onClick.AddListener(OpenButton);
        isOpen = false;
    }

    private void Start()
    {
        InspirationValue = defaultInspirationValue;
    }
    void Update()
    {
        inspirationValue_Number.text = InspirationValue.ToString();
    }

    void OpenButton()
    {
        isOpen = !isOpen;
        EndTurnButton.SetActive(isOpen);
        Bal_And_Sword_Button.SetActive(isOpen);
    }

}
