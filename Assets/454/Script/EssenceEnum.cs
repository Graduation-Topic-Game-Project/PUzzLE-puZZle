using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 用以儲存本質與相關資料的靜態類別
/// </summary>
public static class EssenceEnum
{
    /// <summary> 力量本質_標準色 </summary>
    public static readonly Color32 Strengthe_Color = new Color32(255, 0, 0, 255); // 
    /// <summary> 智慧本質_標準色 </summary>
    public static readonly Color32 Wisdom_Color = new Color32(0, 115, 255, 255); // 
    /// <summary> 信仰本質_標準色 </summary>
    public static readonly Color32 Belief_tColor = new Color32(255, 215, 0, 255); // 金黃色
    /// <summary> 靈魂本質_標準色 </summary>
    public static readonly Color32 Soul_Color = new Color32(195, 0, 255, 255); // 

    public enum Essence
    {
        None_無屬性 = 0,
        Strengthe_力量 = 1, //力量
        Wisdom_智慧 = 2,  //智慧
        Belief_信仰 = 3, //信仰
        Soul_靈魂 = 4, //靈魂
    }
}
