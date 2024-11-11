using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class PartnerData
{
    public int _level = 1;
    public int _hp;
    [SerializeField]
    EssenceClass.Essence _essence;
    public List<PuzzleData> partnersPuzzle;

    public EssenceClass.Essence Essence { get => _essence; }
    public int Hp { get => Hp; }
    public int Lv { get => _level; }
}


[CreateAssetMenu(fileName = "New Parther", menuName = "ScriptableObject/Partner", order = 1)]
public class Partner : ScriptableObject
{
    public PartnerData thisPartner;
    //public Puzzle puzzle1
}