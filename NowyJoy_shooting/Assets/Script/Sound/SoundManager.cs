using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Sound
{
    public string name; //�� �̸�
    public AudioClip clip; // ��
}

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
            }

            return instance;
        }
    }

    public Sound[] effectSounds; //ȿ���� ����� Ŭ����
    public AudioSource[] AudioSourceEfects;// ȿ�������� ���ÿ� ������ ��� �� �� ����
    public string[] playSoundName; //��� ���� ȿ���� ���� �̸� �迭

    float masterValue; //������ ���� ��
    float bgmValue; //��� ���� ��
    float sfxValue; //ȿ���� ���� ��

    private AudioSource bgmPlayer; //��� �÷��� ����� �ҽ�

    [SerializeField]
    private AudioClip mainBgmAudioClip; //����ȭ�鿡�� ����� BGM
    [SerializeField]
    private AudioClip adventureBgmAudioClip; //��庥�ľ����� ����� BGM


    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject); //���� ������ ����� ��. �̰� ���x

        bgmPlayer = GameObject.Find("BGMSoundPlayer").GetComponent<AudioSource>();
        //sfxPlayer = GameObject.Find("SFXSoundPlayer").GetComponent<AudioSource>();

        //foreach (AudioClip audioclip in sfxAudioClips)
        //{
        //    audioClipsDic.Add(audioclip.name, audioclip);
        //}

        //foreach (AudioClip audioclip in sfxAudioClips)
        //{
        //    Debug.Log(audioclip);
        //}

        

        PlayBGMSound();

    }

    private void Start()
    {
        playSoundName = new string[AudioSourceEfects.Length];
    }

    public void PlaySE(string _name)
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if (_name == effectSounds[i].name)
            {
                for (int j = 0; j < AudioSourceEfects.Length; j++)
                {
                    if (!AudioSourceEfects[j].isPlaying)
                    {
                        AudioSourceEfects[j].clip = effectSounds[i].clip;
                        AudioSourceEfects[j].Play();
                        playSoundName[j] = effectSounds[i].name;
                        return;
                    }
                }
                Debug.Log("��� ���� AudioSource�� ��� ���Դϴ�.");
                return;
            }
        }
        Debug.Log(_name + "���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�.");
    }

    // ȿ�� ���� ��� : �̸��� �ʼ� �Ű�����, ������ ������ �Ű������� ����
    //public void PlaySFXSound(string sfxname, AudioClip clip)
    //{
    //    switch (sfxname)
    //    {
    //        case "getcoin":
    //            sfxPlayer.PlayOneShot(clip);
    //            break;
    //        case "click":
    //            sfxPlayer.PlayOneShot(click);
    //            break;
    //        default:
    //            Debug.Log("ȿ������ ã�� �� �����ϴ�.");
    //            break;
    //    }
        
    //}

    //BGM ���� ��� : ������ ������ �Ű������� ����
    public void PlayBGMSound()
    {
        bgmPlayer.loop = true; //BGM �����̹Ƿ� ��������
        bgmPlayer.volume = PlayerPrefs.GetFloat("bgmvolume",0.5f);
        bgmPlayer.clip = adventureBgmAudioClip;
        bgmPlayer.Play();
        //if (SceneManager.GetActiveScene().buildIndex == 1)
        //{
        //    bgmPlayer.clip = mainBgmAudioClip;
        //    bgmPlayer.Play();
        //}
        //else if (SceneManager.GetActiveScene().buildIndex == 2)
        //{
        //    bgmPlayer.clip = adventureBgmAudioClip;
        //    bgmPlayer.Play();
        //}
        //���� ���� �´� BGM ���
    }

    public void ChangeMasterVolume(Slider slider)
    {
        AudioListener.volume = slider.value;
        masterValue = slider.value;
        PlayerPrefs.SetFloat("mastervolume", masterValue);
    }

    public void ChangeBgmVolume(Slider slider)
    {
        bgmPlayer.volume = slider.value;
        bgmValue = slider.value;
        PlayerPrefs.SetFloat("bgmvolume", bgmValue);
    }

    public void ChangeSfxVolume(Slider slider)
    {
        //sfxPlayer.volume = slider.value;

        for (int i = 0; i < AudioSourceEfects.Length; i++)
        {
            AudioSourceEfects[i].volume = slider.value;
        }
        sfxValue = slider.value;
        PlayerPrefs.SetFloat("sfxvolume", sfxValue);
    }
}
