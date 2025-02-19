using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//<--重要

public class ExplorePoint : MapPoint
{
    public ExploreType exploreType = ExploreType.Battle_戰鬥;

    public Image ExplarePointImage;

    public Sprite NoneSprite;
    public Sprite BattleSprite;
    public Sprite EvenSprite;
    public Sprite AwardSprite;



    protected override void Click()
    {
        base.Click();
    }

    private void Start()
    {
        switch (exploreType)
        {
            case ExploreType.None_無:

                break;
            case ExploreType.Battle_戰鬥:
                ExplarePointImage.sprite = BattleSprite;
                break;
            case ExploreType.Event_事件:
                ExplarePointImage.sprite = EvenSprite;
                break;
            case ExploreType.Award_獎勵:
                ExplarePointImage.sprite = EvenSprite;
                break;
        }
    }

    public override void MapPointEvent()
    {
        //按鈕執行事件
        switch (exploreType)
        {
            case ExploreType.None_無:
                Debug.Log("無");
                break;
            case ExploreType.Battle_戰鬥:
                BattleEnter();
                Debug.Log("戰鬥");
                break;
            case ExploreType.Event_事件:
                Debug.Log("事件");
                break;
            case ExploreType.Award_獎勵:
                Debug.Log("獎勵");
                break;
        }
    }

    private void BattleEnter()
    {
        SceneManager.LoadScene("Battle");
    }

    public enum ExploreType
    {
        None_無 = 0,
        Battle_戰鬥 = 1,
        Event_事件 = 2,
        Award_獎勵 = 3,
    }
}
