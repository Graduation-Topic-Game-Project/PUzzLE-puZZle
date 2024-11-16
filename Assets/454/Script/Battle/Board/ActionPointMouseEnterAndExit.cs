using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionPointMouseEnterAndExit : MonoBehaviour
{
    private bool isPointerInside = false; // �аO�ƹ��O�_�w�i�J
    public ActionPoint_Controller actionPoint_Controller;

    private void Awake()
    {
        if (actionPoint_Controller == null) //��������W��ActionPoint_Controller
        {
            actionPoint_Controller = this.gameObject.transform.GetComponent<ActionPoint_Controller>();
        }
    }
    void Update()
    {
        // �˴��ƹ��O�_��󪫥�
        if (IsMouseOverUI())
        {
            if (!isPointerInside)
            {
                isPointerInside = true;
                OnPointerEnter();
            }
        }
        else
        {
            if (isPointerInside)
            {
                isPointerInside = false;
                OnPointerExit();
            }
        }
    }

    private bool IsMouseOverUI()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null) return false;

        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform,
            Input.mousePosition,
            null,
            out localMousePosition // �ץ��G�����ܼƱ����p�⵲�G
        );

        return rectTransform.rect.Contains(localMousePosition);
    }

    private void OnPointerEnter() // �b���B����ƹ��i�J���޿�
    {
        Debug.Log("Pointer entered manually!");
        actionPoint_Controller.StopCoroutine();
        //actionPoint_Controller.StopAllCoroutines();
        actionPoint_Controller.canvasGroup.alpha = 1f;
    }

    private void OnPointerExit() // �b���B����ƹ����}���޿�
    {
        Debug.Log("Pointer exited manually!");
        actionPoint_Controller.ShowActionPoint(); 
    }


}
