using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Ĭ�ʵe���
/// </summary>
public class ConfrontationAnimationController : MonoBehaviour
{
    public BattleGameController battleGameController;

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
    }

    public void Start_Confrontation(BattlePartner partner, Enemy enemy, int partnerCombatPower, int enemyCombatPower)
    {
        StartCoroutine(Confrontation(partner, enemy, partnerCombatPower, enemyCombatPower));
    }

    /// <summary>
    /// <��{> �Ĭ�
    /// </summary>
    private IEnumerator Confrontation(BattlePartner partner, Enemy enemy, int partnerCombatPower, int enemyCombatPower)
    {
        //�������ԤO��
        partner.ShowCombatPower(partnerCombatPower);
        enemy.ShowCombatPower(partnerCombatPower);

        BattleAudioController.PlayAudio_Confrontation(); //�����W����
        yield return new WaitForSeconds(0.5f); // ����  ��

        partner.ClearCombatPower();
        enemy.ClearCombatPower();
    }
}
