using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditPuzzleUI : MonoBehaviour
{
    public GameObject EditPuzzleInterface;
    public EditPuzzleController editPuzzleController;

    public TextMeshProUGUI RightRotateCostText;
    public TextMeshProUGUI LeftRotateCostText;
    public TextMeshProUGUI DestoryCostText;

    public bool isOpen;

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
    /// ¶}Ãö¤¶­± True = Open False = Cloxe
    /// </summary>
    /// <param name="OpenOrClose">True = Open False = Cloxe</param>
    public void InterfaceOpenAndClose()
    {
        isOpen = !isOpen;
        EditPuzzleInterface.SetActive(isOpen);
    }
}
