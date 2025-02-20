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
    public float defaultTextAlpha; //�w�]�z����
    Coroutine NowSetCoroutine;

    public TextMeshProUGUI Red_CountText, Blue_CountText, Yellow_CountText, Purple_CountText;
    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        if (settlementBoardController == null) //��������W��SettlementBoardController
            settlementBoardController = FindObjectOfType<SettlementBoardController>();

        if (canvasGroup == null) //����l���󪺪�CanvasGroup
        {
            //canvasGroup = this.gameObject.transform.GetChild(0).GetComponent<CanvasGroup>();
            canvasGroup = this.gameObject.transform.GetComponent<CanvasGroup>(); //����ۤv����CanvasGroup
        }

        battleGameController.Event_BattleStart += UpdateText;
        battleGameController.Event_PuzzlePlaceCompleted += UpdateText;
    }
    void Start()
    {
        canvasGroup.alpha = defaultTextAlpha; //�z���׳]���q�{
    }

    private void UpdateText(object sender, EventArgs e) //��s��r
    {
        settlementBoardController.BillingEssencePointForBoard(out float Red, out float Blue, out float Yellow, out float Purple);
        Red_CountText.text = Red.ToString();
        Blue_CountText.text = Blue.ToString();
        Yellow_CountText.text = Yellow.ToString();
        Purple_CountText.text = Purple.ToString();
    }

    /// <summary>
    /// ��ʭȤ�r���ܥb�z��
    /// </summary>
    public void ShowActionPoint() // ��ʭȤ�r���ܥb�z��
    {
        /*if (NowSetCoroutine != null)
            StopCoroutine(NowSetCoroutine);*/

        NowSetCoroutine = StartCoroutine(ShowActionPoint_Coroutine());
    }

    public IEnumerator ShowActionPoint_Coroutine() //��ʭȤ�r���ܥb�z��
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
    /// �����{
    /// </summary>
    public void StopCoroutine()
    {
        if (NowSetCoroutine != null)
            StopCoroutine(NowSetCoroutine);
    }

    protected override void OnPointerEnter() // �b���B����ƹ��i�J���޿�
    {
        Debug.Log("Pointer entered manually!");
        StopCoroutine();
        //actionPoint_Controller.StopAllCoroutines();
        canvasGroup.alpha = 1f;
    }

    protected override void OnPointerExit() // �b���B����ƹ����}���޿�
    {
        Debug.Log("Pointer exited manually!");
        ShowActionPoint();
    }
}
