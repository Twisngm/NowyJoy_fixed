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
    public bool bossClear = false;

    public GameObject Over;
    public GameObject Clear;
    public GameObject PerfectClear;
    public GameObject Clearstar_yellow;
    public GameObject Clearstar_blue;
    float hpcounter;
    // Start is called before the first frame update
    private void Start()
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
            StartCoroutine("GameClear");
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

    IEnumerator GameClear()
    {
        
        if (time.min < 0)
        {
        
            if(GM.stagenum == 2 || GM.stagenum == 3 || GM.stagenum == 5 || GM.stagenum == 6 || GM.stagenum == 8)
            {
                bossClear = true;
                yield return new WaitForSeconds(7.5f);
            }
        
            GM.Save();

            if (GM.stagenum == 8)
            {
                GM.stageUnlock[GM.stagenum] = true;
                if (GM.HP >= (GM.MaxHP * 0.8))
                {
                    GM.starSaver(GM.stagenum, 2);
                }
                else
                {
                    if (GM.starnum[GM.stagenum] != 2)
                    {
                        GM.starSaver(GM.stagenum, 1);
                    }
                }
                SceneManager.LoadScene(15);
            }
            else
            {
                pause.isPause = true;
                if (GM.HP >= (GM.MaxHP * 0.8))
                {
                    PerfectClear.SetActive(true);
                    Clearstar_blue.SetActive(true);
                    GM.CurrentStage = GM.stagenum + 1;
                    GM.starSaver(GM.stagenum, 2);
                }
                else
                {
                    Clear.SetActive(true);
                    Clearstar_yellow.SetActive(true);
                    GM.CurrentStage = GM.stagenum + 1;
                    if (GM.starnum[GM.stagenum-1] != 2)
                    {
                        GM.starSaver(GM.stagenum, 1);
                    }
                }
            }
            //Clear.SetActive(true);

            
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
        
        SceneManager.LoadScene("stage" + (GM.stagenum + 1));
       // GM.stagenum += 1;
    }
    public void GoToEndStage()
    {
        pause.isPause = false;
        ptnManager.SetActive(false);
        GM.CurrentStage = GM.stagenum + 1;
        SceneManager.LoadScene(14);
    }
}
