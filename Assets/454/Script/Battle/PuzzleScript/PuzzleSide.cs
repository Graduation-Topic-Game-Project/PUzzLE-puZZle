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

    private int[] IndentationsHaveEssence_Probability = new int[] { 20, 80 }; //凹槽帶有屬性機率(20%)

    /// <summary> 此拼圖邊是否連鎖 </summary>
    public bool Linkage { get; set; }

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

    public enum Interlocking //拼圖凹凸
    {
        None_無凹凸 = 0, //平
        indentations_凹陷 = 1, //凹
        protrusions_突起 = 2,  //凸
    }

    /// <summary> 隨機拼圖邊 </summary>
    public PuzzleSideData RandomlyGeneratedPuzzleData(PuzzleSideData puzzleSideData) //隨機拼圖邊
    {
        puzzleSideData.Interlocking_ = (PuzzleSideData.Interlocking)UnityEngine.Random.Range(1, 3);

        if (puzzleSideData.Interlocking_ == Interlocking.protrusions_突起)
            puzzleSideData.Essence_ = (EssenceEnum.Essence)UnityEngine.Random.Range(1, 5);

        if (puzzleSideData.Interlocking_ == Interlocking.indentations_凹陷)
        {
            int RandowResults = GetRandow.Randow(IndentationsHaveEssence_Probability); //若為凹陷，則20%機率帶有屬性
            switch (RandowResults)
            {
                case 1: //回傳1，沒有屬性
                    puzzleSideData.Essence_ = EssenceEnum.Essence.None_無屬性;
                    break;
                case 0: //回傳0，帶有屬性
                    puzzleSideData.Essence_ = (EssenceEnum.Essence)UnityEngine.Random.Range(1, 5);
                    break;
                default://以上都不符合走這個
                    Debug.LogError("隨機拼圖邊時，邊為凹陷時隨機屬性出問題");
                    break;
            }
        }

        return puzzleSideData;
    }
}
