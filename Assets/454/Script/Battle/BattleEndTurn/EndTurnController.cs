using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndTurnController : MonoBehaviour
{
    private BattleGameController battleGameController;
    private BoardController boardController;

    public static event Action<int,int,int,int> Event_Damage; //�����ˮ`

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        if (boardController == null) //��������W��BoardController   
            boardController = FindObjectOfType<BoardController>();

        //battleGameController.Event_BillingEssencePointForBoard += this.BillingEssencePointForBoard;
        battleGameController.Event_SettlementBoard += this.BillingEssencePointForBoard;

        //battleGameController.Event_EndTurn += Test;


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
                        case EssenceEnum.Essence.Strengthe_�O�q:
                            Red++;
                            break;
                        case EssenceEnum.Essence.Wisdom_���z:
                            Blue++;
                            break;
                        case EssenceEnum.Essence.Belief_�H��:
                            Yellow++;
                            break;
                        case EssenceEnum.Essence.Soul_�F��:
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
        for (int i = 0; i < battleGameController.partners.Length; i++)
        {
            switch (battleGameController.partners[1].thisPartner.Essence)
            {
                case EssenceEnum.Essence.Strengthe_�O�q:
                    Red = Red * 1.5f;
                    break;
                case EssenceEnum.Essence.Wisdom_���z:
                    Blue = Blue * 1.5f; ;
                    break;
                case EssenceEnum.Essence.Belief_�H��:
                    Yellow = Yellow * 1.5f;
                    break;
                case EssenceEnum.Essence.Soul_�F��:
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

    private int ToInt(float num) //�L����i�즨���
    {
        int a = (int)Math.Ceiling(num);
        return a;
    }

    
}
