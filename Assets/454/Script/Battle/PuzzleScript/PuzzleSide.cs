using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PuzzleSide : MonoBehaviour
{
    public PuzzleSideData sideData = new();

    public PuzzleSide(PuzzleSideData.Interlocking interlocking, EssenceEnum.Essence sideEssence)
    {
        sideData.Essence_ = sideEssence;
        sideData.Interlocking_ = interlocking;
    }
}

[Serializable]
public class PuzzleSideData
{
    [SerializeField]
    [Header("拼圖邊的本質屬性"), Tooltip("拼圖邊的本質屬性")]
    private EssenceEnum.Essence _sideEssence = EssenceEnum.Essence.Strengthe_力量;
    [SerializeField]
    [Header("拼圖邊的凹凸"), Tooltip("拼圖邊的凹凸")]
    private Interlocking _interlocking = Interlocking.indentations_凹陷;

    public PuzzleSideData()
    {

    }

    public PuzzleSideData(PuzzleSideData.Interlocking interlocking, EssenceEnum.Essence sideEssence)
    {
        _sideEssence = sideEssence;
        _interlocking = interlocking;
    }

    /// <summary>
    /// 獲取邊的本質屬性
    /// </summary>
    public EssenceEnum.Essence Essence_
    {
        get
        {
            return _sideEssence;
        }
        set
        {
            _sideEssence = value;
        }
    }

    public PuzzleSideData.Interlocking Interlocking_
    {
        get
        {
            return _interlocking;
        }
        set
        {
            _interlocking = value;
        }
    }


    /*public enum SideEssence
    {
        None_無屬性 = 0,
        Strengthe_力量 = 1, //力量
        Wisdom_智慧 = 2,  //智慧
        Belief_信仰 = 3, //信仰
        Soul_靈魂 = 4, //靈魂
    }*/

    public enum Interlocking //拼圖凹凸
    {
        None_無凹凸 = 0, //平
        indentations_凹陷 = 1, //凹
        protrusions_突起 = 2,  //凸
    }

    public PuzzleSideData RandomlyGeneratedPuzzleData(PuzzleSideData puzzleSideData) //隨機拼圖邊
    {
        puzzleSideData.Interlocking_ = (PuzzleSideData.Interlocking)UnityEngine.Random.Range(1, 3);
        puzzleSideData.Essence_ = (EssenceEnum.Essence)UnityEngine.Random.Range(1, 5);

        return puzzleSideData;
    }
}
