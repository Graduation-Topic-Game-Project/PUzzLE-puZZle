using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �ø�
/// </summary>
public class BranchPoint : MonoBehaviour
{
    /// <summary>�O�_����</summary>
    [Header("�O�_����")]
    public bool isHaveRoad;

    public Image RoadImage;

    private void Awake()
    {
        isHaveRoad = false;

        int rd = Random.Range(0, 5);

        if (rd == 0)
        {
            isHaveRoad = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        RoadImage.gameObject.SetActive(isHaveRoad);
    }
}
