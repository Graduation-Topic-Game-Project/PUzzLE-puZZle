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
        Strength = 1, //�O�q
        Wisdom = 2,  //���z
        Belief = 3, //�H��
        Soul = 4, //�F��
    }

    public enum Interlocking //���ϥW�Y
    {
        None = 0, //��
        indentations = 1, //�W
        protrusions = 2,  //�Y
    }
}
