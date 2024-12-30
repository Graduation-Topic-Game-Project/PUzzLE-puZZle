using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPuzzleUI : MonoBehaviour
{
    public GameObject EditPuzzleInterface;
    public EditPuzzleController editPuzzleController;

    void Start()
    {
        EditPuzzleInterface.gameObject.SetActive(false);
    }


    /// <summary>
    /// ¶}Ãö¤¶­± True = Open False = Cloxe
    /// </summary>
    /// <param name="OpenOrClose">True = Open False = Cloxe</param>
    public void InterfaceOpenAndClose(bool OpenOrClose)
    {
        EditPuzzleInterface.SetActive(OpenOrClose);
    }
}
