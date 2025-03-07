using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseEnterAndExit : MonoBehaviour
{
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
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            bool isOverUI = IsPointerOverUI(touch.position);

            if (isOverUI && !isPointerInside)
            {
                isPointerInside = true;
                OnPointerEnter();
            }
            else if (!isOverUI && isPointerInside)
            {
                isPointerInside = false;
                OnPointerExit();
            }
        }
        else
        {
            // �Y�S�������Ĳ�A�� isPointerInside �� true�A��ܤ�����}�F
            if (isPointerInside)
            {
                isPointerInside = false;
                OnPointerExit();
            }
        }
    }

    private bool IsPointerOverUI(Vector2 inputPosition)
    {
        if (rectTransform == null || canvas == null)
        {
            return false;
        }

        // �קK�ƭȲ��`
        if (float.IsNaN(inputPosition.x) || float.IsNaN(inputPosition.y) ||
            float.IsInfinity(inputPosition.x) || float.IsInfinity(inputPosition.y))
        {
            return false;
        }

        // �T�O camera ���T
        Camera eventCamera = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera;
        if (canvas.renderMode != RenderMode.ScreenSpaceOverlay && eventCamera == null)
        {
            Debug.LogWarning("Screen Space - Camera �� World Space �ݭn���w Camera�A�Цb Canvas �]�w worldCamera");
            return false;
        }

        // �Y�y�жW�X�e���d��A�h�^�� false
        if (inputPosition.x < 0 || inputPosition.x > Screen.width || inputPosition.y < 0 || inputPosition.y > Screen.height)
        {
            return false;
        }

        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, inputPosition, eventCamera);
    }

    protected virtual void OnPointerEnter()
    {
        Debug.Log("Pointer Entered UI");
    }

    protected virtual void OnPointerExit()
    {
        Debug.Log("Pointer Exited UI");
    }
}