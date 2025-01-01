using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionPoint_UI_Controller : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI actionPoint_Number; //行動值文字

    public float actionPointTextAlpha = 0.1f; //行動值文字預設透明度
    Coroutine NowSetCoroutine;

    private void Awake()
    {
        if (canvasGroup == null) //獲取場景上的CanvasGroup
        {
            canvasGroup = this.gameObject.transform.GetComponent<CanvasGroup>();
        }
    }

    void Start()
    {
        canvasGroup.alpha = actionPointTextAlpha;
    }

    void Update()
    {
        actionPoint_Number.text = ActionPoint_Controller.ActionPoint.ToString();
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
