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
    public int[] starnum;
    public bool Reset;
    

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

        if (Reset)
        {
            PlayerPrefs.DeleteAll();
        }
        
    }
     
    void Start()
    {
        SceneManager.sceneLoaded += LoadedsceneEvent;
        
    }
 
    void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        Load();
        Loadstar();
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
    public void starSaver(int stagenum, int Starnum)
    {
        if (stagenum == 1)
        {
            Debug.Log("별 저장1");
            PlayerPrefs.SetInt("Star1", Starnum);
        }
        else if (stagenum == 2)
        {
            Debug.Log("별 저장2");
            PlayerPrefs.SetInt("Star2", Starnum);
        }
        else if (stagenum == 3)
        {
            Debug.Log("별 저장3");
            PlayerPrefs.SetInt("Star3", Starnum);
        }
        else if (stagenum == 4)
        {
            Debug.Log("별 저장4");
            PlayerPrefs.SetInt("Star4", Starnum);
        }
        else if (stagenum == 5)
        {
            Debug.Log("별 저장5");
            PlayerPrefs.SetInt("Star5", Starnum);
        }
        else if (stagenum == 6)
        {
            Debug.Log("별 저장6");
            PlayerPrefs.SetInt("Star6", Starnum);
        }
        else if (stagenum == 7)
        {
            Debug.Log("별 저장7");
            PlayerPrefs.SetInt("Star7", Starnum);
        }
        else if (stagenum == 8)
        {
            Debug.Log("별 저장8");
            PlayerPrefs.SetInt("Star8", Starnum);
        }
    }
    public void Loadstar()
    {
        if (PlayerPrefs.HasKey("Star1"))
        {
            if (CurrentStage == 1)
            {
                starnum[1] = PlayerPrefs.GetInt("Star1");
            }
            else if (CurrentStage == 2)
            {
                starnum[1] = PlayerPrefs.GetInt("Star1");
                starnum[2] = PlayerPrefs.GetInt("Star2");
            }
            else if (CurrentStage == 3)
            {
                starnum[1] = PlayerPrefs.GetInt("Star1");
                starnum[2] = PlayerPrefs.GetInt("Star2");
                starnum[3] = PlayerPrefs.GetInt("Star3");
            }
            else if (CurrentStage == 4)
            {
                starnum[1] = PlayerPrefs.GetInt("Star1");
                starnum[2] = PlayerPrefs.GetInt("Star2");
                starnum[3] = PlayerPrefs.GetInt("Star3");
                starnum[4] = PlayerPrefs.GetInt("Star4");
            }
            else if (CurrentStage == 5)
            {
                starnum[1] = PlayerPrefs.GetInt("Star1");
                starnum[2] = PlayerPrefs.GetInt("Star2");
                starnum[3] = PlayerPrefs.GetInt("Star3");
                starnum[4] = PlayerPrefs.GetInt("Star4");
                starnum[5] = PlayerPrefs.GetInt("Star5");
            }
            else if (CurrentStage == 6)
            {
                starnum[1] = PlayerPrefs.GetInt("Star1");
                starnum[2] = PlayerPrefs.GetInt("Star2");
                starnum[3] = PlayerPrefs.GetInt("Star3");
                starnum[4] = PlayerPrefs.GetInt("Star4");
                starnum[5] = PlayerPrefs.GetInt("Star5");
                starnum[6] = PlayerPrefs.GetInt("Star6");
            }
            else if (CurrentStage == 7)
            {
                starnum[1] = PlayerPrefs.GetInt("Star1");
                starnum[2] = PlayerPrefs.GetInt("Star2");
                starnum[3] = PlayerPrefs.GetInt("Star3");
                starnum[4] = PlayerPrefs.GetInt("Star4");
                starnum[5] = PlayerPrefs.GetInt("Star5");
                starnum[6] = PlayerPrefs.GetInt("Star6");
                starnum[7] = PlayerPrefs.GetInt("Star7");
            }
            else if (CurrentStage == 8)
            {
                starnum[1] = PlayerPrefs.GetInt("Star1");
                starnum[2] = PlayerPrefs.GetInt("Star2");
                starnum[3] = PlayerPrefs.GetInt("Star3");
                starnum[4] = PlayerPrefs.GetInt("Star4");
                starnum[5] = PlayerPrefs.GetInt("Star5");
                starnum[6] = PlayerPrefs.GetInt("Star6");
                starnum[7] = PlayerPrefs.GetInt("Star7");
                starnum[8] = PlayerPrefs.GetInt("Star8");
            }
        }
    }
}
