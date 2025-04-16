using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleDrag_PuzzleGrid : MonoBehaviour
{

    public PuzzleDragController puzzleDragController;
    public PuzzleGrid PuzzleGrid;

    private void Awake()
    {
        if (puzzleDragController == null) //獲取場景上的PuzzleDragController
        {
            puzzleDragController = FindObjectOfType<PuzzleDragController>();
        }
    }
    void OnMouseUp()
    {
        // If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Drag ended!");
    }

}
