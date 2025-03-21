using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleConfrontationController : MonoBehaviour
{

    public BattleGameController battleGameController;
    public BattlePartnerUiController battlePartnerUiController;
    public BattleEnemyController battleEnemyController;
    public ConfrontationAnimationController confrontationAnimationController;
    public BattleAnimationController battleAnimationController;

    static BattleConfrontationController @this;

    int[] PartnerAttack = new int[4]; //夥伴攻擊數值
    int EnemyAttack = 0;

    /// <summary> [協程]衝突階段 </summary>
    Coroutine Coroutine_Confrontation;

    private void Awake()
    {
        if (@this == null)
        {
            @this = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (battlePartnerUiController == null) //獲取場景上的BattlePartnerUiController
        {
            battlePartnerUiController = FindObjectOfType<BattlePartnerUiController>();
        }
        if (battleEnemyController == null) //獲取場景上的BattleEnemyController
        {
            battleEnemyController = FindObjectOfType<BattleEnemyController>();
        }
        if (battleAnimationController == null) //獲取場景上的BattleAnimationController
        {
            battleAnimationController = FindObjectOfType<BattleAnimationController>();
        }

        //battleGameController.Event_Confrontation += StartConfrontation;
        battleGameController.Event_StartTurn += ResetConfronatationData;
    }

    public static void AddEnemyAttack(int damage)
    {
        @this.EnemyAttack += damage;
    }


    /// <param name="damage">戰力值</param>
    /// <param name="partnerNum">夥伴編號</param>
    public static void AddPartnerAttack(int damage, int partnerNum)
    {
        @this.PartnerAttack[partnerNum] = damage;
    }

    /// <summary> 開始衝突 </summary>
    public IEnumerator StartConfrontation() //開始衝突
    {
        if (Coroutine_Confrontation == null)
        {
            //Coroutine_Confrontation = StartCoroutine(ConfrontationCoroutine());
            yield return StartCoroutine(ConfrontationCoroutine());
        }
        else
            Debug.Log("錯誤：衝突協程重複觸發");
        //yield return null;
    }

    /// <summary>
    /// {協程}衝突階段
    /// </summary>
    public IEnumerator ConfrontationCoroutine()
    {
        //foreach (int partnerAttack in PartnerAttack)
        for (int i = 0; i < PartnerAttack.Length; i++)
        {
            BattlePartner nowBattlePartner = battlePartnerUiController.PartnersGameObject[i].GetComponent<BattlePartner>();
            int partnerAttack = PartnerAttack[i]; //友方戰力值

            //開始衝突
            confrontationAnimationController.Start_Confrontation(
                nowBattlePartner,
                battleGameController.InstancedEnemy[0],
                partnerAttack,
                EnemyAttack
                );

            yield return StartCoroutine(confrontationAnimationController.Start_Confrontation(
                nowBattlePartner,
                battleGameController.InstancedEnemy[0],
                partnerAttack,
                EnemyAttack
                ));

            yield return new WaitForSeconds(0.5f);

            Debug.Log($"{partnerAttack} vs {EnemyAttack}");

            if (partnerAttack == 0) //直接攻擊
            {
                Debug.Log($"直接攻擊! 我方受到{EnemyAttack}點傷害");
                BattleMainMessage.SetMessage($"直接攻擊! 我方受到{EnemyAttack}點傷害");
                PlayerBattleData.Instance.Damage(EnemyAttack);
            }
            else
            {
                if (partnerAttack > EnemyAttack) //勝利
                {
                    Debug.Log($"勝利! 對敵方造成{partnerAttack - EnemyAttack}點傷害");
                    BattleMainMessage.SetMessage($"勝利! 對敵方造成{partnerAttack - EnemyAttack}點傷害");
                    yield return StartCoroutine(battleAnimationController.Start_PlayAttackAnimation(nowBattlePartner)); //撥放夥伴攻擊動畫
                    EnemyDameged.Call_Event_DamageToEnemy(partnerAttack - EnemyAttack);
                }

                if (partnerAttack < EnemyAttack) //失敗
                {
                    Debug.Log($"衝突失敗! 我方受到{EnemyAttack - partnerAttack}點傷害");
                    BattleMainMessage.SetMessage($"衝突失敗! 我方受到{EnemyAttack - partnerAttack}點傷害");
                    PlayerBattleData.Instance.Damage(EnemyAttack - partnerAttack);
                }

                if (partnerAttack == EnemyAttack) //平手
                {
                    Debug.Log($"平手!");
                    BattleMainMessage.SetMessage($"平手!");
                }

                yield return new WaitForSeconds(0.2f);
                ///********
            }
            yield return new WaitForSeconds(0.5f);
        }

        //yield return new WaitForSeconds(0.5f);
        // 協程執行完畢，清空引用
        Coroutine_Confrontation = null;
    }
    private void ResetConfronatationData(object sender, EventArgs e) //重置
    {
        for (int i = 0; i >= PartnerAttack.Length; i++)
        {
            PartnerAttack[i] = 0;
        }

        //EnemyAttack.Clear();
        EnemyAttack = 0;
    }

    public void Stop_Coroutine_Confrontation() // 停止協程
    {
        if (Coroutine_Confrontation != null)
            StopCoroutine(Coroutine_Confrontation);
    }
}
