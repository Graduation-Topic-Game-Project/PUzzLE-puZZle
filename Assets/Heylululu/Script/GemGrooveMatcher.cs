using UnityEngine;

public class GemGrooveMatcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 檢查是否為寶石
        if (other.CompareTag("GemRed") || other.CompareTag("GemYellow") ||
            other.CompareTag("GemBlue") || other.CompareTag("GemPink") ||
            other.CompareTag("GemGray"))
        {
            // 獲取卡榫的顏色
            string grooveColor = gameObject.tag; // 假設卡榫的標籤是如 "GrooveRed"

            // 檢查顏色是否匹配
            if (other.CompareTag("Gem" + grooveColor.Replace("Groove", ""))) // 例如：如果 grooveColor 是 "GrooveRed"，則匹配 "GemRed"
            {
                Debug.Log("拼成功");
            }
            else
            {
                Debug.Log("拼失敗");
            }
        }
    }
}
