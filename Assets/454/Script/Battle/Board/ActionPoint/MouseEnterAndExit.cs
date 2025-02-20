using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseEnterAndExit : MonoBehaviour
{
    /*private bool isPointerInside = false; // 標記滑鼠是否已進入
    void Update()
    {
        // 檢測滑鼠是否位於物件內
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
            Debug.LogWarning("找不到 Canvas，請確認此物件是否在 Canvas 內");
            return false;
        }

        Vector2 localMousePosition;

        // **Screen Space - Overlay**
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition);
        }
        // **Screen Space - Camera 或 World Space**
        else
        {
            Camera eventCamera = canvas.worldCamera;
            if (eventCamera == null)
            {
                Debug.LogWarning("Screen Space - Camera 或 World Space 模式需要指定 Camera");
                return false;
            }

            // 轉換螢幕座標到 UI 座標
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
                Debug.LogWarning("Screen Space - Camera 或 World Space 需要指定 Camera");
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

        // 獲取輸入位置（滑鼠或觸控）
        Vector2 inputPosition;
        if (Input.touchCount > 0)
        {
            inputPosition = Input.GetTouch(0).position;
        }
        else
        {
            inputPosition = Input.mousePosition;
        }

        // 【方法 1】避免 mousePosition 出錯
        if (float.IsNaN(inputPosition.x) || float.IsNaN(inputPosition.y) ||
            float.IsInfinity(inputPosition.x) || float.IsInfinity(inputPosition.y))
        {
            return false;
        }

        // 【方法 2】確保 camera 正確（Screen Space - Camera 或 World Space）
        Camera eventCamera = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera;
        if (canvas.renderMode != RenderMode.ScreenSpaceOverlay && eventCamera == null)
        {
            Debug.LogWarning("Screen Space - Camera 或 World Space 需要指定 Camera，請在 Canvas 設定 worldCamera");
            return false;
        }

        // 【方法 3】如果座標超出畫面，直接回傳 false
        if (inputPosition.x < 0 || inputPosition.x > Screen.width || inputPosition.y < 0 || inputPosition.y > Screen.height)
        {
            return false;
        }

        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, inputPosition, eventCamera);
    }


    protected virtual void OnPointerEnter() // 在此處執行滑鼠進入的邏輯
    {

    }

    protected virtual void OnPointerExit() // 在此處執行滑鼠離開的邏輯
    {

    }
}
