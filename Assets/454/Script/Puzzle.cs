using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[Serializable]
public class Puzzle : MonoBehaviour
{
    public PuzzleData puzzleData = new();
    public Image _upImage, _downImage, _rightImage, _leftImage, _middleImage;

    public Puzzle(PuzzleData.PuzzleEssence _essence)
    {
        puzzleData._essence = _essence;
    }

    /// <summary>
    /// �]�w�����ݩ�
    /// </summary>
    public PuzzleData.PuzzleEssence Essence
    {
        get
        {
            return puzzleData._essence;
        }
        set
        {
            puzzleData._essence = value;
        }
    }
}

[CreateAssetMenu(fileName = "New Puzzle", menuName = "ScriptableObject/Puzzle", order = 2)]
public class PuzzleScriptableObject : ScriptableObject
{
    public PuzzleData PuzzleDatas;
}

[Serializable]
public class PuzzleData
{
    [Header("���Ϫ������ݩ�"), Tooltip("���Ϫ������ݩ�")]
    public PuzzleEssence _essence = PuzzleEssence.Strengthe_�O�q;
    public SideData _up, _down, _right, _left = new();

    public enum PuzzleEssence
    {
        None_�L�ݩ� = 0,
        Strengthe_�O�q = 1, //�O�q
        Wisdom_���z = 2,  //���z
        Belief_�H�� = 3, //�H��
        Soul_�F�� = 4, //�F��
    }
}

