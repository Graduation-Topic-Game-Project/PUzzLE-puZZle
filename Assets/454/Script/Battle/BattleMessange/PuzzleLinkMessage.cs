using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleLinkMessage : MessageTextController
{
    static PuzzleLinkMessage @this;

    private void Awake()
    {
        if (@this == null)
            @this = this;

        messageText.text = "";
    }

    public static void SetMessage(string messange)
    {
        @this.Open_and_SetMessage(messange);
    }
}
