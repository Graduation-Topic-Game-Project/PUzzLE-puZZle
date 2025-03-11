using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//<--重要
using System;

public class ExplorePoint : MapPoint
{
    public ExploreType exploreType = ExploreType.Battle_戰鬥;

    public Image ExplarePointImage;

    public Sprite NoneSprite;
    public Sprite BattleSprite;
    public Sprite EvenSprite;
    public Sprite AwardSprite;
    public Sprite RestSprite;

    protected override void Awake()
    {
        base.Awake();
        RandomMapPointEvent();
    }

    protected override void Click()
    {
        base.Click();
    }

    void Start()
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
                ExplarePointImage.sprite = AwardSprite;
                break;
            case ExploreType.Rest_休憩:
                ExplarePointImage.sprite = RestSprite;
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
            case ExploreType.Rest_休憩:
                Debug.Log("休憩");
                break;
        }
    }

    public void RandomMapPointEvent()
    {
        int rd = UnityEngine.Random.Range(1, Enum.GetValues(typeof(ExploreType)).Length + 1);

        switch (rd)
        {
            case 1:
                exploreType = ExploreType.Battle_戰鬥;
                break;
            case 2:
                exploreType = ExploreType.Event_事件;
                break;
            case 3:
                exploreType = ExploreType.Award_獎勵;
                break;
            case 4:
                exploreType = ExploreType.Rest_休憩;
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
        Rest_休憩 = 4,
    }
}
