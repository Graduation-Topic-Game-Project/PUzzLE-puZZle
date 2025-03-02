using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BranchPoint : MonoBehaviour
{
    [Header("¬O§_¦³¸ô")]
    public bool isRoad;

    public Image RoadImage;

    private void Awake()
    {
        isRoad = false;

        int rd = Random.Range(0, 5);

        if (rd == 0)
        {
            isRoad = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        RoadImage.gameObject.SetActive(isRoad);
    }
}
