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

    /// <summary>�Ĥ���ϥͦ����̤W���(0~5) </summary>
    protected virtual int _minX { get; } = 0;
    /// <summary>�Ĥ���ϥͦ����̤U���(0~5) </summary>
    protected virtual int _maxX { get; } = 5;
    /// <summary>�Ĥ���ϥͦ����̥����C(0~6) </summary>
    protected virtual int _minY { get; } = 0;
    /// <summary>�Ĥ���ϥͦ����̥k���C(0~6) </summary>
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
            BattleConfrontationController.AddEnemyAttack(damage);
            //PlayerBattleData.Instance.Damage(damage);
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
        enemyPuzzle.BreakImage_OpenOrClose(false);
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

        int x = UnityEngine.Random.Range(_minX, _maxX + 1);
        int y = UnityEngine.Random.Range(_minY, _maxY + 1);


        if (boardController.board[x, y].Puzzle == null)
        {
            boardController.board[x, y].Puzzle = enemyPuzzle.puzzleData; //�N�����Ϸs�W�ܽL��
            boardController.board[x, y].Puzzle.puzzlePosition = (x, y); //��sPuzzleData�������Ϯy��
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
                BattleMainMessage.SetMessage("�Ĥ���Ϥw�Q�}�a");
                Debug.Log("�Ĥ���Ϥw�Q�}�a");

                (int x, int y) = enemyPuzzle.puzzleData.puzzlePosition;
                boardController.board[x, y].Puzzle = enemyPuzzle.puzzleData;

                Debug.Log(boardController.board[x, y].Puzzle);
                Debug.Log($"test ��s�Ĥ����{x},{y}��board ���");
                boardController.UpdatePuzzleBoard();
            }
        }
    }

    /*public void UpdateEnemyPuzzleImage()
    {

    }*/
}
