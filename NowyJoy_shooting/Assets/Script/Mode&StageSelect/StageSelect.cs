using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public string stage;
    public bool full_stay = false;
    public bool changeScene = false;
    float timecheck = 0;
    [SerializeField] [Range(1f, 5f)] float scaleSpeed = 1f;

    GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();   
    }
    private void Update()
    {
        SceneChange();
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
                        Debug.Log("1 스테이지로 이동합니다.");
                        StartCoroutine("changing");
                    break;
                    case "2":
                        Debug.Log("2 스테이지로 이동합니다.");
                        StartCoroutine("changing");
                        break;
                    case "3":
                        Debug.Log("3 스테이지로 이동합니다.");
                        StartCoroutine("changing");
                        break;
                    case "4":
                        Debug.Log("4 스테이지로 이동합니다.");
                        StartCoroutine("changing");
                        break;
                    case "5":
                        Debug.Log("5 스테이지로 이동합니다.");
                        StartCoroutine("changing");
                        break;
                }
            }
        }
    }
    void SceneChange()
    {
        if (changeScene)
        {
            switch (stage)
            {
                case "1":
                    SceneChangeManager.Instance.FadeOut();
                    StartCoroutine("sceneLoading", 1);
                  
                    break;
                case "2":
                    SceneChangeManager.Instance.FadeOut();
                    StartCoroutine("sceneLoading", 2);
                    
                    break;
                case "3":
                    SceneChangeManager.Instance.FadeOut();
                    StartCoroutine("sceneLoading", 3);

                    break;

                case "4":
                    SceneChangeManager.Instance.FadeOut();
                    StartCoroutine("sceneLoading", 4);

                    break;

                case "5":
                    SceneChangeManager.Instance.FadeOut();
                    StartCoroutine("sceneLoading", 5);
                   
                    break;
            }
        }
    }

    IEnumerator sceneLoading(float stage_number)
    {
        yield return new WaitForSeconds(1.0f);

        if (stage_number == 1)
        {
           
            SceneManager.LoadScene("stage1");
        }
        else if (stage_number == 2)
        {
          
            SceneManager.LoadScene("stage2");
        }
        else if (stage_number == 3)
        {
           
            SceneManager.LoadScene("stage3");
        }

        else if (stage_number == 4)
        {
            SceneManager.LoadScene("stage4");
        }

        else if (stage_number == 5)
        {
         
            SceneManager.LoadScene("stage5");
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
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 1f * scaleSpeed * Time.deltaTime, gameObject.transform.localScale.y + 1f * scaleSpeed * Time.deltaTime, 0);
    }

    void changed_small()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 1f * scaleSpeed * Time.deltaTime, gameObject.transform.localScale.y - 1f * scaleSpeed * Time.deltaTime, 0);
    }


    IEnumerator changing()
    {
        float checkTime = 0f;
        
        while (checkTime < 4f)
        {
            yield return new WaitForSecondsRealtime(0.02f);
            checkTime += 0.1f;
            changed();
            timecheck = checkTime;
        }
        
        if (checkTime >= 4f)
        {
            changeScene = true;
            full_stay = true;
            yield break;
        }
    }

    IEnumerator changing_small()
    {
        float checkTime = timecheck;
        while (checkTime >= 0f && checkTime < 4f)
        {
            yield return new WaitForSecondsRealtime(0.02f);
            checkTime -= 0.1f;
            changed_small();
        }
        if (checkTime < 0f)
        {
            yield break;
        }
    }


}
