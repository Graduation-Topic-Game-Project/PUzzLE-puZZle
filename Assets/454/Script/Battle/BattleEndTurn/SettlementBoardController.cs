using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ����L������&�p���ݩʥ[��&��ĤH�y���ˮ`
/// </summary>
public class SettlementBoardController : MonoBehaviour
{
    private BattleGameController battleGameController;
    private BoardController boardController;
    /// <summary> �����Ĥ�ˮ` </summary>
    public static event Action<int, int, int, int> Event_Damage; //�����Ĥ�ˮ`

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        if (boardController == null) //��������W��BoardController   
            boardController = FindObjectOfType<BoardController>();

        battleGameController.Event_SettlementBoard += this.BillingEndTurnAttack;
    }

    /// <summary>
    /// �^�X�����ɵ���ç���
    /// </summary>
    private void BillingEndTurnAttack(object sender, EventArgs e)
    {
        BillingEssencePointForBoard(out float Red, out float Blue, out float Yellow, out float Purple); //����L��
        PartnerEssenceBonus(Red, Blue, Yellow, Purple);
    }



    /// <summary>
    /// ����L���W�������I
    /// </summary>
    /// <returns>(�O�q�����I,���z�����I,�H�������I,�F����I)</returns>
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
                        case EssenceEnum.Essence.Strengthe_�O�q:
                            Red_num++;
                            break;
                        case EssenceEnum.Essence.Wisdom_���z:
                            Blue_num++;
                            break;
                        case EssenceEnum.Essence.Belief_�H��:
                            Yellow_num++;
                            break;
                        case EssenceEnum.Essence.Soul_�F��:
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
    }

    private int ToInt(float num) //�L����i�즨���
    {
        int a = (int)Math.Ceiling(num);
        return a;
    }


}
