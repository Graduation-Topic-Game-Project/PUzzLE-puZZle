using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//<--���n

public class ExplorePoint : MonoBehaviour
{
    private Button button;

    public ExploreType exploreType = ExploreType.Battle_�԰�;

    public (int, int) PointTrasform;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }

    private void Click()
    {
        ExplorePlayerMove.StartCoroutine_PlayerMove(this.gameObject.transform);

        //ExplareEventJudge();
    }


    /// <summary>
    /// �̷ӱ����I��������ƥ�
    /// </summary>
    private void ExplareEventJudge()
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
