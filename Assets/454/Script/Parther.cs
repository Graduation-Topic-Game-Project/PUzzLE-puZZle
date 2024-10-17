using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class PartherData
{
    public int Lv = 1;
    public int Hp;
    public List<PuzzleData> parthersPuzzle;
}


[CreateAssetMenu(fileName = "New Parther", menuName = "ScriptableObject/Parther",order = 1)]
public class Parther : ScriptableObject
{
    public PartherData thisParther;
    //public Puzzle puzzle1
}