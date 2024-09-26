using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionPoint_Controller : MonoBehaviour
{
    public TextMeshProUGUI actionPoint_Number;
    public int actionPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actionPoint_Number.text = actionPoint.ToString();
    }
}
