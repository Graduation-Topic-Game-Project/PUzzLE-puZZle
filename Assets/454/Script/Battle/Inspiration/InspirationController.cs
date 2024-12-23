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

    int InspirationValue; //靈感值
    public int defaultInspirationValue = 3; //靈感值預設值

    public TextMeshProUGUI inspirationValue_Number; //靈感值文字

    //public static event Action<bool> Event_; //開關

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
