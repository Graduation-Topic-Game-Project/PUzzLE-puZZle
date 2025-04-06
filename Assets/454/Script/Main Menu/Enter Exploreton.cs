using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//<--重要


public class EnterExplore : MonoBehaviour
{
    Animator animator;

    Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>(); //訂閱按紐點擊事件
        _button.onClick.AddListener(Click);

        animator = GetComponent<Animator>();
    }

    public void Click()
    {
        animator.SetBool("Click",true);

        this.Invoke("LoadExplore", 2.5f);//延遲3秒後執行LoadExplore()
        //LoadExplore();
    }

    public void LoadExplore()
    {
        PlayerBattleData.Instance.ResetPlayerHp();
        ExplorePlayerProgress.Instance.ResetPlayerProgress();
        SceneManager.LoadScene("Explore");
    }
}
