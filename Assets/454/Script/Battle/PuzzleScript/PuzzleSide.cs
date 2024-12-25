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

    private int[] IndentationsHaveEssence_Probability = new int[] { 20, 80 }; //�W�ѱa���ݩʾ��v(20%)

    /// <summary> ��������O�_�s�� </summary>
    public bool Linkage { get; set; }

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

    public enum Interlocking //���ϥW�Y
    {
        None_�L�W�Y = 0, //��
        indentations_�W�� = 1, //�W
        protrusions_��_ = 2,  //�Y
    }

    /// <summary> �H�������� </summary>
    public PuzzleSideData RandomlyGeneratedPuzzleData(PuzzleSideData puzzleSideData) //�H��������
    {
        puzzleSideData.Interlocking_ = (PuzzleSideData.Interlocking)UnityEngine.Random.Range(1, 3);

        if (puzzleSideData.Interlocking_ == Interlocking.protrusions_��_)
            puzzleSideData.Essence_ = (EssenceEnum.Essence)UnityEngine.Random.Range(1, 5);

        if (puzzleSideData.Interlocking_ == Interlocking.indentations_�W��)
        {
            int RandowResults = GetRandow.Randow(IndentationsHaveEssence_Probability); //�Y���W���A�h20%���v�a���ݩ�
            switch (RandowResults)
            {
                case 1: //�^��1�A�S���ݩ�
                    puzzleSideData.Essence_ = EssenceEnum.Essence.None_�L�ݩ�;
                    break;
                case 0: //�^��0�A�a���ݩ�
                    puzzleSideData.Essence_ = (EssenceEnum.Essence)UnityEngine.Random.Range(1, 5);
                    break;
                default://�H�W�����ŦX���o��
                    Debug.LogError("�H��������ɡA�䬰�W�����H���ݩʥX���D");
                    break;
            }
        }

        return puzzleSideData;
    }
}
