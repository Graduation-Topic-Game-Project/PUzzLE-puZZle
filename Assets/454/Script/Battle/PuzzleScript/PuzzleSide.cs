using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PuzzleSide : MonoBehaviour
{
    public PuzzleSideData sideData = new();

    public PuzzleSide(PuzzleSideData.Interlocking interlocking, PuzzleSideData.SideEssence sideEssence)
    {
        sideData._essence = sideEssence;
        sideData._interlocking = interlocking;
    }

    public PuzzleSideData.SideEssence Essence
    {
        get
        {
            return sideData._essence;
        }
    }
}

[Serializable]
public class PuzzleSideData
{
    [Header("拼圖邊的本質屬性"), Tooltip("拼圖邊的本質屬性")]
    public SideEssence _essence = SideEssence.Strengthe_力量;
    [Header("拼圖邊的凹凸"), Tooltip("拼圖邊的凹凸")]
    public Interlocking _interlocking = Interlocking.indentations_凹陷;

    public enum SideEssence
    {
        None_無屬性 = 0,
        Strengthe_力量 = 1, //力量
        Wisdom_智慧 = 2,  //智慧
        Belief_信仰 = 3, //信仰
        Soul_靈魂 = 4, //靈魂
    }

    public enum Interlocking //拼圖凹凸
    {
        None_無凹凸 = 0, //平
        indentations_凹陷 = 1, //凹
        protrusions_突起 = 2,  //凸

    }
}
