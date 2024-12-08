using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[Serializable]
public class Puzzle : MonoBehaviour
{
    public PuzzleData puzzleData = new();
    public Image _upImage, _downImage, _rightImage, _leftImage, _middleImage, _bgImage;
    public List<Sprite> PuzzleEssenceImage = new List<Sprite>();
    public List<Sprite> PuzzleSideEssenceImage = new List<Sprite>();
    public List<Sprite> PuzzleSideIndentationImage = new List<Sprite>();
    public Sprite NoneSprite;

    /// <param name="puzzleData_">���w��Ϫ�PuzzleData</param>
    public Puzzle(PuzzleData puzzleData_)
    {
        puzzleData = puzzleData_;
    }
    public Puzzle()
    {

    }

    /// <summary>
    /// �]�w�����ݩ�
    /// </summary>
    public EssenceEnum.Essence Essence
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

    public void ReUpdate_PuzzleSide_Image(PuzzleSideData _puzzleSideData, Image _sideImage) //��s������ϥ�
    {
        if (_puzzleSideData.Interlocking_ == PuzzleSideData.Interlocking.indentations_�W��)
        {
            //_sideImage.sprite = PuzzleSideEssenceImage[5];
            _sideImage.sprite = PuzzleSideIndentationImage[(int)_puzzleSideData.Essence_];
        }
        else
        {
            _sideImage.sprite = PuzzleSideEssenceImage[(int)_puzzleSideData.Essence_];
        }
    }

    public void Hide_BgImage_and_MidImage() //���ë��ϹϪO�P�D�n�_��
    {
        _middleImage.sprite = NoneSprite;
        _bgImage.sprite = NoneSprite;
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
    public EssenceEnum.Essence _essence = EssenceEnum.Essence.Strengthe_�O�q;
    [Header("��������"), Tooltip("��������"), SerializeField]
    private PuzzleType _puzzleType;
    [SerializeField]
    private PuzzleSideData _up, _down, _right, _left = new();
    public (int, int) puzzlePosition = (-1, -1);

    /// <summary>�����ݩ�</summary>
    public EssenceEnum.Essence Essence { get => _essence; set { _essence = value; } }

    /// <summary>��������</summary>
    public PuzzleType Type { get => _puzzleType; set { _puzzleType = value; } }

    public PuzzleSideData UpSide_ { get { return _up; } set { _up = value; } }
    public PuzzleSideData DownSide_ { get { return _down; } set { _down = value; } }
    public PuzzleSideData RightSide_ { get { return _right; } set { _right = value; } }
    public PuzzleSideData LeftSide_ { get { return _left; } set { _left = value; } }

    public enum PuzzleType
    {
        Puzzle_���q���� = 0, //���q����
        EnemyPuzzle_�Ĥ���� = 1, //�Ĥ����
        PartnerPuzzle_�٦���� = 2, //�٦����
    }

    public void RandomlyGeneratedPuzzleData() //�H������
    {
        _essence = (EssenceEnum.Essence)UnityEngine.Random.Range(1, 5);

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

