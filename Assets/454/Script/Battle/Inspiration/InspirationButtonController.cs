using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InspirationButtonController : MonoBehaviour
{
    Button _button;
    private Animator animator; //�F�P�ȫ��sanimator
    private Animator animator2; //����F�P�Ȥ���animator�A�}�B��

    public GameObject EndTurnButton;
    public GameObject Bal_And_Sword_Button;
    public GameObject Shodow;
    public GameObject Particle_System; //�ɤl�ĪG
    public bool isOpen;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator2 = gameObject.transform.parent.gameObject.GetComponent<Animator>();

        _button = GetComponent<Button>(); //�q�\�����I���ƥ�
        _button.onClick.AddListener(OpenButton);
        isOpen = false;

        EndTurnButton.GetComponent<EndTurnButton>().Event_CloseInspiration += this.CloseButton;
    }

    void OpenButton()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            animator.SetBool("IsOpen", true);
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
        Particle_System.SetActive(!isOpen);
    }

    void CloseButton()
    {
        if (isOpen == false) //�Y���ӴN�����F�A�L��
            return;

        OpenButton();
    }
}
