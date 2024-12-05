using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "New Explore Information", menuName = "ScriptableObject/ExploreInformation", order = 4)]
public class ExploreInformation : ScriptableObject
{
    public ExploreData exploreData;

    public int Layers { get => exploreData.layers; }
    public int LayerWidth { get => exploreData.layerWidth; }
}

[Serializable]
public class ExploreData
{
    [Header("本地圖有幾層(只計算事件Layer)")]
    public int layers;
    [Header("本地圖一層寬度有幾格(只計算事件Layer中的事件格)")]
    public int layerWidth;
    [Header("可能發生的戰鬥")]
    public List<BattleInformation> battleInformation;
}
