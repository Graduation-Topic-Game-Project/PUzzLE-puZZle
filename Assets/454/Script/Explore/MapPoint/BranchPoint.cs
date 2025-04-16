using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 岔路
/// </summary>
public class BranchPoint : MonoBehaviour
{
    /// <summary>是否有路</summary>
    [Header("是否有路")]
    public bool isHaveRoad;

    public Image RoadImage;

    private void Awake()
    {
        if (ExplorePlayerProgress.Instance == null)
        {
            RandomBranch();
        }

    }

    // Update is called once per frame
    void Update()
    {
        RoadImage.gameObject.SetActive(isHaveRoad);
    }

    /// <summary> 隨機生成岔路 </summary>
    public void RandomBranch() //隨機生成岔路
    {
        isHaveRoad = false;

        int rd = Random.Range(0, 5); //20% 出現岔路

        if (rd == 0)
        {
            isHaveRoad = true;
        }

    }
}
