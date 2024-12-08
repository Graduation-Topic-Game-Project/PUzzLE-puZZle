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

    /// <param name="puzzleData_">指定拚圖的PuzzleData</param>
    public Puzzle(PuzzleData puzzleData_)
    {
        puzzleData = puzzleData_;
    }
    public Puzzle()
    {

    }

    /// <summary>
    /// 設定拼圖屬性
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
    /// 更新拼圖圖片
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

    public void ReUpdate_PuzzleSide_Image(PuzzleSideData _puzzleSideData, Image _sideImage) //更新拼圖邊圖示
    {
        if (_puzzleSideData.Interlocking_ == PuzzleSideData.Interlocking.indentations_凹陷)
        {
            //_sideImage.sprite = PuzzleSideEssenceImage[5];
            _sideImage.sprite = PuzzleSideIndentationImage[(int)_puzzleSideData.Essence_];
        }
        else
        {
            _sideImage.sprite = PuzzleSideEssenceImage[(int)_puzzleSideData.Essence_];
        }
    }

    public void Hide_BgImage_and_MidImage() //隱藏拼圖圖板與主要寶石
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
    [Header("拼圖的本質屬性"), Tooltip("拼圖的本質屬性")]
    public EssenceEnum.Essence _essence = EssenceEnum.Essence.Strengthe_力量;
    [Header("拼圖類型"), Tooltip("拼圖類型"), SerializeField]
    private PuzzleType _puzzleType;
    [SerializeField]
    private PuzzleSideData _up, _down, _right, _left = new();
    public (int, int) puzzlePosition = (-1, -1);

    /// <summary>拼圖屬性</summary>
    public EssenceEnum.Essence Essence { get => _essence; set { _essence = value; } }

    /// <summary>拼圖類型</summary>
    public PuzzleType Type { get => _puzzleType; set { _puzzleType = value; } }

    public PuzzleSideData UpSide_ { get { return _up; } set { _up = value; } }
    public PuzzleSideData DownSide_ { get { return _down; } set { _down = value; } }
    public PuzzleSideData RightSide_ { get { return _right; } set { _right = value; } }
    public PuzzleSideData LeftSide_ { get { return _left; } set { _left = value; } }

    public enum PuzzleType
    {
        Puzzle_普通拼圖 = 0, //普通拼圖
        EnemyPuzzle_敵方拼圖 = 1, //敵方拼圖
        PartnerPuzzle_夥伴拼圖 = 2, //夥伴拼圖
    }

    public void RandomlyGeneratedPuzzleData() //隨機拼圖
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

