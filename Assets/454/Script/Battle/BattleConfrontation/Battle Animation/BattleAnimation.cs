using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAnimation : MonoBehaviour
{
    public Animator animator;

    public string[] animations;
    private void Awake()
    {
        if (animator = null)
        {
            animator = GetComponent<Animator>();
        }

    }
}
