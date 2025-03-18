using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditPuzzle_DestoryPuzzle : MonoBehaviour
{
    public EditPuzzleController editPuzzleController;

    public GameObject destoryUI;
    public GameObject destoryButton;


    private void Awake()
    {
        if (editPuzzleController == null) //獲取場景上的EditPuzzleController
        {
            editPuzzleController = FindObjectOfType<EditPuzzleController>();
        }

        destoryUI.SetActive(false);
    }
    public void DestoryPlaneSwitch(bool OpenOrClose)
    {
        destoryUI.SetActive(OpenOrClose);
        destoryButton.SetActive(!OpenOrClose);
    }
}
