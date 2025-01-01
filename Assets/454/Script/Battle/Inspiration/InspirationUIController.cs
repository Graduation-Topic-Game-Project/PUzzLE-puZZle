using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InspirationUIController : MonoBehaviour
{
    public InspirationController inspirationController;

    //int InspirationValue; //�F�P��
    //public int defaultInspirationValue = 3; //�F�P�ȹw�]��

    public TextMeshProUGUI inspirationValue_Number; //�F�P�Ȥ�r

    private void Awake()
    {
        if (inspirationController == null) //��������W��InspirationController
        {
            inspirationController = FindObjectOfType<InspirationController>();
        }
    }
    void Update()
    {
        inspirationValue_Number.text = inspirationController.Inspiration.ToString();
    }

}
