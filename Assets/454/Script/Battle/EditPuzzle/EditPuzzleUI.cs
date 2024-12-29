using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPuzzleUI : MonoBehaviour
{
    public GameObject EditPuzzleInterface;
    public EditPuzzle_SpecifyPuzzle SpecifyPuzzleImgae;
    void Start()
    {
        EditPuzzleInterface.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
