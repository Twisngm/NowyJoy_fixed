using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Sound
{
    public string name; //곡 이름
    public AudioClip clip; // 곡
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

    public Sound[] effectSounds; //효과음 오디오 클립들
    public AudioSource[] AudioSourceEfects;// 효과음들을 동시에 여러개 재생 될 수 있음
    public string[] playSoundName; //재생 중인 효과음 사운드 이름 배열

    float masterValue; //마스터 볼륨 값
    float bgmValue; //브금 볼륨 값
    float sfxValue; //효과음 볼륨 값

    public AudioSource bgmPlayer; //브금 플레이 오디오 소스

    [SerializeField]
    private AudioClip mainBgmAudioClip; //메인화면에서 사용할 BGM
    [SerializeField]
    private AudioClip TitleBgmAudioClip; //다른 씬에서 사용할 BGM test

    [SerializeField]
    private AudioClip ModeSelectBgmAudioClip; //다른 씬에서 사용할 BGM


    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject); //여러 씬에서 사용할 것. 이건 사용x

        bgmPlayer = GameObject.Find("BGMSoundPlayer").GetComponent<AudioSource>();
        //sfxPlayer = GameObject.Find("SFXSoundPlayer").GetComponent<AudioSource>();

        PlayBGMSound();
    }

    private void Start()
    {
        playSoundName = new string[AudioSourceEfects.Length];
    }

    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeBGM(); // 브금 변경하는 함수
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
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
                Debug.Log("모든 가용 AudioSource가 사용 중입니다.");
                return;
            }
        }
        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니다.");
    }

    public void ChangeBGM()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            bgmPlayer = GameObject.Find("BGMSoundPlayer").GetComponent<AudioSource>();
            bgmPlayer.clip = mainBgmAudioClip;
            bgmPlayer.Play();
        }else if (SceneManager.GetActiveScene().name == "ModeSelect")
        {
            bgmPlayer = GameObject.Find("BGMSoundPlayer").GetComponent<AudioSource>();
            bgmPlayer.clip = ModeSelectBgmAudioClip;
            bgmPlayer.Play();
        }
    }

    // 효과 사운드 재생 : 이름을 필수 매개변수, 볼륨을 선택적 매개변수로 지정
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
    //            Debug.Log("효과음을 찾을 수 없습니다.");
    //            break;
    //    }

    //}

    //BGM 사운드 재생 : 볼륨을 선택적 매개변수로 지정
    public void PlayBGMSound()
    {
        bgmPlayer.loop = true; //BGM 사운드이므로 루프설정
        bgmPlayer.volume = PlayerPrefs.GetFloat("bgmvolume",0.5f);
        bgmPlayer.clip = TitleBgmAudioClip;
        bgmPlayer.Play();
        //if (scenemanager.getactivescene().buildindex == 1)
        //{
        //    bgmplayer.clip = mainbgmaudioclip;
        //    bgmplayer.play();
        //}
        //else if (scenemanager.getactivescene().buildindex == 2)
        //{
        //    bgmplayer.clip = adventurebgmaudioclip;
        //    bgmplayer.play();
        //}
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
