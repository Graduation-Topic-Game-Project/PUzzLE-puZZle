using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PartnerData
{
    [SerializeField]
    private string _partnerName;
    [SerializeField]
    public Sprite PartnerTachie;
    [SerializeField]
    public Sprite PartnerCuteBattle;
    [SerializeField]
    private int _level = 1;
    [SerializeField]
    private int _hp;
    [SerializeField]
    EssenceEnum.Essence _essence;
    public List<PuzzleData> partnersPuzzle;

    public EssenceEnum.Essence Essence { get => _essence; }
    public int Hp { get => Hp; }
    public int Lv { get => _level; }
}


[CreateAssetMenu(fileName = "New Parther", menuName = "ScriptableObject/Partner", order = 1)]
public class Partner : ScriptableObject
{
    public PartnerData thisPartner;
    //public Puzzle puzzle1
}