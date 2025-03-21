using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPuzzle_Button : MonoBehaviour
{
    public InspirationButtonController inspirationButtonController;
    public EditPuzzleUI editPuzzleUI;
    

    private void Awake()
    {
        if (inspirationButtonController == null) //獲取場景上的InspirationButtonController
        {
            inspirationButtonController = FindObjectOfType<InspirationButtonController>();
        }
    }
    public void open()
    {
        inspirationButtonController.CloseButton();
        editPuzzleUI.InterfaceOpenAndClose();
    }
}
