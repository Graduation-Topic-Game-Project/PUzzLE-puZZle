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

    //int InspirationValue; //�F�P��
    //public int defaultInspirationValue = 3; //�F�P�ȹw�]��

    public TextMeshProUGUI inspirationValue_Number; //�F�P�Ȥ�r
    public CanvasGroup canvasGroup;

    private void Awake()
    {
        if (battleGameController == null) //��������W��BattleGameController
        {
            battleGameController = FindObjectOfType<BattleGameController>();
        }
        if (inspirationController == null) //��������W��InspirationController
        {
            inspirationController = FindObjectOfType<InspirationController>();
        }
        if (inspirationButtonController == null) //��������W��InspirationButtonController
        {
            inspirationButtonController = FindObjectOfType<InspirationButtonController>();
        }
        if (canvasGroup == null) //��������W��InspirationController
        {
            canvasGroup = this.gameObject.GetComponent<CanvasGroup>();
        }

        battleGameController.Event_SettlementBoard += SetInspirationHide_True;
        battleGameController.Event_StartTurn += SetInspirationHide_False;
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
    /// �����F�P�Ȥ���
    /// </summary>
    /// <param name="isHide"></param>
    public void SetInspirationHide(bool isHide)
    {
        if (isHide)
        {
            // �]�z���� (0 �N�����z��)
            canvasGroup.alpha = 0;

            canvasGroup.interactable = false; // ��������
            canvasGroup.blocksRaycasts = false; // �T���I��
            inspirationButtonController.Particle_System.SetActive(false); //���òɤl�ĪG
        }
        else
        {
            // �]�z���� (1 �N�������z��)
            canvasGroup.alpha = 1;

            canvasGroup.interactable = true;  // �}�Ҥ���
            canvasGroup.blocksRaycasts = true; // ���\�I��
            inspirationButtonController.Particle_System.SetActive(true); //��ܲɤl�ĪG
        }
}

}
