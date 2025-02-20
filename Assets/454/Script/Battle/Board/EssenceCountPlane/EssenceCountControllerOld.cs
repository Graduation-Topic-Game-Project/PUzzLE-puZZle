using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EssenceCountControllerOld : MouseEnterAndExit
{
    public BattleGameController battleGameController;
    public SettlementBoardController settlementBoardController;

    public CanvasGroup canvasGroup;
    public float defaultTextAlpha; //預設透明度
    Coroutine NowSetCoroutine;

    public TextMeshProUGUI Red_CountText, Blue_CountText, Yellow_CountText, Purple_CountText;
    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        if (settlementBoardController == null) //獲取場景上的SettlementBoardController
            settlementBoardController = FindObjectOfType<SettlementBoardController>();

        if (canvasGroup == null) //獲取子物件的的CanvasGroup
        {
            //canvasGroup = this.gameObject.transform.GetChild(0).GetComponent<CanvasGroup>();
            canvasGroup = this.gameObject.transform.GetComponent<CanvasGroup>(); //獲取自己的的CanvasGroup
        }

        battleGameController.Event_BattleStart += UpdateText;
        battleGameController.Event_PuzzlePlaceCompleted += UpdateText;
    }
    void Start()
    {
        canvasGroup.alpha = defaultTextAlpha; //透明度設為默認
    }

    private void UpdateText(object sender, EventArgs e) //更新文字
    {
        settlementBoardController.BillingEssencePointForBoard(out float Red, out float Blue, out float Yellow, out float Purple);
        Red_CountText.text = Red.ToString();
        Blue_CountText.text = Blue.ToString();
        Yellow_CountText.text = Yellow.ToString();
        Purple_CountText.text = Purple.ToString();
    }

    /// <summary>
    /// 行動值文字降至半透明
    /// </summary>
    public void ShowActionPoint() // 行動值文字降至半透明
    {
        /*if (NowSetCoroutine != null)
            StopCoroutine(NowSetCoroutine);*/

        NowSetCoroutine = StartCoroutine(ShowActionPoint_Coroutine());
    }

    public IEnumerator ShowActionPoint_Coroutine() //行動值文字降至半透明
    {
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(0.2f);

        for (float i = 1f; i > defaultTextAlpha; i = i - Time.deltaTime)
        {
            canvasGroup.alpha = i;
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
    /// <summary>
    /// 停止協程
    /// </summary>
    public void StopCoroutine()
    {
        if (NowSetCoroutine != null)
            StopCoroutine(NowSetCoroutine);
    }

    protected override void OnPointerEnter() // 在此處執行滑鼠進入的邏輯
    {
        Debug.Log("Pointer entered manually!");
        StopCoroutine();
        //actionPoint_Controller.StopAllCoroutines();
        canvasGroup.alpha = 1f;
    }

    protected override void OnPointerExit() // 在此處執行滑鼠離開的邏輯
    {
        Debug.Log("Pointer exited manually!");
        ShowActionPoint();
    }
}
