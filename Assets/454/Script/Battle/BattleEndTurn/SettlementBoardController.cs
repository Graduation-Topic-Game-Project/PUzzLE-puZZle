using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 結算盤面拼圖&計算屬性加成&對敵人造成傷害
/// </summary>
public class SettlementBoardController : MonoBehaviour
{
    private BattleGameController battleGameController;
    private BoardController boardController;
    /// <summary> 給予敵方傷害 </summary>
    public static event Action<int, int, int, int> Event_Damage; //給予敵方傷害

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        if (boardController == null) //獲取場景上的BoardController   
            boardController = FindObjectOfType<BoardController>();

        battleGameController.Event_SettlementBoard += this.BillingEndTurnAttack;
    }

    /// <summary>
    /// 回合結束時結算並攻擊
    /// </summary>
    private void BillingEndTurnAttack(object sender, EventArgs e)
    {
        BillingEssencePointForBoard(out float Red, out float Blue, out float Yellow, out float Purple); //結算盤面
        PartnerEssenceBonus(Red, Blue, Yellow, Purple);
    }



    /// <summary>
    /// 結算盤面上的本質點
    /// </summary>
    /// <returns>(力量本質點,智慧本質點,信仰本質點,靈魂本質點)</returns>
    private void BillingEssencePointForBoard(out float Red_num, out float Blue_num, out float Yellow_num, out float Purple_num)
    {
        Red_num = 0; Blue_num = 0; Yellow_num = 0; Purple_num = 0;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (boardController.board[i, j].Puzzle != null)
                {
                    PuzzleData puzzle = boardController.board[i, j].Puzzle;
                    switch (puzzle.Essence)
                    {
                        case EssenceEnum.Essence.Strengthe_力量:
                            Red_num++;
                            break;
                        case EssenceEnum.Essence.Wisdom_智慧:
                            Blue_num++;
                            break;
                        case EssenceEnum.Essence.Belief_信仰:
                            Yellow_num++;
                            break;
                        case EssenceEnum.Essence.Soul_靈魂:
                            Purple_num++;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        //PartnerEssenceBonus(Red, Blue, Yellow, Purple);
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
    }

    private int ToInt(float num) //無條件進位成整數
    {
        int a = (int)Math.Ceiling(num);
        return a;
    }


}
