using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    [SerializeField] Button Setting_Button;
    [SerializeField] Button Audio_Button;
    bool isSettingPlaneOpen;
    bool isAudioOpen;
    [SerializeField] GameObject SettingPlane;
    [SerializeField] GameObject AudioPlane;

    private void Awake()
    {
        isSettingPlaneOpen = false;
        isAudioOpen = false;
        AudioPlane.SetActive(isAudioOpen);
        SettingPlane.SetActive(isSettingPlaneOpen);
    }

    public void OpenSettingPlane()
    {
        isSettingPlaneOpen = !isSettingPlaneOpen;
        SettingPlane.SetActive(isSettingPlaneOpen);
    }
    public void OpenAudioPlane()
    {
        isAudioOpen = !isAudioOpen;
        AudioPlane.SetActive(isAudioOpen);
    }

}
