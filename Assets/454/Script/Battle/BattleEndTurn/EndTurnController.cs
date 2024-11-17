using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndTurnController : MonoBehaviour
{
    private BattleGameController battleGameController;
    private BoardController boardController;

    public static event Action<int,int,int,int> Event_Damage; //給予傷害

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
                        case EssenceEnum.Essence.Strengthe_力量:
                            Red++;
                            break;
                        case EssenceEnum.Essence.Wisdom_智慧:
                            Blue++;
                            break;
                        case EssenceEnum.Essence.Belief_信仰:
                            Yellow++;
                            break;
                        case EssenceEnum.Essence.Soul_靈魂:
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
        for (int i = 0; i < battleGameController.partners.Length; i++)
        {
            switch (battleGameController.partners[1].thisPartner.Essence)
            {
                case EssenceEnum.Essence.Strengthe_力量:
                    Red = Red * 1.5f;
                    break;
                case EssenceEnum.Essence.Wisdom_智慧:
                    Blue = Blue * 1.5f; ;
                    break;
                case EssenceEnum.Essence.Belief_信仰:
                    Yellow = Yellow * 1.5f;
                    break;
                case EssenceEnum.Essence.Soul_靈魂:
                    Purple = Purple * 1.5f;
                    break;
                default:
                    break;
            }
        }

        Debug.Log($"{Math.Ceiling(Red)} , {Math.Ceiling(Blue)} , {Math.Ceiling(Yellow)} , {Math.Ceiling(Purple)}");
        Event_Damage?.Invoke(ToInt(Red), ToInt(Blue), ToInt(Yellow), ToInt(Purple));

        //TestDamage((int)(Math.Ceiling(Red + Blue + Yellow + Purple)));
    }

    private int ToInt(float num) //無條件進位成整數
    {
        int a = (int)Math.Ceiling(num);
        return a;
    }

    
}
