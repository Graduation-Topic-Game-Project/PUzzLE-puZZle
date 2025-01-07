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

        if (battleGameController == null) //��������W��BattleGameController
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
            Debug.Log("���~�G�Ĭ��{����Ĳ�o");
    }

    /// <summary>
    /// ����Ĭ�
    /// </summary>
    private void MutualConflict()
    {
        //foreach (int enemyAttack in EnemyAttack)
        {
        }
    }


    /// <summary>
    /// <��{>�Ĭ𶥬q
    /// </summary>
    private IEnumerator ConfrontationCoroutine()
    {
        if (PartnerAttack.Count == 0)
        {
            BattleMainMessage.SetMessage($"��譱�����A�ڤ����{EnemyAttack}�I�ˮ`");
            PlayerBattleData.Instance.Damage(EnemyAttack);
            Stop_Coroutine_Confrontation();
        }

        foreach (int partnerAttack in PartnerAttack)
        {
            if (partnerAttack > EnemyAttack)
            {
                Debug.Log($"��Ĥ�y��{partnerAttack - EnemyAttack}�I�ˮ`");
                BattleMainMessage.SetMessage($"��Ĥ�y��{partnerAttack - EnemyAttack}�I�ˮ`");
                //EnemyDameged
            }

            if (partnerAttack < EnemyAttack)
            {
                Debug.Log($"�ڤ����{EnemyAttack - partnerAttack}�I�ˮ`");
                BattleMainMessage.SetMessage($"�ڤ����{EnemyAttack - partnerAttack}�I�ˮ`");
                PlayerBattleData.Instance.Damage(EnemyAttack - partnerAttack);
            }

            if (partnerAttack == EnemyAttack)
            {
                Debug.Log($"����!");
                BattleMainMessage.SetMessage($"����!");
            }

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        // ��{���槹���A�M�Ťޥ�
        Coroutine_Confrontation = null;
    }
    private void ResetConfronatationData(object sender, EventArgs e) //���m
    {
        PartnerAttack.Clear();
        //EnemyAttack.Clear();
        EnemyAttack = 0;
    }

    public void Stop_Coroutine_Confrontation() // �����{
    {
        if (Coroutine_Confrontation != null)
            StopCoroutine(Coroutine_Confrontation);
    }
}
