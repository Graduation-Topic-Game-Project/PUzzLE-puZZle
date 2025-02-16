using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 戰鬥場景的夥伴小人的UI
/// </summary>
public class BattlePartner : MonoBehaviour
{
    /// <summary> 夥伴資料 </summary>
    public Partner partner;
    /// <summary> 夥伴位置編號 </summary>
    public int PartnerNumber;

    public Image PartnerImage;
    /// <summary> 衝突戰力值文字 </summary>
    public TextMeshProUGUI CombatPowerNumber; //衝突戰力值文字

    /// <summary> 顯示戰力值 </summary>
    /// <param name="_combatPower">戰力值</param>
    public void ShowCombatPower(int _combatPower)
    {
        Color color = CombatPowerNumber.color; //打開透明度
        color.a = 1f;
        CombatPowerNumber.color = color;

        CombatPowerNumber.text = _combatPower.ToString();
    }

    /// <summary> 隱藏戰力值UI </summary>
    public void ClearCombatPower()
    {
        Color color = CombatPowerNumber.color; //關閉透明度
        color.a = 0f;
        CombatPowerNumber.color = color;
    }
}
