using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSide : MonoBehaviour
{
    public Essence _essence;
    public Interlocking _interlocking;

    public enum Essence
    {
        None = 0,
        Strength = 1, //¤O¶q
        Wisdom = 2,  //´¼¼z
        Belief = 3, //«H¥õ
        Soul = 4, //ÆF»î
    }

    public enum Interlocking //«÷¹Ï¥W¥Y
    {
        None = 0, //¥­
        indentations = 1, //¥W
        protrusions = 2,  //¥Y
    }
}
