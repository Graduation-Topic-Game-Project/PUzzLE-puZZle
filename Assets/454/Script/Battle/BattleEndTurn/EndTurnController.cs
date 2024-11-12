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
        if (battleGameController == null) //獲取場景上的BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        if (boardController == null) //獲取場景上的BoardController   
            boardController = FindObjectOfType<BoardController>();

        //battleGameController.Event_BillingEssencePointForBoard += this.BillingEssencePointForBoard;
        battleGameController.Event_SettlementBoard += this.BillingEssencePointForBoard;

        //battleGameController.Event_EndTurn += Test;


    }

    /// <summary>
    /// 結算盤面上的本質點
    /// </summary>
    /// <returns>(力量本質點,智慧本質點,信仰本質點,靈魂本質點)</returns>
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
                        case EssenceClass.Essence.Strengthe_力量:
                            Red++;
                            break;
                        case EssenceClass.Essence.Wisdom_智慧:
                            Blue++;
                            break;
                        case EssenceClass.Essence.Belief_信仰:
                            Yellow++;
                            break;
                        case EssenceClass.Essence.Soul_靈魂:
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
    /// 夥伴本質加成
    /// </summary>
    private void PartnerEssenceBonus(float Red, float Blue, float Yellow, float Purple)
    {
        for (int i = 0; i < battleGameController.partner.Length; i++)
        {
            switch (battleGameController.partner[1].thisPartner.Essence)
            {
                case EssenceClass.Essence.Strengthe_力量:
                    Red = Red * 1.5f;
                    break;
                case EssenceClass.Essence.Wisdom_智慧:
                    Blue = Blue * 1.5f; ;
                    break;
                case EssenceClass.Essence.Belief_信仰:
                    Yellow = Yellow * 1.5f;
                    break;
                case EssenceClass.Essence.Soul_靈魂:
                    Purple = Purple * 1.5f;
                    break;
                default:
                    break;
            }
        }

        Debug.Log($"{Math.Ceiling(Red)} , {Math.Ceiling(Blue)} , {Math.Ceiling(Yellow)} , {Math.Ceiling(Purple)}");

        //TestDamage((int)(Math.Ceiling(Red + Blue + Yellow + Purple)));
    }

    private void TestDamage(int damage)
    {
        Player.Damage(damage);
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
