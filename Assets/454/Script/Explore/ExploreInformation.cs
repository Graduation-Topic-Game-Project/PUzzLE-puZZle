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
    [Header("���a�Ϧ��X�h(�u�p��ƥ�Layer)")]
    public int layers;
    [Header("���a�Ϥ@�h�e�צ��X��(�u�p��ƥ�Layer�����ƥ��)")]
    public int layerWidth;
    [Header("�i��o�ͪ��԰�")]
    public List<BattleInformation> battleInformation;
}
