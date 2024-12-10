using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//<--���n

public class ExplorePoint : MapPoint
{
    public ExploreType exploreType = ExploreType.Battle_�԰�;

    public Image ExplarePointImage;

    public Sprite NoneSprite;
    public Sprite BattleSprite;
    public Sprite EvenSpritet;



    protected override void Click()
    {
        base.Click();
    }

    private void Start()
    {
        switch (exploreType)
        {
            case ExploreType.None_�L:

                break;
            case ExploreType.Battle_�԰�:
                ExplarePointImage.sprite = BattleSprite;
                break;
            case ExploreType.Event_�ƥ�:
                ExplarePointImage.sprite = EvenSpritet;
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
    }
}
