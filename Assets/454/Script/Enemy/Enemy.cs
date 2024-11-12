using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObject/Enemy", order = 2)]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    public string enemyName;
    [SerializeField]
    public Sprite EnemyImage;
    [SerializeField]
    private int _enemyAtk;
}


