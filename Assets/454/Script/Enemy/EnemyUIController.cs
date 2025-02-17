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
    public TextMeshProUGUI CombatPowerNumber; //衝突戰力值文字
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

        _enemy.Event_IsDead += DeadUIController; //死亡時，執行死亡動畫
        _enemy.Event_ConfrontaionStart += ShowCombatPower; //衝突動畫開始時，顯示戰力值
        _enemy.Event_ConfrontaionEnd += ClearCombatPower; //衝突動畫結束時，隱藏戰力值UI
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
        isOpenInformation = !isOpenInformation; //切換isOpen的true&false
        InformationPlane.SetActive(isOpenInformation);

        InformationText.text = _enemy.Information;
        InformationEnemyName.text = _enemy.enemyName;
    }

    /// <summary> 顯示戰力值 </summary>
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

    /// <summary> 執行死亡動畫 </summary>
    public void DeadUIController()
    {
        Debug.Log("執行死亡動畫");
        EnemyImage.sprite = _enemy.DeadImage;
    }

    private void OnDestroy() //摧毀時取消訂閱
    {
        _enemy.Event_IsDead -= DeadUIController;
    }
}
