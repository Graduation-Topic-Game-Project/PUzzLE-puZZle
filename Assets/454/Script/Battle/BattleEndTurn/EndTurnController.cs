using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnController : MonoBehaviour
{
    public BattleGameController battleGameController;

    Coroutine Coroutine_EndTurn;

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
    }


    public void StartEndTurn()
    {
        if (Coroutine_EndTurn == null)
        {
            Coroutine_EndTurn = StartCoroutine(EndTurnCoroutine());
        }
        else
            Debug.Log("�ӫ�F");
    }

    /// <summary>
    /// <��{>�����^�X
    /// </summary>
    private IEnumerator EndTurnCoroutine()
    {
        // ����L��
        battleGameController.CallEvent_SettlementBoard();
        yield return new WaitForSeconds(0.5f); // �i�ھڻݨD�վ㩵��ɶ�

        // ����ĤH�ޯ�
        battleGameController.CallEvent_SettlementEnemySkill();
        yield return new WaitForSeconds(0.1f);

        // �ޯ�Ĭ�
        battleGameController.CallEvent_Confrontation();
        yield return new WaitForSeconds(1.5f); //�ƭȤӧC�|bug,����n�ﱼ

        // �����^�X
        battleGameController.CallEvent_EndTurn();
        yield return new WaitForSeconds(0.5f);

        // �}�l�s�^�X
        battleGameController.CallEvent_StartTurn();
        yield return new WaitForSeconds(0.5f);

        // ��{���槹���A�M�Ťޥ�
        Coroutine_EndTurn = null;
    }

    private void OnDestroy()
    {
        if (Coroutine_EndTurn != null)
        {
            StopCoroutine(Coroutine_EndTurn);
            Coroutine_EndTurn = null;
        }
    }
}
