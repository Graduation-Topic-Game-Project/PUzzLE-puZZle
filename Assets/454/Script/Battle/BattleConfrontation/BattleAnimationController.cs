using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAnimationController : MonoBehaviour
{

    [Tooltip("�ʵe����ͦ���m")]
    public GameObject AnimationInstanceObject;

    public void PlayAttackAnimation(BattlePartner battlePartner)
    {

        Instantiate(battlePartner.partner.partnerData.partnerAnimation_Attack.gameObject,
            battlePartner.transform.position,
            Quaternion.identity, 
            AnimationInstanceObject.transform);
    }
}
