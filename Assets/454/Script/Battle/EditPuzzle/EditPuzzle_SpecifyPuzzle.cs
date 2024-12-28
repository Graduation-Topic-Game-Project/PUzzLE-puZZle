using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EditPuzzle_SpecifyPuzzle : MonoBehaviour
{
    public BattleGameController battleGameController;
    public PuzzleMasterController puzzleMasterController;

    public Image image;
    public GameObject InstanceLocation; //�ͦ���m
    public Puzzle nowSpecifyPuzzle;
    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (puzzleMasterController == null) //��������W��PuzzleMasterController
        {
            puzzleMasterController = FindObjectOfType<PuzzleMasterController>();
        }

        battleGameController.Event_SpecifyPuzzle += UpdateSpecifyPuzzleImage;
    }

    private void Start()
    {
        UpdateSpecifyPuzzleImage();
    }

    public void UpdateSpecifyPuzzleImage(object sender, EventArgs e)
    {
        if (puzzleMasterController.specifyPuzzleNumber == -1)
        {
            Debug.Log("UpdateSpecifyPuzzleImage return");
            return;
        }

        if (nowSpecifyPuzzle != null)
            Destroy(nowSpecifyPuzzle.gameObject);

        nowSpecifyPuzzle = Instantiate(puzzleMasterController.puzzlePrefab, InstanceLocation.transform.position, InstanceLocation.transform.rotation, InstanceLocation.transform);
        nowSpecifyPuzzle.puzzleData = puzzleMasterController.specifyPuzzle;
        nowSpecifyPuzzle.ReUpdate_PuzzleEssence_Image();
    }

    public void UpdateSpecifyPuzzleImage()
    {
        UpdateSpecifyPuzzleImage(this, EventArgs.Empty);
    }
}
