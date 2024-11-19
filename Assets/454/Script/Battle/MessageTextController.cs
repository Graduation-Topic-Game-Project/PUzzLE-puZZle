using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageTextController : MonoBehaviour
{
    TextMeshProUGUI messageText;
    static MessageTextController @this;
    Color textColor;

    Coroutine NowSetMessange;

    private void Awake()
    {
        if (@this == null)
            @this = this;

        messageText = this.GetComponent<TextMeshProUGUI>();
    }

    public void SetColorAlpha(float _alpha) //設置文字透明度
    {
        messageText.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, _alpha);
    }

    public static void SetMessage(string messange)
    {
        if (@this.NowSetMessange != null)
            @this.StopCoroutine(@this.NowSetMessange);
        @this.SetColorAlpha(0f);
        @this.NowSetMessange = @this.StartCoroutine(@this.SetMessage3s(messange));

        Debug.Log(messange);
    }


    public IEnumerator SetMessage3s(string messange) //顯示訊息3秒
    {
        SetColorAlpha(1f);
        messageText.text = messange;

        yield return new WaitForSeconds(2);

        for (float i = 1f; i > 0; i = i - Time.deltaTime)
        {
            SetColorAlpha(i);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }

}
