using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PartnerData
{
    /// <summary> ¹Ù¦ñ¦W¦r </summary>
    [SerializeField]
    private string _partnerName;
    /// <summary> ¹Ù¦ñ¥ßÃ¸ </summary>
    [SerializeField]
    public Sprite PartnerTachie;
    /// <summary> ¹Ù¦ñ¾Ô°«¤p¤H </summary>
    [SerializeField]
    public Sprite PartnerCuteBattle;
    /// <summary> ¹Ù¦ñ«Ý¾÷°ÊºA </summary>
    [SerializeField]
    public PartnerLive2D PartnerSetLive2D;
    /// <summary> ¹Ù¦ñÄÝ©Ê </summary>
    [SerializeField]
    EssenceEnum.Essence _essence;
    [SerializeField]
    /// <summary> ¹Ù¦ñ°Êµe_§ðÀ» </summary>
    public BattleAnimation partnerAnimation_Attack;
    /// <summary> ¹Ù¦ñ«÷¹Ï </summary>
    public List<PuzzleData> partnersPuzzle;




    [SerializeField]
    private int _level = 1;
    [SerializeField]
    private int _hp;

    public EssenceEnum.Essence Essence { get => _essence; }
    public int Hp { get => Hp; }
    public int Lv { get => _level; }
}


[CreateAssetMenu(fileName = "New Parther", menuName = "ScriptableObject/Partner", order = 1)]
public class Partner : ScriptableObject
{
    public PartnerData partnerData;
    //public Puzzle puzzle1
}