using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPoint : MonoBehaviour
{
    private Button button;

    public (int, int) PointTrasform;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }

    protected virtual void Click()
    {
        if (ExploreMapController.isCanClickExploreMapUI == false)
        {
            Debug.Log("UI����������");
            return;
        }
        if (ExplorePlayerMove.IsCanMove(this) == false)
        {
            return;
        }
        ExplorePlayerMove.StartCoroutine_PlayerMove(this);

        ExplorePlayerProgress.Instance.SetPlayerTransform(PointTrasform);
        ExplorePlayerProgress.Instance.SetPlayerGameObjectPosition(this.gameObject.transform.position);


    }


    /// <summary>
    /// ���汴���I�ƥ�
    /// </summary>
    public virtual void MapPointEvent()
    {

    }
}
