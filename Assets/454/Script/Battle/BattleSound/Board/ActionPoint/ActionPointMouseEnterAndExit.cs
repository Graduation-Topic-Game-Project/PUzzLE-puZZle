using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionPointMouseEnterAndExit : MouseEnterAndExit
{
    public ActionPoint_UI_Controller actionPoint_UI_Controller;

    private void Awake()
    {
        if (actionPoint_UI_Controller == null) //獲取此物件上的ActionPoint_UI_Controller
        {
            actionPoint_UI_Controller = this.gameObject.transform.GetComponent<ActionPoint_UI_Controller>();
        }
    }

    protected override void OnPointerEnter() // 在此處執行滑鼠進入的邏輯
    {
        actionPoint_UI_Controller.StopCoroutine();
        actionPoint_UI_Controller.canvasGroup.alpha = 1f;


        //actionPoint_UI_Controller.ShowActionPoint(); //行動裝置版本需加此行
    }

    protected override void OnPointerExit() // 在此處執行滑鼠離開的邏輯
    {
        //Debug.Log("Pointer exited manually!");
        actionPoint_UI_Controller.ShowActionPoint();
    }


}
