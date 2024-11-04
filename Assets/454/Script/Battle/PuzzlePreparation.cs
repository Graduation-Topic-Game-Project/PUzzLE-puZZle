using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class PuzzlePreparation : MonoBehaviour
{
    public BattleGameController battleGameController;

    public int number;

    public event Action<int> ClickPreparationBotton;

    private Button button;

    private void Awake()
    {
        if (battleGameController == null)
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Click()
    {
        //battleGameController.otherPuzzle = PuzzleLibrary.puzzlePreparations[number];
        ClickPreparationBotton?.Invoke(number);
    }


}
