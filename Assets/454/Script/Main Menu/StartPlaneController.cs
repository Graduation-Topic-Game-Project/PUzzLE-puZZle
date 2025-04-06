using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPlaneController : MonoBehaviour
{
    public GameObject StartPlane;
    public GameObject particleObject; //粒子效果
    bool isOpen;

    private void Awake()
    {
        isOpen = false;
        StartPlane.SetActive(isOpen);
    }

    //按鈕用
    public void SetStartPlane()
    {
        isOpen = !isOpen;
        StartPlane.SetActive(isOpen);
        particleObject.SetActive(!isOpen);
    }
}
