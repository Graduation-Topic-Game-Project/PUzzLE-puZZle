using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageTextController : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI linkageText;
    static MessageTextController @this;
    Color textColor;

    [Header("�T����ܬ��"), Tooltip("")]
    public int secondsDisplayed;

    Coroutine NowSetMessange;
    Coroutine NowSetLinkageMessange;

    private void Awake()
    {
        if (@this == null)
            @this = this;

        //messageText = this.GetComponent<TextMeshProUGUI>();
        messageText.text = "";
        linkageText.text = "";
    }



    public static void SetMessage(string messange)
    {
        if (@this.NowSetMessange != null)
            @this.StopCoroutine(@this.NowSetMessange);
        @this.SetColorAlpha(0f, @this.messageText);
        @this.NowSetMessange = @this.StartCoroutine(@this.SetMessage2s(messange));
    }

    public static void SetLinkageMessage(string messange)
    {
        if (@this.NowSetLinkageMessange != null)
            @this.StopCoroutine(@this.NowSetLinkageMessange);
        @this.SetColorAlpha(0f, @this.linkageText);
        @this.NowSetLinkageMessange = @this.StartCoroutine(@this.SetLinkageMessage2s(messange));
    }

    void SetColorAlpha(float _alpha, TextMeshProUGUI textObject) //�]�m��r�z����
    {
        textObject.color = new Color(textObject.color.r, textObject.color.g, textObject.color.b, _alpha);
    }

    public IEnumerator SetMessage2s(string messange) //��ܰT��1.5��
    {
        SetColorAlpha(1f, messageText);
        messageText.text = messange;

        yield return new WaitForSeconds(0.5F);

        for (float i = 1f; i > 0; i = i - Time.deltaTime) //�b1���H�X
        {
            SetColorAlpha(i, messageText);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }

    public IEnumerator SetLinkageMessage2s(string messange) //��ܰT��2��
    {
        SetColorAlpha(1f, linkageText);
        linkageText.text = messange;

        yield return new WaitForSeconds(secondsDisplayed);

        for (float i = 1f; i > 0; i = i - Time.deltaTime) //�b1���H�X
        {
            SetColorAlpha(i, linkageText);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }

}
