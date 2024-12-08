using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    public BattleGameController battleGameController;
    Button _button;
    Coroutine Coroutine_EndTurn;



    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }

        _button = GetComponent<Button>(); //�q�\�����I���ƥ�
        _button.onClick.AddListener(EndTurnButtonOnClick);
    }

    private void EndTurnButtonOnClick()
    {
        if (Coroutine_EndTurn == null)
            Coroutine_EndTurn = StartCoroutine(EndTurnCoroutine());
        else
            Debug.Log("�ӫ�F");
    }

    /// <summary>
    /// <��{>�����^�X
    /// </summary>
    /// <returns></returns>
    private IEnumerator EndTurnCoroutine()
    {
        // ����L��
        battleGameController.CallEvent_SettlementBoard();
        yield return new WaitForSeconds(0.5f); // �i�ھڻݨD�վ㩵��ɶ�

        // ����ĤH�ޯ�
        battleGameController.CallEvent_SettlementEnemySkill();
        yield return new WaitForSeconds(0.5f);

        // �����^�X
        battleGameController.CallEvent_EndTurn();
        yield return new WaitForSeconds(0.5f);

        // �}�l�s�^�X
        battleGameController.CallEvent_StartTurn();

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
