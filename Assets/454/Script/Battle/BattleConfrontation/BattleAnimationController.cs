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
            Destroy(nowAnimation);
        }

        if (battlePartner.partner.partnerData.partnerAnimation_Attack == null)
        {
            Debug.Log("沒有攻擊動畫");
            yield break;
        }

        nowAnimation = Instantiate(battlePartner.partner.partnerData.partnerAnimation_Attack,
            battlePartner.PartnerImage.transform.position,
            Quaternion.identity,
            AnimationInstanceObject.transform);

        yield return null;
    }
}
