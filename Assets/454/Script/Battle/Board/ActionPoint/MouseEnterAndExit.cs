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
        /*RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null) return false;

        // ��� Canvas ������ Camera
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas == null || canvas.renderMode != RenderMode.ScreenSpaceCamera || canvas.worldCamera == null)
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

        return rectTransform.rect.Contains(localMousePosition);*/

        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null) return false;

        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
        {
            Debug.LogWarning("�䤣�� Canvas�A�нT�{������O�_�b Canvas ��");
            return false;
        }

        Vector2 localMousePosition;

        // **Screen Space - Overlay**
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition);
        }
        // **Screen Space - Camera �� World Space**
        else
        {
            Camera eventCamera = canvas.worldCamera;
            if (eventCamera == null)
            {
                Debug.LogWarning("Screen Space - Camera �� World Space �Ҧ��ݭn���w Camera");
                return false;
            }

            // �ഫ�ù��y�Ш� UI �y��
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform, Input.mousePosition, eventCamera, out localMousePosition))
            {
                return rectTransform.rect.Contains(localMousePosition);
            }
        }

        return false;
    }

    protected virtual void OnPointerEnter() // �b���B����ƹ��i�J���޿�
    {

    }

    protected virtual void OnPointerExit() // �b���B����ƹ����}���޿�
    {

    }
}
