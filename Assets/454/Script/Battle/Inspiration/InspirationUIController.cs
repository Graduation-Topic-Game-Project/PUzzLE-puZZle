using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InspirationUIController : MonoBehaviour
{
    public BattleGameController battleGameController;
    public InspirationController inspirationController;
    public InspirationButtonController inspirationButtonController;

    //int InspirationValue; //靈感值
    //public int defaultInspirationValue = 3; //靈感值預設值

    public TextMeshProUGUI inspirationValue_Number; //靈感值文字
    public CanvasGroup canvasGroup;

    private void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (inspirationController == null) //獲取場景上的InspirationController
        {
            inspirationController = FindObjectOfType<InspirationController>();
        }
        if (inspirationButtonController == null) //獲取場景上的InspirationButtonController
        {
            inspirationButtonController = FindObjectOfType<InspirationButtonController>();
        }
        if (canvasGroup == null) //獲取場景上的InspirationController
        {
            canvasGroup = this.gameObject.GetComponent<CanvasGroup>();
        }

        battleGameController.Event_SettlementBoard += SetInspirationHide_True;
        battleGameController.Event_StartTurn += SetInspirationHide_False;

        battleGameController.Event_HideInspiration += SetInspirationHide;
    }
    void Update()
    {
        inspirationValue_Number.text = inspirationController.Inspiration.ToString();
    }

    public void SetInspirationHide_True(object sender, EventArgs e)
    {
        SetInspirationHide(true);
    }
    public void SetInspirationHide_False(object sender, EventArgs e)
    {
        SetInspirationHide(false);
    }

    /// <summary>
    /// 隱藏靈感值介面
    /// </summary>
    /// <param name="isHide"></param>
    public void SetInspirationHide(bool isHide)
    {
        if (isHide == true)
        {
            // 設透明度 (0 代表完全透明)
            canvasGroup.alpha = 0;

            inspirationButtonController.Particle_System.GetComponent<ParticleSystem>().Stop(); //隱藏粒子效果
            canvasGroup.interactable = false; // 關閉互動
            canvasGroup.blocksRaycasts = false; // 禁止點擊

        }
        else
        {
            // 設透明度 (1 代表完全不透明)
            canvasGroup.alpha = 1;

            inspirationButtonController.Particle_System.GetComponent<ParticleSystem>().Play(); ; //顯示粒子效果
            canvasGroup.interactable = true;  // 開啟互動
            canvasGroup.blocksRaycasts = true; // 允許點擊

        }
}

}
