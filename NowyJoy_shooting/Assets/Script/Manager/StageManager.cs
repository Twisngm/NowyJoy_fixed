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
    public GameObject PerfectClear;
    public GameObject Clearstar_yellow;
    public GameObject Clearstar_blue;
    float hpcounter;
    // Start is called before the first frame update
    private void Awake()
    {
        GM = GameManager.GM_Instance;
        pause = Pause.Instance;
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
            GM.Save();
            pause.isPause = true;
            Clear.SetActive(true);

            if (GM.HP >= GM.MaxHP * 0.8f)
            {
                PerfectClear.SetActive(true);
                Clearstar_blue.SetActive(true);
            }
            else
            {
                Clear.SetActive(true);
                Clearstar_yellow.SetActive(true);
            }
            GM.stageUnlock[GM.stagenum] = true;
            
        }

    }
    public void ReStart()
    {
        pause.isPause = false;
        SceneManager.LoadScene("stage" + (GM.stagenum));
    }

    public void GotoTitle()
    {
        pause.isPause = false;
        ptnManager.SetActive(false);
        SceneManager.LoadScene("Title");
    }

    public void nextStage()
    {
        pause.isPause = false;
        ptnManager.SetActive(false);
        GM.CurrentStage = GM.stagenum+1;
        SceneManager.LoadScene("stage" + (GM.stagenum + 1));
       // GM.stagenum += 1;
    }
}
