using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPuzzle_Button : MonoBehaviour
{
    public InspirationButtonController inspirationButtonController;

    public GameObject S_and_B_Interface;
    bool isOpen = false;

    private void Awake()
    {
        if (inspirationButtonController == null) //獲取場景上的InspirationButtonController
        {
            inspirationButtonController = FindObjectOfType<InspirationButtonController>();
        }
    }
    public void open()
    {
        isOpen = !isOpen;
        S_and_B_Interface.SetActive(isOpen);
        //Debug.Log("Bal_And_Sword_Button");

        inspirationButtonController.CloseButton();
    }
}
