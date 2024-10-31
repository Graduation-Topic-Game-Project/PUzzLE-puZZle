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
    public List<Sprite> PuzzleEssenceImage = new List<Sprite>();
    public List<Sprite> PuzzleSideEssenceImage = new List<Sprite>();

    public Puzzle(PuzzleData.PuzzleEssence _essence)
    {
        puzzleData._essence = _essence;
    }

    /// <param name="puzzleData_">���w��Ϫ�PuzzleData</param>
    public Puzzle(PuzzleData puzzleData_)
    {
        puzzleData = puzzleData_;
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

    public PuzzleSideData.SideEssence UpSideEssence
    {
        get
        {
            return puzzleData._up._essence;
        }
    }

    /// <summary>
    /// ��s���ϹϤ�
    /// </summary>
    public void ReUpdate_PuzzleEssence_Image()
    {
        _middleImage.sprite = PuzzleEssenceImage[(int)this.Essence];

        //_upImage.sprite = PuzzleSideEssenceImage[(int)this.Essence];

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
    public PuzzleSideData _up, _down, _right, _left = new();

    //public PuzzleData.PuzzleEssence 


    public enum PuzzleEssence
    {
        None_�L�ݩ� = 0,
        Strengthe_�O�q = 1, //�O�q
        Wisdom_���z = 2,  //���z
        Belief_�H�� = 3, //�H��
        Soul_�F�� = 4, //�F��
    }
}

