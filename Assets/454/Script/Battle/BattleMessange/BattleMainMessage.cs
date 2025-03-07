using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMainMessage : MessageTextController
{
    static BattleMainMessage @this;

    public CanvasGroup canvasGroup;
    public Animator animator;

    private void Awake()
    {
        if (@this == null)
            @this = this;

        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();

        if (animator == null)
            animator = GetComponent<Animator>();

        messageText.text = "";
        canvasGroup.alpha = 0f;
    }


    public static void SetMessage(string messange)
    {
        @this.Open_and_SetMessage(messange);

        @this.animator.SetTrigger("In");
    }


    public void SetObjectAlpha(float alpha)
    {
        canvasGroup.alpha = alpha;
    }

    protected override IEnumerator SetMessageCoroutine(string messange, int second)
    {
        // 設置訊息文字透明度與顯示
        SetColorAlpha(1f, messageText);
        messageText.text = messange;


        SetObjectAlpha(1f);


        yield return new WaitForSeconds(second); //顯示n秒後

        // 淡出過程
        for (float i = 1f; i > 0; i -= Time.deltaTime)
        {
            SetColorAlpha(i, messageText);
            SetObjectAlpha(i);

            yield return new WaitForFixedUpdate();
        }

        // 確保最後透明度為0
        SetColorAlpha(0f, messageText);
        SetObjectAlpha(0f);

        yield return null;
    }
}
