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
    public EssenceClass.Essence Essence
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

        if (puzzleData.UpSide_ == null)
            Debug.Log("123 puzzleData.Up_ == null");
        ReUpdate_PuzzleSide_Image(puzzleData.UpSide_, _upImage);
        ReUpdate_PuzzleSide_Image(puzzleData.DownSide_, _downImage);
        ReUpdate_PuzzleSide_Image(puzzleData.RightSide_, _rightImage);
        ReUpdate_PuzzleSide_Image(puzzleData.LeftSide_, _leftImage);
    }

    public void ReUpdate_PuzzleSide_Image(PuzzleSideData _puzzleSideData, Image _sideImage)
    {
        if (_puzzleSideData.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��)
        {
            _sideImage.sprite = PuzzleSideEssenceImage[5];
        }
        else
        {
            _sideImage.sprite = PuzzleSideEssenceImage[(int)_puzzleSideData.Essence_];
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
    public EssenceClass.Essence _essence = EssenceClass.Essence.Strengthe_�O�q;
    [SerializeField]
    private PuzzleSideData _up, _down, _right, _left = new();


    public EssenceClass.Essence Essence { get => _essence; set { _essence = value; } }

    public PuzzleSideData UpSide_ { get { return _up; } }
    public PuzzleSideData DownSide_ { get { return _down; } }
    public PuzzleSideData RightSide_ { get { return _right; } }
    public PuzzleSideData LeftSide_ { get { return _left; } }

    /*public enum PuzzleEssence
    {
        None_�L�ݩ� = 0,
        Strengthe_�O�q = 1, //�O�q
        Wisdom_���z = 2,  //���z
        Belief_�H�� = 3, //�H��
        Soul_�F�� = 4, //�F��
    }*/

    public void RandomlyGeneratedPuzzleData() //�H������
    {
        _essence = (EssenceClass.Essence)UnityEngine.Random.Range(0, 5);

        _up = new PuzzleSideData();
        _down = new PuzzleSideData();
        _left = new PuzzleSideData();
        _right = new PuzzleSideData();

        _up = _up.RandomlyGeneratedPuzzleData(_up);
        _down = _down.RandomlyGeneratedPuzzleData(_down);
        _left = _left.RandomlyGeneratedPuzzleData(_left);
        _right = _right.RandomlyGeneratedPuzzleData(_right);
    }
}

