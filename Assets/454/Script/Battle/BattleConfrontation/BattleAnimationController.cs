using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAnimationController : MonoBehaviour
{

    [Tooltip("�ʵe����ͦ���m")]
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
            Debug.Log("�S�������ʵe");
            yield break;
        }

        nowAnimation = Instantiate(battlePartner.partner.partnerData.partnerAnimation_Attack,
            battlePartner.PartnerImage.transform.position,
            Quaternion.identity,
            AnimationInstanceObject.transform);

        yield return null;
    }
}
