using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// �԰��������٦�p�H��UI
/// </summary>
public class BattlePartner : MonoBehaviour
{
    public int PartnerNumber;
    public Image PartnerImage;
    public TextMeshProUGUI CombatPowerNumber; //�Ĭ�ԤO�Ȥ�r

    /// <summary> ��ܾԤO�� </summary>
    /// <param name="_combatPower">�ԤO��</param>
    public void ShowCombatPower(int _combatPower)
    {
        Color color = CombatPowerNumber.color; //���}�z����
        color.a = 1f;
        CombatPowerNumber.color = color;

        CombatPowerNumber.text = _combatPower.ToString();
    }

    /// <summary> ���þԤO��UI </summary>
    public void ClearCombatPower()
    {
        Color color = CombatPowerNumber.color; //�����z����
        color.a = 0f;
        CombatPowerNumber.color = color;
    }
}
