using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleConfrontationController : MonoBehaviour
{
    public BattleGameController battleGameController;
    static BattleConfrontationController @this;

    int[] PartnerAttack = new int[4]; //�٦�����ƭ�
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

    
    /// <param name="damage">�ԤO��</param>
    /// <param name="partnerNum">�٦�s��</param>
    public static void AddPartnerAttack(int damage, int partnerNum)
    {
        @this.PartnerAttack[partnerNum] = damage;
    }

    /// <summary> �}�l�Ĭ� </summary>
    public void StartConfrontation() //�}�l�Ĭ�
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
        /*if (PartnerAttack.Length == 0)
        {
            BattleMainMessage.SetMessage($"��譱�����A�ڤ����{EnemyAttack}�I�ˮ`");
            PlayerBattleData.Instance.Damage(EnemyAttack);
            Stop_Coroutine_Confrontation();
        }*/

        foreach (int partnerAttack in PartnerAttack)
        {
            Debug.Log($"{partnerAttack} vs {EnemyAttack}");

            if (partnerAttack > EnemyAttack)
            {
                Debug.Log($"�ӧQ! ��Ĥ�y��{partnerAttack - EnemyAttack}�I�ˮ`");
                BattleMainMessage.SetMessage($"�ӧQ! ��Ĥ�y��{partnerAttack - EnemyAttack}�I�ˮ`");
                EnemyDameged.Call_Event_DamageToEnemy(partnerAttack - EnemyAttack);
            }

            if (partnerAttack < EnemyAttack)
            {
                Debug.Log($"�Ĭ𥢱�! �ڤ����{EnemyAttack - partnerAttack}�I�ˮ`");
                BattleMainMessage.SetMessage($"�Ĭ𥢱�! �ڤ����{EnemyAttack - partnerAttack}�I�ˮ`");
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
        for (int i = 0; i >= PartnerAttack.Length; i++)
        {
            PartnerAttack[i] = 0;
        }

        //EnemyAttack.Clear();
        EnemyAttack = 0;
    }

    public void Stop_Coroutine_Confrontation() // �����{
    {
        if (Coroutine_Confrontation != null)
            StopCoroutine(Coroutine_Confrontation);
    }
}
