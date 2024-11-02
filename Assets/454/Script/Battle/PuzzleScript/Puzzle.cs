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

    /// <summary>
    /// ��s���ϹϤ�
    /// </summary>
    public void ReUpdate_PuzzleEssence_Image()
    {
        _middleImage.sprite = PuzzleEssenceImage[(int)this.Essence];

        ReUpdate_PuzzleSide_Image(puzzleData.Up_, _upImage);
        ReUpdate_PuzzleSide_Image(puzzleData.Down_, _downImage);
        ReUpdate_PuzzleSide_Image(puzzleData.Right_, _rightImage);
        ReUpdate_PuzzleSide_Image(puzzleData.Left_, _leftImage);

    }

    public void ReUpdate_PuzzleSide_Image(PuzzleSideData _puzzleSideData, Image _sideImage)
    {
        if (_puzzleSideData.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��)
        {
            _sideImage.sprite = PuzzleSideEssenceImage[5];
        }
        else
        {
            _sideImage.sprite = PuzzleSideEssenceImage[(int)puzzleData.Up_.Interlocking_];
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
    public PuzzleSideData _up, _down, _right, _left = new();


    public PuzzleSideData Up_ { get { return _up; } }
    public PuzzleSideData Down_ { get { return _down; } }
    public PuzzleSideData Right_ { get { return _right; } }
    public PuzzleSideData Left_ { get { return _left; } }


    public enum PuzzleEssence
    {
        None_�L�ݩ� = 0,
        Strengthe_�O�q = 1, //�O�q
        Wisdom_���z = 2,  //���z
        Belief_�H�� = 3, //�H��
        Soul_�F�� = 4, //�F��
    }
}

