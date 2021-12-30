using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public string stage;
    public int nowStage = 0;
    public bool full_stay = false;
    public bool changeScene = false;
    public bool isNext = false;

    public GameObject yellowstar;
    public GameObject bluestar;
    float timecheck = 0;
    [SerializeField] [Range(1f, 5f)] float scaleSpeed = 1f;

    private SceneChangeManager sceneMG;

   

    private void Awake()
    {
        SceneChangeManager.Instance.isCurtein_Down_finished = false;
        SceneChangeManager.Instance.isCurtein_Up_finished = false;
        SceneChangeManager.Instance.isCurtein_Close_finished = false;
        SceneChangeManager.Instance.isCurtein_Open_finished = false;
       
    }

    private void Update()
    {
        SceneChange();
        StageUnlock();
        if (full_stay)
        {
            sceneLoading();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!full_stay)
            {
                switch (stage)
                {
                    case "1":
                        if (GameManager.GM_Instance.stageUnlock[0])
                        {
                            Debug.Log("1 스테이지로 이동합니다.");
                            StartCoroutine("changing");
                        }
                        break;
                    case "2":
                        if (GameManager.GM_Instance.stageUnlock[1])
                        {
                            Debug.Log("2 스테이지로 이동합니다.");
                            StartCoroutine("changing");
                        }
                        break;
                    case "3":
                        if (GameManager.GM_Instance.stageUnlock[2])
                        {
                            Debug.Log("3 스테이지로 이동합니다.");
                            StartCoroutine("changing");
                        }
                        break;
                    case "4":
                        if (GameManager.GM_Instance.stageUnlock[3])
                        {
                            Debug.Log("4 스테이지로 이동합니다.");
                            StartCoroutine("changing");
                        }
                        break;
                    case "5":
                        if (GameManager.GM_Instance.stageUnlock[4])
                        {
                            Debug.Log("5 스테이지로 이동합니다.");
                            StartCoroutine("changing");
                        }
                        break;
                    case "6":
                        if (GameManager.GM_Instance.stageUnlock[5])
                        {
                            Debug.Log("6 스테이지로 이동합니다.");
                            StartCoroutine("changing");
                        }
                        break;
                    case "7":
                        if (GameManager.GM_Instance.stageUnlock[6])
                        {
                            Debug.Log("7 스테이지로 이동합니다.");
                            StartCoroutine("changing");
                        }
                        break;
                    case "8":
                        if (GameManager.GM_Instance.stageUnlock[7])
                        {
                            Debug.Log("8 스테이지로 이동합니다.");
                            StartCoroutine("changing");
                        }
                        break;
                    case "9":
                        if (GameManager.GM_Instance.stageUnlock[8])
                        {
                            Debug.Log("9 스테이지로 이동합니다.");
                            StartCoroutine("changing");
                        }
                        break;
                }
            }
        }
    }
    void SceneChange()
    {
        if (changeScene)
        {
            changeScene = false;
            SceneChangeManager.Instance.curtein_Down();
        }
    }

    private void sceneLoading()
    {
        if (SceneChangeManager.Instance.isCurtein_Down_finished)
        {
            SceneChangeManager.Instance.isCurtein_Down_finished = false;
            full_stay = false;
            switch (stage)
            {
                case "1":
                    Debug.Log("1스테이지로 이동");                    
                    SceneManager.LoadScene(13);
                    
                    
                    break;
                case "2":
                        Debug.Log("2스테이지로 이동");
                    if (GameManager.GM_Instance.CurrentStage < 3)
                        GameManager.GM_Instance.CurrentStage = 2;
                    SceneManager.LoadScene(4);
                    
                    break;
                case "3":
   
                        Debug.Log("3스테이지로 이동");
                    if (GameManager.GM_Instance.CurrentStage < 4)
                        GameManager.GM_Instance.CurrentStage = 3;
                    SceneManager.LoadScene(5);
                 

                    break;
                    
                case "4":

                        Debug.Log("4스테이지로 이동");
                    if (GameManager.GM_Instance.CurrentStage < 5)
                        GameManager.GM_Instance.CurrentStage = 4;
                    SceneManager.LoadScene(6);
             
                    break;
                case "5":
    
                        Debug.Log("5스테이지로 이동");
                    if (GameManager.GM_Instance.CurrentStage < 6)
                        GameManager.GM_Instance.CurrentStage = 5;
                    SceneManager.LoadScene(7);
                
                    break;
                case "6":

                        Debug.Log("6스테이지로 이동");
                    if (GameManager.GM_Instance.CurrentStage < 7)
                        GameManager.GM_Instance.CurrentStage = 6;
                    SceneManager.LoadScene(8);
                
                    break;
                case "7":
            
                        Debug.Log("7스테이지로 이동");
                    if (GameManager.GM_Instance.CurrentStage < 8)
                        GameManager.GM_Instance.CurrentStage = 7;
                    SceneManager.LoadScene(9);
               
                    break;
                case "8":
         
                        Debug.Log("8스테이지로 이동");
                    if (GameManager.GM_Instance.CurrentStage < 9)
                        GameManager.GM_Instance.CurrentStage = 8;
                    SceneManager.LoadScene(14);
              
                    break;
                case "9":
             
                        Debug.Log("9스테이지로 이동");
                        SceneManager.LoadScene("stage9");
                    GameManager.GM_Instance.CurrentStage = 9;
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine("changing");
        if (!full_stay)
        {
            StartCoroutine("changing_small");
        }
    }

    void changed()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.2f * scaleSpeed * Time.deltaTime, gameObject.transform.localScale.y + 0.2f * scaleSpeed * Time.deltaTime, 0);
    }

    void changed_small()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.2f * scaleSpeed * Time.deltaTime, gameObject.transform.localScale.y - 0.2f * scaleSpeed * Time.deltaTime, 0);
    }


    IEnumerator changing()
    {
        float checkTime = 0f;

        while (checkTime < 2f)
        {
            yield return new WaitForSeconds(0.1f);
            checkTime += 0.1f;
            changed();
            timecheck = checkTime;
        }

        if (checkTime >= 2f)
        {
            changeScene = true;
            full_stay = true;
            yield break;
        }
    }

    IEnumerator changing_small()
    {
        float checkTime = timecheck;
        while (checkTime >= 0f && checkTime < 2f)
        {
            yield return new WaitForSeconds(0.1f);
            checkTime -= 0.1f;
            changed_small();
        }
        if (checkTime < 0f)
        {
            yield break;
        }
    }

    void StageUnlock()
    {
        switch(stage)
        {
            case "1":
                if(GameManager.GM_Instance.stageUnlock[0] == false)
                {
                    this.transform.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.75f);

                }
                else
                {
                    this.transform.GetComponent<SpriteRenderer>().color = Color.white;

                    if (GameManager.GM_Instance.starnum[0] == 1)
                    {
                        yellowstar.SetActive(true);
                    }
                    else if (GameManager.GM_Instance.starnum[0] == 2)
                    {
                        bluestar.SetActive(true);
                        yellowstar.SetActive(false);
                    }
                }
                break;
            case "2":
                if (GameManager.GM_Instance.stageUnlock[1] == false)
                {
                    this.transform.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.75f);
                }
                else
                {
                    this.transform.GetComponent<SpriteRenderer>().color = Color.white;

                    if (GameManager.GM_Instance.starnum[1] == 1)
                    {
                        yellowstar.SetActive(true);
                    }
                    else if (GameManager.GM_Instance.starnum[1] == 2)
                    {
                        bluestar.SetActive(true);
                        yellowstar.SetActive(false);
                    }
                }
                break;
            case "3":
                if (GameManager.GM_Instance.stageUnlock[2] == false)
                {
                    this.transform.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.75f);
                }
                else
                {
                    this.transform.GetComponent<SpriteRenderer>().color = Color.white;

                    if (GameManager.GM_Instance.starnum[2] == 1)
                    {
                        yellowstar.SetActive(true);
                    }
                    else if (GameManager.GM_Instance.starnum[2] == 2)
                    {
                        bluestar.SetActive(true);
                        yellowstar.SetActive(false);
                    }
                }
                break;
            case "4":
                if (GameManager.GM_Instance.stageUnlock[3] == false)
                {
                    this.transform.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.75f);
                }
                else
                {
                    this.transform.GetComponent<SpriteRenderer>().color = Color.white;

                    if (GameManager.GM_Instance.starnum[3] == 1)
                    {
                        yellowstar.SetActive(true);
                    }
                    else if (GameManager.GM_Instance.starnum[3] == 2)
                    {
                        bluestar.SetActive(true);
                        yellowstar.SetActive(false);
                    }
                }
                break;
            case "5":
                if (GameManager.GM_Instance.stageUnlock[4] == false)
                {
                    this.transform.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.75f);
                }
                else
                {
                    this.transform.GetComponent<SpriteRenderer>().color = Color.white;

                    if (GameManager.GM_Instance.starnum[4] == 1)
                    {
                        yellowstar.SetActive(true);
                    }
                    else if (GameManager.GM_Instance.starnum[4] == 2)
                    {
                        bluestar.SetActive(true);
                        yellowstar.SetActive(false);
                    }
                }
                break;
            case "6":
                if (GameManager.GM_Instance.stageUnlock[5] == false)
                {
                    this.transform.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.75f);
                }
                else
                {
                    this.transform.GetComponent<SpriteRenderer>().color = Color.white;

                    if (GameManager.GM_Instance.starnum[5] == 1)
                    {
                        yellowstar.SetActive(true);
                    }
                    else if (GameManager.GM_Instance.starnum[5] == 2)
                    {
                        bluestar.SetActive(true);
                        yellowstar.SetActive(false);
                    }
                }
                break;
            case "7":
                if (GameManager.GM_Instance.stageUnlock[6] == false)
                {
                    this.transform.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.75f);
                }
                else
                {
                    this.transform.GetComponent<SpriteRenderer>().color = Color.white;

                    if (GameManager.GM_Instance.starnum[6] == 1)
                    {
                        yellowstar.SetActive(true);
                    }
                    else if (GameManager.GM_Instance.starnum[6] == 2)
                    {
                        bluestar.SetActive(true);
                        yellowstar.SetActive(false);
                    }
                }
                break;
            case "8":
                if (GameManager.GM_Instance.stageUnlock[7] == false)
                {
                    this.transform.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.75f);
                }
                else
                {
                    this.transform.GetComponent<SpriteRenderer>().color = Color.white;

                    if (GameManager.GM_Instance.starnum[7] == 1)
                    {
                        yellowstar.SetActive(true);
                    }
                    else if (GameManager.GM_Instance.starnum[7] == 2)
                    {
                        bluestar.SetActive(true);
                        yellowstar.SetActive(false);
                    }
                }
                break;
        }    
    }



}
