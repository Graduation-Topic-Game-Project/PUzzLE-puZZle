using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndTurnController : MonoBehaviour
{
    private BattleGameController battleGameController;
    private BoardController boardController;

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        if (boardController == null) //��������W��BoardController   
            boardController = FindObjectOfType<BoardController>();

        //battleGameController.Event_BillingEssencePointForBoard += this.BillingEssencePointForBoard;
        battleGameController.Event_SettlementBoard += this.BillingEssencePointForBoard;


    }

    /// <summary>
    /// ����L���W�������I
    /// </summary>
    /// <returns>(�O�q�����I,���z�����I,�H�������I,�F����I)</returns>
    private void BillingEssencePointForBoard(object sender, EventArgs e)
    {
        float Red = 0, Blue = 0, Yellow = 0, Purple = 0;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (boardController.puzzles[i, j] != null)
                {
                    PuzzleData puzzle = boardController.puzzles[i, j];
                    switch (puzzle.Essence)
                    {
                        case EssenceClass.Essence.Strengthe_�O�q:
                            Red++;
                            break;
                        case EssenceClass.Essence.Wisdom_���z:
                            Blue++;
                            break;
                        case EssenceClass.Essence.Belief_�H��:
                            Yellow++;
                            break;
                        case EssenceClass.Essence.Soul_�F��:
                            Purple++;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        PartnerEssenceBonus(Red, Blue, Yellow, Purple);
    }
    /// <summary>
    /// �٦񥻽�[��
    /// </summary>
    private void PartnerEssenceBonus(float Red, float Blue, float Yellow, float Purple)
    {
        for (int i = 0; i < battleGameController.partner.Length; i++)
        {
            switch (battleGameController.partner[1].thisPartner.Essence)
            {
                case EssenceClass.Essence.Strengthe_�O�q:
                    Red = Red * 1.5f;
                    break;
                case EssenceClass.Essence.Wisdom_���z:
                    Blue = Blue * 1.5f; ;
                    break;
                case EssenceClass.Essence.Belief_�H��:
                    Yellow = Yellow * 1.5f;
                    break;
                case EssenceClass.Essence.Soul_�F��:
                    Purple = Purple * 1.5f;
                    break;
                default:
                    break;
            }
        }

        Debug.Log($"{Math.Ceiling(Red)} , {Math.Ceiling(Blue)} , {Math.Ceiling(Yellow)} , {Math.Ceiling(Purple)}");
    }

    private (int a, int b) Test(int i)
    {
        int a, b;
        a = i;
        b = i + 1;
        return (a, b);
    }

    public void Test2()
    {
        int c;
        (_, c) = Test(10);
        Debug.Log(c);
    }
}
