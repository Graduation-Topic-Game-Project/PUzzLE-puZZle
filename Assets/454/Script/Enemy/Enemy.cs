using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

//[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObject/Enemy", order = 2)]
public class Enemy : MonoBehaviour
{
    private BattleGameController battleGameController;

    public string enemyName;
    public Sprite EnemyImage;
    public TextMeshProUGUI HpText;

    public GameObject InformationPlane;
    bool isOpenInformation = false;

    public int _enemyAtk;
    public int _enemyHp;

    public Button _button;

    protected void Awake()
    {
        if (battleGameController == null) //獲取場景上的BattleGameController        
            battleGameController = FindObjectOfType<BattleGameController>();

        _button = this.gameObject.GetComponent<Button>();
        _button.onClick.AddListener(OpenInformation);

        //battleGameController.Event_EndTurn += this.
    }
    private void Start()
    {
        this.GetComponent<Image>().sprite = EnemyImage;
        EndTurnController.Event_Damage += this.Damage;

    }
    private void Update()
    {
        HpText.text = _enemyHp.ToString();
    }

    protected virtual void Damage(int R, int B, int Y, int P) //受傷
    {
        _enemyHp -= R + B + Y + P;
    }

    public void OpenInformation()
    {
        Debug.Log("button 123test");
        isOpenInformation = !isOpenInformation; //切換isOpen的true&false
        InformationPlane.SetActive(isOpenInformation);
    }

}


