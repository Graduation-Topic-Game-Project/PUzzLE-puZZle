using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    public BattleGameController battleGameController;
    Button _button;
    //public GameObject EndTurnButton;


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
        /*battleGameController.CallEvent_SettlementBoard(); //����L��
        battleGameController.CallEvent_SettlementEnemySkill(); //����ĤH�ޯ�
        battleGameController.CallEvent_EndTurn(); //�����^�X
        battleGameController.CallEvent_StartTurn(); //�^�X�}�l
        */

        StartCoroutine(EndTurnCoroutine());
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
    }
}
