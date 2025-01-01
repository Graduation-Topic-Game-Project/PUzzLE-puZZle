using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionPointMouseEnterAndExit : MouseEnterAndExit
{
    public ActionPoint_UI_Controller actionPoint_UI_Controller;

    private void Awake()
    {
        if (actionPoint_UI_Controller == null) //���������W��ActionPoint_UI_Controller
        {
            actionPoint_UI_Controller = this.gameObject.transform.GetComponent<ActionPoint_UI_Controller>();
        }
    }

    protected override void OnPointerEnter() // �b���B����ƹ��i�J���޿�
    {
        //Debug.Log("Pointer entered manually!");
        actionPoint_UI_Controller.StopCoroutine();
        //actionPoint_Controller.StopAllCoroutines();
        actionPoint_UI_Controller.canvasGroup.alpha = 1f;
    }

    protected override void OnPointerExit() // �b���B����ƹ����}���޿�
    {
        //Debug.Log("Pointer exited manually!");
        actionPoint_UI_Controller.ShowActionPoint();
    }


}
