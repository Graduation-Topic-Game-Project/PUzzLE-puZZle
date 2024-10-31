using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PuzzleSide : MonoBehaviour
{
    public PuzzleSideData sideData = new();

    public PuzzleSide(PuzzleSideData.Interlocking interlocking, PuzzleSideData.SideEssence sideEssence)
    {
        sideData._essence = sideEssence;
        sideData._interlocking = interlocking;
    }

    public PuzzleSideData.SideEssence Essence
    {
        get
        {
            return sideData._essence;
        }
    }
}

[Serializable]
public class PuzzleSideData
{
    [Header("�����䪺�����ݩ�"), Tooltip("�����䪺�����ݩ�")]
    public SideEssence _essence = SideEssence.Strengthe_�O�q;
    [Header("�����䪺�W�Y"), Tooltip("�����䪺�W�Y")]
    public Interlocking _interlocking = Interlocking.indentations_�W��;

    public enum SideEssence
    {
        None_�L�ݩ� = 0,
        Strengthe_�O�q = 1, //�O�q
        Wisdom_���z = 2,  //���z
        Belief_�H�� = 3, //�H��
        Soul_�F�� = 4, //�F��
    }

    public enum Interlocking //���ϥW�Y
    {
        None_�L�W�Y = 0, //��
        indentations_�W�� = 1, //�W
        protrusions_��_ = 2,  //�Y

    }
}
