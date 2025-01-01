using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InspirationUIController : MonoBehaviour
{
    public InspirationController inspirationController;

    //int InspirationValue; //靈感值
    //public int defaultInspirationValue = 3; //靈感值預設值

    public TextMeshProUGUI inspirationValue_Number; //靈感值文字

    private void Awake()
    {
        if (inspirationController == null) //獲取場景上的InspirationController
        {
            inspirationController = FindObjectOfType<InspirationController>();
        }
    }
    void Update()
    {
        inspirationValue_Number.text = inspirationController.Inspiration.ToString();
    }

}
