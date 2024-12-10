using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//<--���n

public class ExplorePoint : MapPoint
{
    public ExploreType exploreType = ExploreType.Battle_�԰�;

    public Image image;
    public Sprite Battle;
    public Sprite Event;



    protected override void Click()
    {
        base.Click();
    }

    private void Awake()
    {
        
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
