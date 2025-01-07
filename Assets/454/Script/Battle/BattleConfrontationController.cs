using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleConfrontationController : MonoBehaviour
{
    public BattleGameController battleGameController;
    static BattleConfrontationController @this;

    List<int> PartnerAttack = new List<int>();
    int EnemyAttack = 0;

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
        battleGameController.Event_Confrontation += StartConfrontation;
        battleGameController.Event_StartTurn += ResetConfronatationData;
    }

    public static void AddEnemyAttack(int damage)
    {
        @this.EnemyAttack += damage;
    }

    public void StartConfrontation()
    {
        if (Coroutine_Confrontation == null)
        {
            Coroutine_Confrontation = StartCoroutine(ConfrontationCoroutine());
        }
        else
            Debug.Log("錯誤：衝突協程重複觸發");
    }

    /// <summary>
    /// 雙方衝突
    /// </summary>
    private void MutualConflict()
    {
        //foreach (int enemyAttack in EnemyAttack)
        {
        }
    }


    /// <summary>
    /// <協程>衝突階段
    /// </summary>
    private IEnumerator ConfrontationCoroutine()
    {
        if (PartnerAttack.Count == 0)
        {
            BattleMainMessage.SetMessage($"單方面受擊，我方受到{EnemyAttack}點傷害");
            PlayerBattleData.Instance.Damage(EnemyAttack);
            Stop_Coroutine_Confrontation();
        }

        foreach (int partnerAttack in PartnerAttack)
        {
            if (partnerAttack > EnemyAttack)
            {
                Debug.Log($"對敵方造成{partnerAttack - EnemyAttack}點傷害");
                BattleMainMessage.SetMessage($"對敵方造成{partnerAttack - EnemyAttack}點傷害");
                //EnemyDameged
            }

            if (partnerAttack < EnemyAttack)
            {
                Debug.Log($"我方受到{EnemyAttack - partnerAttack}點傷害");
                BattleMainMessage.SetMessage($"我方受到{EnemyAttack - partnerAttack}點傷害");
                PlayerBattleData.Instance.Damage(EnemyAttack - partnerAttack);
            }

            if (partnerAttack == EnemyAttack)
            {
                Debug.Log($"平手!");
                BattleMainMessage.SetMessage($"平手!");
            }

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        // 協程執行完畢，清空引用
        Coroutine_Confrontation = null;
    }
    private void ResetConfronatationData(object sender, EventArgs e) //重置
    {
        PartnerAttack.Clear();
        //EnemyAttack.Clear();
        EnemyAttack = 0;
    }

    public void Stop_Coroutine_Confrontation() // 停止協程
    {
        if (Coroutine_Confrontation != null)
            StopCoroutine(Coroutine_Confrontation);
    }
}
