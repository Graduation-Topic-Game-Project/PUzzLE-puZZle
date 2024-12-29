using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMainMessage : MessageTextController
{
    static BattleMainMessage @this;

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
