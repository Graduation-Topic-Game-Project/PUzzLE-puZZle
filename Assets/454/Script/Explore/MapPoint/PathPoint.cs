using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathPoint : MapPoint
{
    public BranchPoint BranchPoint_L, BranchPoint_R;
    protected override void Click()
    {
        base.Click();
    }


}
