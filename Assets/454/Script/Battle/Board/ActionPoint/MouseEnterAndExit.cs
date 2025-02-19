using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEnterAndExit : MonoBehaviour
{
    private bool isPointerInside = false; // �аO�ƹ��O�_�w�i�J
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

        // ��� Canvas ������ Camera
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas == null || /*canvas.renderMode != RenderMode.ScreenSpaceCamera ||*/ canvas.worldCamera == null)
        {
            Debug.LogWarning("Canvas ����v�����]�m���T");
            return false;
        }

        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform,
            Input.mousePosition,
            canvas.worldCamera, // ��v���Ѽƻݭn���w���T�� Camera
            out localMousePosition // �ץ��G�����ܼƱ����p�⵲�G
        );

        return rectTransform.rect.Contains(localMousePosition);
    }

    protected virtual void OnPointerEnter() // �b���B����ƹ��i�J���޿�
    {

    }

    protected virtual void OnPointerExit() // �b���B����ƹ����}���޿�
    {

    }
}
