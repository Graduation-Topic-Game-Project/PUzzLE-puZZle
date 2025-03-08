using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// �԰��������٦�p�H��UI
/// </summary>
public class BattlePartner : MonoBehaviour
{
    /// <summary> �٦��� </summary>
    public Partner partner;
    /// <summary> �٦��m�s�� </summary>
    public int PartnerNumber;
    /// <summary> �٦�Ϥ� </summary>
    public Image PartnerImage;
    /// <summary> ���v�Ϥ� </summary>
    public Image ShadowImage;
    /// <summary> �Ĭ�ԤO�Ȥ�r </summary>
    public TextMeshProUGUI CombatPowerNumber; //�Ĭ�ԤO�Ȥ�r
    /// <summary> �ʵe�ͦ��y�Ц�m </summary>
    public GameObject animationInstanceTransform;
    /// <summary> �ޯ୶�� </summary>
    public PartnerSkillPanelController partnerSkillPanelController;

    public Button button;

    private void Awake()
    {
        if (partnerSkillPanelController == null) //��������W��PartnerSkillPanelController
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

    /// <summary> ��ܾԤO�� </summary>
    /// <param name="_combatPower">�ԤO��</param>
    public void ShowCombatPower(int _combatPower)
    {
        Color color = CombatPowerNumber.color; //���}�z����
        color.a = 1f;
        CombatPowerNumber.color = color;

        CombatPowerNumber.text = _combatPower.ToString();
    }

    /// <summary> ���þԤO��UI </summary>
    public void ClearCombatPower()
    {
        Color color = CombatPowerNumber.color; //�����z����
        color.a = 0f;
        CombatPowerNumber.color = color;
    }

    /// <summary> �}���٦�Ϥ�UI </summary>
    public void HidePartnerUI(bool openOrClose)
    {
        PartnerImage.gameObject.SetActive(openOrClose);
        //ShadowImage.gameObject.SetActive(openOrClose);
    }

    private void Click() //���s����ƥ�
    {
        partnerSkillPanelController.OpenSkillPlane(true);
    }
}
