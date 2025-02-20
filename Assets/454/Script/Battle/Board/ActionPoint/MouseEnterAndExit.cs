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

        // 確保物件有 CanvasGroup
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.interactable = false; // 讓 UI 不影響點擊
        canvasGroup.blocksRaycasts = false; // 讓點擊可以穿透到後面的 UI
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
            // 若沒有手指接觸，但 isPointerInside 為 true，表示手指離開了
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

        // 避免數值異常
        if (float.IsNaN(inputPosition.x) || float.IsNaN(inputPosition.y) ||
            float.IsInfinity(inputPosition.x) || float.IsInfinity(inputPosition.y))
        {
            return false;
        }

        // 確保 camera 正確
        Camera eventCamera = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera;
        if (canvas.renderMode != RenderMode.ScreenSpaceOverlay && eventCamera == null)
        {
            Debug.LogWarning("Screen Space - Camera 或 World Space 需要指定 Camera，請在 Canvas 設定 worldCamera");
            return false;
        }

        // 若座標超出畫面範圍，則回傳 false
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