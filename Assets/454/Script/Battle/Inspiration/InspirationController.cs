using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InspirationController : MonoBehaviour
{
    static InspirationButtonController @this;

    BattleGameController battleGameController;
    //Animator animator;

    int InspirationValue; //�F�P��
    public int defaultInspirationValue = 3; //�F�P�ȹw�]��

    public TextMeshProUGUI inspirationValue_Number; //�F�P�Ȥ�r

    //public static event Action<bool> Event_; //�}��

    private void Start()
    {
        //animator = GetComponent<Animator>();
        InspirationValue = defaultInspirationValue;
    }
    void Update()
    {
        inspirationValue_Number.text = InspirationValue.ToString();
    }

    void OpenAnimation(bool OpenOrClose)
    {
        //animator.SetBool("IsOpen", OpenOrClose);
        Debug.Log("OpenAnimation");
    }

}
