using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class PartherData
{
    public int Lv;
    public int Hp;
    //public List<Puzzle> partherPuzzle;
    public List<PuzzleData> partherPuzzleData;
}


[CreateAssetMenu(fileName = "New Parther", menuName = "ScriptableObject/Parther",order = 1)]
public class Parther : ScriptableObject
{
    public PartherData thisParther;
    //public Puzzle puzzle1
}