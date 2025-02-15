using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 衝突動畫控制器
/// </summary>
public class ConfrontationAnimationController : MonoBehaviour
{
    public BattleGameController battleGameController;

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
    }

    public void Start_Confrontation(BattlePartner partner, Enemy enemy, int partnerCombatPower, int enemyCombatPower)
    {
        StartCoroutine(Confrontation(partner, enemy, partnerCombatPower, enemyCombatPower));
    }

    /// <summary>
    /// <協程> 衝突
    /// </summary>
    private IEnumerator Confrontation(BattlePartner partner, Enemy enemy, int partnerCombatPower, int enemyCombatPower)
    {
        //顯示雙方戰力值
        partner.ShowCombatPower(partnerCombatPower);
        enemy.ShowCombatPower(partnerCombatPower);

        BattleAudioController.PlayAudio_Confrontation(); //撥放交鋒音效
        yield return new WaitForSeconds(0.5f); // 延遲  秒

        partner.ClearCombatPower();
        enemy.ClearCombatPower();
    }
}
