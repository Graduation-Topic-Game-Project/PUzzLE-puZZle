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
            Destroy(nowAnimation.gameObject);
        }

        if (battlePartner.partner.partnerData.partnerAnimation_Attack == null)
        {
            Debug.Log("�S�������ʵe");
            yield break;
        }

        battlePartner.HidePartnerUI(false); //�Ȯ����äH��UI

        nowAnimation = Instantiate(battlePartner.partner.partnerData.partnerAnimation_Attack,
            battlePartner.PartnerImage.transform.position,
            Quaternion.identity,
            AnimationInstanceObject.transform);

        yield return null;

        Animator animator = nowAnimation.GetComponent<Animator>();
        if (animator != null)
        {
            // ���ݰʵe�����̫�@�Ӫ��A����
            yield return WaitForFinalAnimation(animator);
        }

        yield return null;
        Destroy(nowAnimation.gameObject); //�ʵe������R������
        battlePartner.HidePartnerUI(true); //�}�ҤH��UI
    }

    private IEnumerator WaitForFinalAnimation(Animator animator)
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("End"));
        Debug.Log("�ʵe����");
    }
}
