using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//<--重要


public class EnterExplore : MonoBehaviour
{
    Button _button;


    private void Awake()
    {
        _button = GetComponent<Button>(); //訂閱按紐點擊事件
        _button.onClick.AddListener(LoadExplore);
    }



    public void LoadExplore()
    {
        //PlayerBattleData.ResetPlayer();
        SceneManager.LoadScene("Explore");
    }
}
