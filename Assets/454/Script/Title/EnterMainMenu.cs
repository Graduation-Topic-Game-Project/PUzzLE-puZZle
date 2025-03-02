using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//<--���n

public class EnterMainMenu : MonoBehaviour
{
    Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>(); //�q�\�����I���ƥ�
        _button.onClick.AddListener(LoadMainMenu);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
