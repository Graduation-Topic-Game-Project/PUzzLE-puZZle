using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_EnemyPuzzle : MonoBehaviour
{
    public BoardController boardController;

    private void Awake()
    {
        if (boardController == null) //獲取場景上的BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }
    }
}
