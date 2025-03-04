using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public BattleConfrontationController battleConfrontationController;

    public GameObject UIMask; //UI���׾B�n
    public GameObject InspirationObject;
    Coroutine Coroutine_EndTurn;

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (battleConfrontationController == null) //��������W��BattleConfrontationController
        {
            battleConfrontationController = FindObjectOfType<BattleConfrontationController>();
        }

        UIMask.SetActive(false);
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
        UIMask.SetActive(true);
        //InspirationObject.SetActive(false);

        // ����L��
        battleGameController.CallEvent_SettlementBoard();
        yield return new WaitForSeconds(0.5f); // �i�ھڻݨD�վ㩵��ɶ�

        // ����ĤH�ޯ�
        battleGameController.CallEvent_SettlementEnemySkill();
        yield return new WaitForSeconds(0.1f);

        // �ޯ�Ĭ�
        battleGameController.CallEvent_Confrontation();
        yield return StartCoroutine(battleConfrontationController.StartConfrontation());

        // �����^�X
        battleGameController.CallEvent_EndTurn();
        yield return new WaitForSeconds(0.5f);

        // �}�l�s�^�X
        battleGameController.CallEvent_StartTurn();
        yield return new WaitForSeconds(0.5f);

        // ��{���槹���A�M�Ťޥ�
        Coroutine_EndTurn = null;

        UIMask.SetActive(false);
        //InspirationObject.SetActive(true);
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
