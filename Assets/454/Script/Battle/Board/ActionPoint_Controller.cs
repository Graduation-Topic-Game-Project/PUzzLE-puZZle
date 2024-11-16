using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ActionPoint_Controller : MonoBehaviour
{
    public BattleGameController battleGameController;
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI actionPoint_Number; //行動值文字

    [SerializeField]
    static public int ActionPoint; //行動值
    public int maxActionPoint; //最大行動值
    float actionPointTextAlpha = 0.5f; //行動值文字預設透明度

    Coroutine NowSetCoroutine;


    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (canvasGroup == null) //獲取場景上的CanvasGroup
        {
            canvasGroup = this.gameObject.transform.GetComponent<CanvasGroup>();
        }

        battleGameController.Event_PuzzlePlaceCompleted += this.PuzzlePlaceCompleted_ActionPoint; //放置拼圖後減少行動值
        battleGameController.Event_EndTurn += this.Reset_ActionPoint;
    }
    void Start()
    {
        Reset_ActionPoint(this, EventArgs.Empty); //將行動值提升至最大值
        canvasGroup.alpha = actionPointTextAlpha;
    }

    void Update()
    {
        actionPoint_Number.text = ActionPoint.ToString();
    }

    /// <summary>
    /// 放置拼圖後減少行動值
    /// </summary>
    void PuzzlePlaceCompleted_ActionPoint(object sender, EventArgs e)
    {
        ActionPoint--;
    }

    /// <summary>
    /// 將行動值回復至最大值
    /// </summary>
    private void Reset_ActionPoint(object sender, EventArgs e)
    {
        ActionPoint = maxActionPoint;
    }

    /// <summary>
    /// 行動值文字降至半透明
    /// </summary>
    public void ShowActionPoint()
    {
        /*if (NowSetCoroutine != null)
            StopCoroutine(NowSetCoroutine);*/

        NowSetCoroutine = StartCoroutine(ShowActionPoint_Coroutine());
    }

    public IEnumerator ShowActionPoint_Coroutine() //行動值文字降至半透明
    {
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(0.2f);

        for (float i = 1f; i > actionPointTextAlpha; i = i - Time.deltaTime)
        {
            canvasGroup.alpha = i;
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }

    public void StopCoroutine()
    {
        if (NowSetCoroutine != null)
            StopCoroutine(NowSetCoroutine);
    }

}
