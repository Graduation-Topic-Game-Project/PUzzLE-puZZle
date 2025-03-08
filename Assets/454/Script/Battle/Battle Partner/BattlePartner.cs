using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 戰鬥場景的夥伴小人的UI
/// </summary>
public class BattlePartner : MonoBehaviour
{
    /// <summary> 夥伴資料 </summary>
    public Partner partner;
    /// <summary> 夥伴位置編號 </summary>
    public int PartnerNumber;
    /// <summary> 夥伴圖片 </summary>
    public Image PartnerImage;
    /// <summary> 陰影圖片 </summary>
    public Image ShadowImage;
    /// <summary> 衝突戰力值文字 </summary>
    public TextMeshProUGUI CombatPowerNumber; //衝突戰力值文字
    /// <summary> 動畫生成座標位置 </summary>
    public GameObject animationInstanceTransform;
    /// <summary> 技能頁面 </summary>
    public PartnerSkillPanelController partnerSkillPanelController;

    public Button button;

    private void Awake()
    {
        if (partnerSkillPanelController == null) //獲取場景上的PartnerSkillPanelController
        {
            partnerSkillPanelController = FindObjectOfType<PartnerSkillPanelController>();
        }

        if (button == null)
        {
            button = GetComponent<Button>();
        }
        button.onClick.AddListener(Click);
    }
    private void Start()
    {
        ClearCombatPower();
    }

    /// <summary> 顯示戰力值 </summary>
    /// <param name="_combatPower">戰力值</param>
    public void ShowCombatPower(int _combatPower)
    {
        Color color = CombatPowerNumber.color; //打開透明度
        color.a = 1f;
        CombatPowerNumber.color = color;

        CombatPowerNumber.text = _combatPower.ToString();
    }

    /// <summary> 隱藏戰力值UI </summary>
    public void ClearCombatPower()
    {
        Color color = CombatPowerNumber.color; //關閉透明度
        color.a = 0f;
        CombatPowerNumber.color = color;
    }

    /// <summary> 開關夥伴圖片UI </summary>
    public void HidePartnerUI(bool openOrClose)
    {
        PartnerImage.gameObject.SetActive(openOrClose);
        //ShadowImage.gameObject.SetActive(openOrClose);
    }

    private void Click() //按鈕執行事件
    {
        partnerSkillPanelController.OpenSkillPlane(true);
    }
}
