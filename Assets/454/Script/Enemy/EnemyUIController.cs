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

    public GameObject InformationPlane;
    public TextMeshProUGUI InformationEnemyName;
    public TextMeshProUGUI InformationText;
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

        _enemy.Event_IsDead += DeadUIController;

    }

    private void Start()
    {
        EnemyImage.sprite = _enemy.EnemyImage;
    }

    void Update()
    {
        HpText.text = _enemy._enemyHp.ToString();
    }

    public void OpenInformation()
    {
        //Debug.Log("button 123test");
        isOpenInformation = !isOpenInformation; //切換isOpen的true&false
        InformationPlane.SetActive(isOpenInformation);

        InformationText.text = _enemy.Information;
        InformationEnemyName.text = _enemy.enemyName;
    }

    private void DeadUIController()
    {
        Debug.Log("執行死亡動畫");
        EnemyImage.sprite = null;
    }
}
