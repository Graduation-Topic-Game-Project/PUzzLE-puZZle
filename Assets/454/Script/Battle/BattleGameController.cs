using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class BattleGameController : MonoBehaviour
{
    public event EventHandler BattleStart;
    public event EventHandler BattleAwake;
    public event EventHandler TestUpdatePuzzleBoard;

    private void Awake()
    {
        BattleAwake?.Invoke(this, EventArgs.Empty);
    }

    private void Start()
    {
        BattleStart?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TestUpdatePuzzleBoard?.Invoke(this, EventArgs.Empty);
        }
    }


}
