using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//<--���n


public class EnterExplore : MonoBehaviour
{
    Button _button;


    private void Awake()
    {
        _button = GetComponent<Button>(); //�q�\�����I���ƥ�
        _button.onClick.AddListener(LoadExplore);
    }



    public void LoadExplore()
    {
        PlayerBattleData.Instance.ResetPlayerHp();
        ExplorePlayerProgress.Instance.ResetPlayerProgress();
        SceneManager.LoadScene("Explore");
    }
}
