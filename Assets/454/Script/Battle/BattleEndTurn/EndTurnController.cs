using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public BattleConfrontationController battleConfrontationController;

    public GameObject UIMask; //UI阻擋遮罩
    public GameObject InspirationObject;
    Coroutine Coroutine_EndTurn;

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (battleConfrontationController == null) //獲取場景上的BattleConfrontationController
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
            Debug.Log("太急了");
    }

    /// <summary>
    /// <協程>結束回合
    /// </summary>
    private IEnumerator EndTurnCoroutine()
    {
        UIMask.SetActive(true);
        //InspirationObject.SetActive(false);

        // 結算盤面
        battleGameController.CallEvent_SettlementBoard();
        yield return new WaitForSeconds(0.5f); // 可根據需求調整延遲時間

        // 結算敵人技能
        battleGameController.CallEvent_SettlementEnemySkill();
        yield return new WaitForSeconds(0.1f);

        // 技能衝突
        battleGameController.CallEvent_Confrontation();
        yield return StartCoroutine(battleConfrontationController.StartConfrontation());

        // 結束回合
        battleGameController.CallEvent_EndTurn();
        yield return new WaitForSeconds(0.5f);

        // 開始新回合
        battleGameController.CallEvent_StartTurn();
        yield return new WaitForSeconds(0.5f);

        // 協程執行完畢，清空引用
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
