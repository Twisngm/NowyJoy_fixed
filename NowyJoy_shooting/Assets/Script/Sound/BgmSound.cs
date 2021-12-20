using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSound : MonoBehaviour
{
    public Slider masterVolume; //마스터 볼륨 슬라이더
    public Slider bgmVolume; //브금 볼륨 슬라이더
    public Slider sfxVolume; //효과음 볼륨 슬라이더

    private void FixedUpdate()
    {
        masterVolume.value = PlayerPrefs.GetFloat("mastervolume", 0.5f);
        bgmVolume.value = PlayerPrefs.GetFloat("bgmvolume", 0.5f);
        sfxVolume.value = PlayerPrefs.GetFloat("sfxvolume", 0.5f);
    }

    public void ChangeMasterVolume()
    {
        SoundManager.Instance.ChangeMasterVolume(masterVolume);
    }

    public void ChangeBgmVolume()
    {
        SoundManager.Instance.ChangeBgmVolume(bgmVolume);
    }

    public void ChangeSfxVolume()
    {
        SoundManager.Instance.ChangeSfxVolume(sfxVolume);
    }
}
