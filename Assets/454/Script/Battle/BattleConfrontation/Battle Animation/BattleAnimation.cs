using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAnimation : MonoBehaviour
{
    public Animator animator;
    private void Awake()
    {
        if (animator = null)
        {
            animator = GetComponent<Animator>();
        }

    }
}
