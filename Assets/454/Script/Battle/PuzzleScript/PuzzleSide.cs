using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PuzzleSide : MonoBehaviour
{
    public PuzzleSideData sideData = new();

    public PuzzleSide(PuzzleSideData.Interlocking interlocking, EssenceEnum.Essence sideEssence)
    {
        sideData.Essence_ = sideEssence;
        sideData.Interlocking_ = interlocking;
    }
}

[Serializable]
public class PuzzleSideData
{
    [SerializeField]
    [Header("�����䪺�����ݩ�"), Tooltip("�����䪺�����ݩ�")]
    private EssenceEnum.Essence _sideEssence = EssenceEnum.Essence.Strengthe_�O�q;
    [SerializeField]
    [Header("�����䪺�W�Y"), Tooltip("�����䪺�W�Y")]
    private Interlocking _interlocking = Interlocking.indentations_�W��;

    public PuzzleSideData()
    {

    }

    public PuzzleSideData(PuzzleSideData.Interlocking interlocking, EssenceEnum.Essence sideEssence)
    {
        _sideEssence = sideEssence;
        _interlocking = interlocking;
    }

    /// <summary>
    /// ����䪺�����ݩ�
    /// </summary>
    public EssenceEnum.Essence Essence_
    {
        get
        {
            return _sideEssence;
        }
        set
        {
            _sideEssence = value;
        }
    }

    public PuzzleSideData.Interlocking Interlocking_
    {
        get
        {
            return _interlocking;
        }
        set
        {
            _interlocking = value;
        }
    }


    /*public enum SideEssence
    {
        None_�L�ݩ� = 0,
        Strengthe_�O�q = 1, //�O�q
        Wisdom_���z = 2,  //���z
        Belief_�H�� = 3, //�H��
        Soul_�F�� = 4, //�F��
    }*/

    public enum Interlocking //���ϥW�Y
    {
        None_�L�W�Y = 0, //��
        indentations_�W�� = 1, //�W
        protrusions_��_ = 2,  //�Y
    }

    public PuzzleSideData RandomlyGeneratedPuzzleData(PuzzleSideData puzzleSideData) //�H��������
    {
        puzzleSideData.Interlocking_ = (PuzzleSideData.Interlocking)UnityEngine.Random.Range(1, 3);
        puzzleSideData.Essence_ = (EssenceEnum.Essence)UnityEngine.Random.Range(1, 5);

        return puzzleSideData;
    }
}
