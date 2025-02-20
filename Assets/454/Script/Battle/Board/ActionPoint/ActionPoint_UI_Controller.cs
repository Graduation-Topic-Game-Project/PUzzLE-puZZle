using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionPoint_UI_Controller : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI actionPoint_Number; //��ʭȤ�r

    public float actionPointTextAlpha; //��ʭȤ�r�w�]�z����
    Coroutine NowSetCoroutine;

    private void Awake()
    {
        if (canvasGroup == null) //���������W��CanvasGroup
        {
            canvasGroup = this.gameObject.transform.GetComponent<CanvasGroup>();
        }
    }

    void Start()
    {
        canvasGroup.alpha = actionPointTextAlpha; //�z���׳]���q�{
    }

    void Update()
    {
        actionPoint_Number.text = ActionPoint_Controller.ActionPoint.ToString();
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

        yield return new WaitForSeconds(1.2f);  //��ܮɶ�

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
