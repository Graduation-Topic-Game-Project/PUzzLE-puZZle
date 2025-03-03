using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAnimationController : MonoBehaviour
{

    [Tooltip("動畫物件生成位置")]
    public GameObject AnimationInstanceObject;
    public BattleAnimation nowAnimation;
    Coroutine coroutine;

    public IEnumerator Start_PlayAttackAnimation(BattlePartner battlePartner)
    {
        yield return StartCoroutine(PlayAttackAnimation(battlePartner));
    }

    public IEnumerator PlayAttackAnimation(BattlePartner battlePartner)
    {
        if(nowAnimation != null)
        {
            Destroy(nowAnimation.gameObject);
        }

        if (battlePartner.partner.partnerData.partnerAnimation_Attack == null)
        {
            Debug.Log("沒有攻擊動畫");
            yield break;
        }

        battlePartner.HidePartnerUI(false); //暫時隱藏人物UI

        nowAnimation = Instantiate(battlePartner.partner.partnerData.partnerAnimation_Attack,
            battlePartner.PartnerImage.transform.position,
            Quaternion.identity,
            AnimationInstanceObject.transform);

        yield return null;

        Animator animator = nowAnimation.GetComponent<Animator>();
        if (animator != null)
        {
            // 等待動畫機的最後一個狀態播完
            yield return WaitForFinalAnimation(animator);
        }

        yield return null;
        Destroy(nowAnimation.gameObject); //動畫結束後刪除物件
        battlePartner.HidePartnerUI(true); //開啟人物UI
    }

    private IEnumerator WaitForFinalAnimation(Animator animator)
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("End"));
        Debug.Log("動畫結束");
    }
}
