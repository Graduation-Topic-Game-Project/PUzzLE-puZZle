using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EditPuzzleUI : MonoBehaviour
{
    public BattleGameController battleGameController;

    public GameObject EditPuzzleInterface;
    public EditPuzzleController editPuzzleController;

    public TextMeshProUGUI RightRotateCostText;
    public TextMeshProUGUI LeftRotateCostText;
    public TextMeshProUGUI DestoryCostText;

    public bool isOpen;


    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
    }

    void Start()
    {
        EditPuzzleInterface.gameObject.SetActive(false);
        isOpen = false;
    }

    private void Update()
    {
        RightRotateCostText.text = editPuzzleController.rightRotateCost.ToString();
        LeftRotateCostText.text = editPuzzleController.leftRotateCost.ToString();
        DestoryCostText.text = editPuzzleController.destoryCost.ToString();
    }


    /// <summary>
    /// 開關介面 True = Open False = Cloxe
    /// </summary>
    /// <param name="OpenOrClose">True = Open False = Cloxe</param>
    public void InterfaceOpenAndClose()
    {
        isOpen = !isOpen;
        EditPuzzleInterface.SetActive(isOpen);
        battleGameController.CallEvent_HideInspiration(isOpen);
    }
}
