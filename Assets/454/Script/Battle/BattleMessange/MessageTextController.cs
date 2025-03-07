using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageTextController : MonoBehaviour
{
    public TextMeshProUGUI messageText;


    [Header("�T����ܬ��"), Tooltip("���n���H�X�A�H�X�ɶ��T�w1��")]
    public int secondsDisplayed;

    Coroutine NowSetMessangeCoroutine;


    protected void Open_and_SetMessage(string messange)
    {
        if (NowSetMessangeCoroutine != null)
            StopCoroutine(NowSetMessangeCoroutine); //����ثe��{
        SetColorAlpha(0f, messageText); //��r�ܳz��
        NowSetMessangeCoroutine = StartCoroutine(SetMessageCoroutine(messange, secondsDisplayed));
    }


    protected void SetColorAlpha(float _alpha, TextMeshProUGUI textObject) //�]�m��r�z����
    {
        textObject.color = new Color(textObject.color.r, textObject.color.g, textObject.color.b, _alpha);
    }

    protected virtual IEnumerator SetMessageCoroutine(string messange, int second) //��ܰT����{
    {
        SetColorAlpha(1f, messageText);
        messageText.text = messange;

        yield return new WaitForSeconds(second); //���n���

        for (float i = 1f; i > 0; i = i - Time.deltaTime) //�b1���H�X
        {
            SetColorAlpha(i, messageText);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }

}
