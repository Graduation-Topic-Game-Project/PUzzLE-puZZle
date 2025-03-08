using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PartnerData
{
    /// <summary> �٦�W�r </summary>
    [SerializeField]
    private string _partnerName;
    /// <summary> �٦��ø </summary>
    [SerializeField]
    public Sprite PartnerTachie;
    /// <summary> �٦�԰��p�H </summary>
    [SerializeField]
    public Sprite PartnerCuteBattle;
    /// <summary> �٦�ݾ��ʺA </summary>
    [SerializeField]
    public PartnerLive2D PartnerSetLive2D;
    /// <summary> �٦��ݩ� </summary>
    [SerializeField]
    EssenceEnum.Essence _essence;
    [SerializeField]
    /// <summary> �٦�ʵe_���� </summary>
    public BattleAnimation partnerAnimation_Attack;
    /// <summary> �٦���� </summary>
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