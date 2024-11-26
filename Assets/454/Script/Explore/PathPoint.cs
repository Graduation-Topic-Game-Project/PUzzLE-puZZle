using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathPoint : MonoBehaviour
{

    private Button button;
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
}
