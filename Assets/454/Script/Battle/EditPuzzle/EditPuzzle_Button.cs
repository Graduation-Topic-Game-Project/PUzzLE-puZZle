using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPuzzle_Button : MonoBehaviour
{
    public GameObject S_and_B_Interface;
    bool isOpen = false;

    public void open()
    {
        isOpen = !isOpen;
        S_and_B_Interface.SetActive(isOpen);
        Debug.Log("Bal_And_Sword_Button");
    }
}
