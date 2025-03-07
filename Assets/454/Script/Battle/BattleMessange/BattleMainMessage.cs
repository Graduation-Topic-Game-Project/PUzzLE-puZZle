using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMainMessage : MessageTextController
{
    static BattleMainMessage @this;

    /*[Header("�ݭn�H�X������")]
    public Image BgObject; // �ݭn�@�_�z���ƪ�����*/

    public CanvasGroup canvasGroup;

    private void Awake()
    {
        if (@this == null)
            @this = this;

        messageText.text = "";
        canvasGroup.alpha = 0f;
    }


    public static void SetMessage(string messange)
    {
        @this.Open_and_SetMessage(messange);
    }


    #region
    public void SetObjectAlpha(float alpha)
    {
        canvasGroup.alpha = alpha;
    }

    protected override IEnumerator SetMessageCoroutine(string messange, int second)
    {
        // �]�m�T����r�z���׻P���
        SetColorAlpha(1f, messageText);
        messageText.text = messange;


        SetObjectAlpha(1f);


        yield return new WaitForSeconds(second); //���n���

        // �H�X�L�{
        for (float i = 1f; i > 0; i -= Time.deltaTime)
        {
            SetColorAlpha(i, messageText);
            SetObjectAlpha(i);

            yield return new WaitForFixedUpdate();
        }

        // �T�O�̫�z���׬�0
        SetColorAlpha(0f, messageText);
        SetObjectAlpha(0f);

        yield return null;
    }

    #endregion
}
