using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InspirationButtonController : MonoBehaviour
{
    Button _button;
    private Animator animator;
    private Animator animator2;

    public GameObject EndTurnButton;
    public GameObject Bal_And_Sword_Button;
    public GameObject Shodow;
    public bool isOpen;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator2 = gameObject.transform.parent.gameObject.GetComponent<Animator>();

        _button = GetComponent<Button>(); //­q¾\«ö¯ÃÂIÀ»¨Æ¥ó
        _button.onClick.AddListener(OpenButton);
        isOpen = false;

    }

    void OpenButton()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            animator.SetBool("IsOpen",true);
            animator2.SetBool("IsOpen", true);
        }
        else
        {
            animator.SetBool("IsOpen", false);
            animator2.SetBool("IsOpen", false);
        }

        EndTurnButton.SetActive(isOpen);
        Bal_And_Sword_Button.SetActive(isOpen);
        Shodow.SetActive(isOpen);


    }
}
