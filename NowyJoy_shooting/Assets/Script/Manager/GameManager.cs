using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int MaxHP;
    public int HP;
    public int stagenum;
    public int CurrentStage = 1;
    public bool[] stageUnlock;
    public bool isUnlock = false;
    public bool Perfectmode;
    

    static GameManager GM_instance;

    public static GameManager GM_Instance
    {
        get
        {
            if (GM_instance == null)
            {
                GM_instance = FindObjectOfType<GameManager>();
            }

            return GM_instance;
        }
    }
    private void Awake()
    {
        if (GM_Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        
    }
     
    void Start()
    {
        SceneManager.sceneLoaded += LoadedsceneEvent;
        
    }
 
    void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        Load();
        HP = MaxHP;
       switch(SceneManager.GetActiveScene().buildIndex) // stagenum 초기화
        {
            case 0:
                stagenum = 0;
                break;
            case 1:
                stagenum = 0;
                break;
            case 2:
                stagenum = 0;
                break;
            case 3:
                stagenum = 1; // 스테이지 1
                break;
            case 4:
                stagenum = 2; // 스테이지 2
                break;
            case 5:
                stagenum = 3; // 스테이지 3
                break;
            case 6:     // 스테이지 4
                stagenum = 4;
                break;
            case 7: // 스테이지 5
                stagenum = 5;
                break;
            case 8:
                stagenum = 6;
                break;
            case 9:
                stagenum = 7;
                break;
            case 10:
                stagenum = 8;
                break;
            case 11:
                stagenum = 9;
                break;
        }
        Time.timeScale = 1;
    
        /*
        if (stagenum != 0)
        {
            time = FindObjectOfType<Time_UI>();
            pause = FindObjectOfType<Pause>();
            ptnManager = GameObject.Find("Managers").transform.Find("patternManager").gameObject;
            Over = GameObject.Find("UI").transform.Find("BlackWindow_GameOver").gameObject;
            Clear = GameObject.Find("UI").transform.Find("BlackWindow_GameClear").gameObject;
        }
        if (ptnManager != null)
            ptnManager.SetActive(true);
        Debug.Log("뭐야");
        */

    }
    public void PerfectMode()
    {
        if (!Perfectmode)
            Perfectmode = true;
        else if (Perfectmode)
            Perfectmode = false;
    }
    public void UnlockMode()
    {
        if (!isUnlock)
            isUnlock = true;

        else if (isUnlock)
            isUnlock = false;

            for (int i = 1; i < stageUnlock.Length; i++)
            {
                stageUnlock[i] = isUnlock;
            }
        
    }

    public void Save()
    {
        Debug.Log("저장");
        PlayerPrefs.SetInt("StageDate", CurrentStage);

    }

    public void Load()
    {
        
        if(PlayerPrefs.HasKey("StageDate"))
        {
            CurrentStage = PlayerPrefs.GetInt("StageDate");
        }

    }

    public void StageUnlockLoad()
    {
        Load();
        Debug.Log("로드 완료");
        for(int i = 0; i < CurrentStage; i++)
        {
            stageUnlock[i] = true;
        }
    }

}
