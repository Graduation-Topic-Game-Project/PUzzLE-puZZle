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
    public float actionPointTextAlpha = 0.1f; //行動值文字預設透明度
    [Header("是否開啟控制器功能")]
    [Tooltip("啟用後才有作為控制器功能，關閉時作為單純展示行動值用。請確保場景內只有一個開啟")]
    public bool isController;

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

        if (isController == true) //是否作為控制器
        {
            battleGameController.Event_PuzzlePlaceCompleted += this.PuzzlePlaceCompleted_ActionPoint; //放置拼圖後減少行動值
            battleGameController.Event_StartTurn += this.Reset_ActionPoint; //回合開始重製行動值
        }
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

        for (float i = 1f; i > actionPointTextAlpha; i = i - Time.deltaTime)
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

}
