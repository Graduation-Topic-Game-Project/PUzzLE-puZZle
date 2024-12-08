using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyPuzzleSkill : EnemySkill
{
    BoardController boardController;

    protected override int damage { get; } = 10;
    public EnemyPuzzle enemyPuzzle;
    public bool isBreak;
    protected virtual int _minX { get; } = 0;
    protected virtual int _maxX { get; } = 5;
    protected virtual int _minY { get; } = 0;
    protected virtual int _maxY { get; } = 6;


    protected void Awake()
    {
        if (boardController == null) //��������W��BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }
        //base.Awake();
        if (enemyPuzzle == null)
            enemyPuzzle = this.gameObject.transform.GetComponent<EnemyPuzzle>();

        isBreak = false;
    }

    /// <summary>
    /// ���B�g����ƥ�
    /// </summary>
    public override void SettlementSkill()
    {
        if (isBreak == false)
        {
            Debug.Log("���Q�}�a�A��ڤ趤��y���ˮ`");
            PlayerBattleData.Damage(damage);
        }
        else
        {
            Debug.Log("�w�Q�}�a�A���y���ˮ`");
        }
    }

    /// <summary>
    /// ��l�Ƨޯ�
    /// </summary>
    public override void InitializeSkill()
    {
        isBreak = false;
    }

    /// <summary>
    /// ��ҤƧޯ�
    /// </summary>
    public override void InstantiateSkill()
    {
        if (boardController == null) //��������W��BoardController
        {
            boardController = FindObjectOfType<BoardController>();
        }

        int x = UnityEngine.Random.Range(_minX, _maxX);
        int y = UnityEngine.Random.Range(_minY, _maxY);


        if (boardController.board[x, y].Puzzle == null)
        {
            boardController.board[x, y].Puzzle = enemyPuzzle.puzzleData; //��sPuzzleData�������Ϯy��
            boardController.board[x, y].Puzzle.puzzlePosition = (x, y);
        }
        else
            Debug.Log("���~�A�Ӧa��w�����ϡA�L�k��m�Ĥ���ϧޯ�");

        boardController.UpdatePuzzleBoard();
    }

    public void CheckIsBreak() //�ˬd�O�_�Q�}�a
    {
        if (isBreak == false)
        {
            if (CheckEnemyPuzzleAround.Check(enemyPuzzle.puzzleData))
            {
                isBreak = true;
                MessageTextController.SetMessage("�Ĥ���Ϥw�Q�}�a");
                Debug.Log("�Ĥ���Ϥw�Q�}�a");
            }
        }
    }
}
