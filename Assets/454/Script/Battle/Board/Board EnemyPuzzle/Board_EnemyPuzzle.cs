using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_EnemyPuzzle : MonoBehaviour
{
    public BoardController boardController;

    private void Awake()
    {
        if (boardController == null) //��������W��BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }
    }
}
