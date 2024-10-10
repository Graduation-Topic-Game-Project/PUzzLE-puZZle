using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    public PuzzleSide _up, _down, _right, _left;
    public Image _upImage, _downImage, _rightImage, _leftImage, _middleImage;
    public Essence _essence;


    public enum Essence
    {
        None = 0,
        Strength = 1, //¤O¶q
        Wisdom = 2,  //´¼¼z
        Belief = 3, //«H¥õ
        Soul = 4, //ÆF»î
    }


}
