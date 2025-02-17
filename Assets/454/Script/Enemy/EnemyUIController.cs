using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUIController : MonoBehaviour
{
    Enemy _enemy;

    public Image EnemyImage;
    public TextMeshProUGUI HpText;
    public EnemyBattleUI enemyBattleUI;

    public GameObject InformationPlane;
    public TextMeshProUGUI InformationEnemyName;
    public TextMeshProUGUI InformationText;
    public TextMeshProUGUI CombatPowerNumber; //�Ĭ�ԤO�Ȥ�r
    public Image InformationImage;

    bool isOpenInformation = false;

    public Button _button;

    private void Awake()
    {
        _enemy = this.gameObject.GetComponent<Enemy>();

        _button = this.gameObject.GetComponent<Button>();
        _button.onClick.AddListener(OpenInformation);

        isOpenInformation = false;
        InformationPlane.SetActive(false);

        _enemy.Event_IsDead += DeadUIController; //���`�ɡA���榺�`�ʵe
        _enemy.Event_ConfrontaionStart += ShowCombatPower; //�Ĭ�ʵe�}�l�ɡA��ܾԤO��
        _enemy.Event_ConfrontaionEnd += ClearCombatPower; //�Ĭ�ʵe�����ɡA���þԤO��UI
    }

    private void Start()
    {
        EnemyImage.sprite = _enemy.EnemyImage;
    }

    void Update()
    {
        _enemy.enemyBattleUI.HpText.text = _enemy._enemyHp.ToString();
        _enemy.enemyBattleUI.HpBar.fillAmount = _enemy._enemyHp / _enemy._enemyMaxHp;
    }

    public void OpenInformation()
    {
        //Debug.Log("button 123test");
        isOpenInformation = !isOpenInformation; //����isOpen��true&false
        InformationPlane.SetActive(isOpenInformation);

        InformationText.text = _enemy.Information;
        InformationEnemyName.text = _enemy.enemyName;
    }

    /// <summary> ��ܾԤO�� </summary>
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

    /// <summary> ���榺�`�ʵe </summary>
    public void DeadUIController()
    {
        Debug.Log("���榺�`�ʵe");
        EnemyImage.sprite = _enemy.DeadImage;
    }

    private void OnDestroy() //�R���ɨ����q�\
    {
        _enemy.Event_IsDead -= DeadUIController;
    }
}
