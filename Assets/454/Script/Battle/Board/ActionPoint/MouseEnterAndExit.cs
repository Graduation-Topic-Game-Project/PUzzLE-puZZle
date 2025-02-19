using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEnterAndExit : MonoBehaviour
{
    private bool isPointerInside = false; // 標記滑鼠是否已進入
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

        // 獲取 Canvas 的相關 Camera
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas == null || /*canvas.renderMode != RenderMode.ScreenSpaceCamera ||*/ canvas.worldCamera == null)
        {
            Debug.LogWarning("Canvas 或攝影機未設置正確");
            return false;
        }

        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform,
            Input.mousePosition,
            canvas.worldCamera, // 攝影機參數需要指定正確的 Camera
            out localMousePosition // 修正：提供變數接收計算結果
        );

        return rectTransform.rect.Contains(localMousePosition);
    }

    protected virtual void OnPointerEnter() // 在此處執行滑鼠進入的邏輯
    {

    }

    protected virtual void OnPointerExit() // 在此處執行滑鼠離開的邏輯
    {

    }
}
