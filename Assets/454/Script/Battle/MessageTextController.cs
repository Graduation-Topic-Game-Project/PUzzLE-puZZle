using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageTextController : MonoBehaviour
{
    TextMeshProUGUI messageText;
    MessageTextController messageTextController;
    Color textColor;

    private void Awake()
    {
        if (messageTextController == null)
            messageTextController = this;

        messageText = this.GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        messageText.text = "123";

        textColor = messageText.color;

        textColor = new Color(textColor.r, textColor.g, textColor.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
