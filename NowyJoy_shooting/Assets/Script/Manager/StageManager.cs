using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public GameManager GM;
    public GameObject ptnManager;
    public Time_UI time;
    public Pause pause;

    public GameObject Over;
    public GameObject Clear;
    // Start is called before the first frame update
    private void Awake()
    {
        GM = GameManager.GM_Instance;
        ptnManager.SetActive(true); 
    }

    // Update is called once per frame

    private void Update()
    {
        if (pause != null)
        {
            GameOver();
            GameClear();
        }
    }

    void GameOver()
    {

        if (GM.HP <= 0 && Over != null)
        {
            pause.isPause = true;
            Over.SetActive(true);
        }

    }

    void GameClear()
    {
        
            if (time.min < 0)
            {
                pause.isPause = true;
                Clear.SetActive(true);
                GM.stageUnlock[GM.stagenum] = true;
            }
     

    }

    public void ReStart()
    {
        pause.isPause = false;
        SceneManager.LoadScene("stage" + GM.stagenum);
    }

    public void GotoTitle()
    {
        pause.isPause = false;
        ptnManager.SetActive(false);
        SceneManager.LoadScene("StageSelect");
    }

    public void nextStage()
    {
        pause.isPause = false;
        ptnManager.SetActive(false);
        SceneManager.LoadScene("stage" + (GM.stagenum + 1));
        GM.stagenum += 1;
    }
}
