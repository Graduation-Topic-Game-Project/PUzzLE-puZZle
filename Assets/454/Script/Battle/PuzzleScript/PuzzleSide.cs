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
        sideData._sideEssence = sideEssence;
        sideData._interlocking = interlocking;
    }
}

[Serializable]
public class PuzzleSideData
{
    [Header("�����䪺�����ݩ�"), Tooltip("�����䪺�����ݩ�")]
    public SideEssence _sideEssence = SideEssence.Strengthe_�O�q;
    [Header("�����䪺�W�Y"), Tooltip("�����䪺�W�Y")]
    public Interlocking _interlocking = Interlocking.indentations_�W��;


    /// <summary>
    /// ����䪺�����ݩ�
    /// </summary>
    public PuzzleSideData.SideEssence Essence_
    {
        get
        {
            return _sideEssence;
        }
    }

    public PuzzleSideData.Interlocking Interlocking_
    {
        get
        {
            return _interlocking;
        }
    }


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