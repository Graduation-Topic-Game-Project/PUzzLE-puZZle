using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PassiveCountNumber : MonoBehaviour
{
    public int need;
    public int nowHave;

    public TextMeshProUGUI needText;
    public TextMeshProUGUI nowHaveText;


    void Update()
    {
        needText.text = need.ToString();
        nowHaveText.text = nowHave.ToString();
    }
}
