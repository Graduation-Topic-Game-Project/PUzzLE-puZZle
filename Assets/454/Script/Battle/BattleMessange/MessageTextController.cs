using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageTextController : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    //static MessageTextController @this;

    [Header("訊息顯示秒數"), Tooltip("顯示n秒後淡出，淡出時間固定1秒")]
    public int secondsDisplayed;

    Coroutine NowSetMessangeCoroutine;


    protected void Open_and_SetMessage(string messange)
    {
        if (NowSetMessangeCoroutine != null)
            StopCoroutine(NowSetMessangeCoroutine); //停止目前協程
        SetColorAlpha(0f, messageText); //文字變透明
        NowSetMessangeCoroutine = StartCoroutine(SetMessageCoroutine(messange, secondsDisplayed));
    }


    void SetColorAlpha(float _alpha, TextMeshProUGUI textObject) //設置文字透明度
    {
        textObject.color = new Color(textObject.color.r, textObject.color.g, textObject.color.b, _alpha);
    }

    protected virtual IEnumerator SetMessageCoroutine(string messange,int second) //顯示訊息協程
    {
        SetColorAlpha(1f, messageText);
        messageText.text = messange;

        yield return new WaitForSeconds(second); //顯示n秒後

        for (float i = 1f; i > 0; i = i - Time.deltaTime) //在1秒內淡出
        {
            SetColorAlpha(i, messageText);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }

    /*public IEnumerator SetLinkageMessage2s(string messange) //顯示訊息2秒
    {
        SetColorAlpha(1f, linkageText);
        linkageText.text = messange;

        yield return new WaitForSeconds(secondsDisplayed);

        for (float i = 1f; i > 0; i = i - Time.deltaTime) //在1秒內淡出
        {
            SetColorAlpha(i, linkageText);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }*/

}
