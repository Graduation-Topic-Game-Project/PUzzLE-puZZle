using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider Master;
    [SerializeField] Slider BGM;
    [SerializeField] Slider Sound;

    private void Start()
    {
        MasterSldOnClick();
        BGMSldOnClick();
        SoundSldOnClick();
    }
    public void MasterSldOnClick()
    {
        audioMixer.SetFloat("vMaster", Master.value * 80 - 80);
    }
    public void BGMSldOnClick()
    {
        audioMixer.SetFloat("vBGM", BGM.value * 90 - 80);
    }
    public void SoundSldOnClick()
    {
        audioMixer.SetFloat("vSound", Sound.value * 90 - 80);
    }
}
