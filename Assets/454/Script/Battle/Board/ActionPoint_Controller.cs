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
    public TextMeshProUGUI actionPoint_Number; //��ʭȤ�r

    [SerializeField]
    static public int ActionPoint; //��ʭ�
    public int maxActionPoint; //�̤j��ʭ�
    public float actionPointTextAlpha = 0.1f; //��ʭȤ�r�w�]�z����
    [Header("�O�_�}�ұ���\��")]
    [Tooltip("�ҥΫ�~���@������\��A�����ɧ@����®i�ܦ�ʭȥΡC�нT�O�������u���@�Ӷ}��")]
    public bool isController;

    Coroutine NowSetCoroutine;
    


    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (canvasGroup == null) //��������W��CanvasGroup
        {
            canvasGroup = this.gameObject.transform.GetComponent<CanvasGroup>();
        }

        if (isController == true) //�O�_�@�����
        {
            battleGameController.Event_PuzzlePlaceCompleted += this.PuzzlePlaceCompleted_ActionPoint; //��m���ϫ��֦�ʭ�
            battleGameController.Event_StartTurn += this.Reset_ActionPoint; //�^�X�}�l���s��ʭ�
        }
    }
    void Start()
    {
        Reset_ActionPoint(this, EventArgs.Empty); //�N��ʭȴ��ɦ̤ܳj��
        canvasGroup.alpha = actionPointTextAlpha;
    }

    void Update()
    {
        actionPoint_Number.text = ActionPoint.ToString();
    }

    /// <summary>
    /// ��m���ϫ��֦�ʭ�
    /// </summary>
    void PuzzlePlaceCompleted_ActionPoint(object sender, EventArgs e)
    {
        ActionPoint--;
    }

    /// <summary>
    /// �N��ʭȦ^�_�̤ܳj��
    /// </summary>
    private void Reset_ActionPoint(object sender, EventArgs e)
    {
        ActionPoint = maxActionPoint;
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

        for (float i = 1f; i > actionPointTextAlpha; i = i - Time.deltaTime)
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

}
