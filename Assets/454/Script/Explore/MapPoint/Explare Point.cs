using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//<--���n
using System;

public class ExplorePoint : MapPoint
{
    public ExploreType exploreType = ExploreType.Battle_�԰�;

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
            case ExploreType.None_�L:

                break;
            case ExploreType.Battle_�԰�:
                ExplarePointImage.sprite = BattleSprite;
                break;
            case ExploreType.Event_�ƥ�:
                ExplarePointImage.sprite = EvenSprite;
                break;
            case ExploreType.Award_���y:
                ExplarePointImage.sprite = AwardSprite;
                break;
            case ExploreType.Rest_���:
                ExplarePointImage.sprite = RestSprite;
                break;
        }
    }

    public override void MapPointEvent()
    {
        //���s����ƥ�
        switch (exploreType)
        {
            case ExploreType.None_�L:
                Debug.Log("�L");
                break;
            case ExploreType.Battle_�԰�:
                BattleEnter();
                Debug.Log("�԰�");
                break;
            case ExploreType.Event_�ƥ�:
                Debug.Log("�ƥ�");
                break;
            case ExploreType.Award_���y:
                Debug.Log("���y");
                break;
            case ExploreType.Rest_���:
                Debug.Log("���");
                break;
        }
    }

    public void RandomMapPointEvent()
    {
        int rd = UnityEngine.Random.Range(1, Enum.GetValues(typeof(ExploreType)).Length + 1);

        switch (rd)
        {
            case 1:
                exploreType = ExploreType.Battle_�԰�;
                break;
            case 2:
                exploreType = ExploreType.Event_�ƥ�;
                break;
            case 3:
                exploreType = ExploreType.Award_���y;
                break;
            case 4:
                exploreType = ExploreType.Rest_���;
                break;
        }
    }

    private void BattleEnter()
    {
        SceneManager.LoadScene("Battle");
    }

    public enum ExploreType
    {
        None_�L = 0,
        Battle_�԰� = 1,
        Event_�ƥ� = 2,
        Award_���y = 3,
        Rest_��� = 4,
    }
}
