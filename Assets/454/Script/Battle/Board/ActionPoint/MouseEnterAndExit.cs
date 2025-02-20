using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseEnterAndExit : MonoBehaviour
{
    /*private bool isPointerInside = false; // �аO�ƹ��O�_�w�i�J
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
    }*/

    private bool isPointerInside = false;
    private RectTransform rectTransform;
    private Canvas canvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        // �T�O���� CanvasGroup
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.interactable = false; // �� UI ���v�T�I��
        canvasGroup.blocksRaycasts = false; // ���I���i�H��z��᭱�� UI
    }

    void Update()
    {
        if (IsPointerOverUI())
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

    /*private bool IsPointerOverUI()
    {
        if (rectTransform == null || canvas == null)
        {
            return false;
        }

        Vector2 inputPosition;
        if (Input.touchCount > 0)
        {
            inputPosition = Input.GetTouch(0).position;
        }
        else
        {
            inputPosition = Input.mousePosition;
        }

        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, inputPosition);
        }
        else
        {
            Camera eventCamera = canvas.worldCamera;
            if (eventCamera == null)
            {
                Debug.LogWarning("Screen Space - Camera �� World Space �ݭn���w Camera");
                return false;
            }

            return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, inputPosition, eventCamera);
        }
    }*/
    private bool IsPointerOverUI()
    {
        if (rectTransform == null || canvas == null)
        {
            return false;
        }

        // �����J��m�]�ƹ���Ĳ���^
        Vector2 inputPosition;
        if (Input.touchCount > 0)
        {
            inputPosition = Input.GetTouch(0).position;
        }
        else
        {
            inputPosition = Input.mousePosition;
        }

        // �i��k 1�j�קK mousePosition �X��
        if (float.IsNaN(inputPosition.x) || float.IsNaN(inputPosition.y) ||
            float.IsInfinity(inputPosition.x) || float.IsInfinity(inputPosition.y))
        {
            return false;
        }

        // �i��k 2�j�T�O camera ���T�]Screen Space - Camera �� World Space�^
        Camera eventCamera = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera;
        if (canvas.renderMode != RenderMode.ScreenSpaceOverlay && eventCamera == null)
        {
            Debug.LogWarning("Screen Space - Camera �� World Space �ݭn���w Camera�A�Цb Canvas �]�w worldCamera");
            return false;
        }

        // �i��k 3�j�p�G�y�жW�X�e���A�����^�� false
        if (inputPosition.x < 0 || inputPosition.x > Screen.width || inputPosition.y < 0 || inputPosition.y > Screen.height)
        {
            return false;
        }

        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, inputPosition, eventCamera);
    }


    protected virtual void OnPointerEnter() // �b���B����ƹ��i�J���޿�
    {

    }

    protected virtual void OnPointerExit() // �b���B����ƹ����}���޿�
    {

    }
}
