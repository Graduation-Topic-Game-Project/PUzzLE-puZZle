using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bal_And_Sword_Button : MonoBehaviour
{
    public GameObject sword;
    public GameObject balance;
    bool isOpen = false;

    public void open()
    {
        isOpen = !isOpen;
        sword.SetActive(isOpen);
        balance.SetActive(isOpen);
    }
}
