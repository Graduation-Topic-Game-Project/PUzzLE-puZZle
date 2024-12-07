using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenStartPlane : MonoBehaviour
{
    public GameObject StartPlane;
    bool isOpen;

    private void Awake()
    {
        isOpen = false;
        StartPlane.SetActive(isOpen);
    }

    public void SetStartPlane()
    {
        isOpen = !isOpen;
        StartPlane.SetActive(isOpen);
    }
}
