using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSound : MonoBehaviour
{
    public Slider masterVolume; //������ ���� �����̴�
    public Slider bgmVolume; //��� ���� �����̴�
    public Slider sfxVolume; //ȿ���� ���� �����̴�

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
