using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public string stage;
    
    [SerializeField] [Range(1f, 5f)] float scaleSpeed = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (stage)
            {
                case "1":
                    Debug.Log("1 스테이지로 이동합니다.");
                    //SceneManager.LoadScene("stage1");
                    StartCoroutine("changing");
                    break;
                case "1-1":
                    Debug.Log("1-1 스테이지로 이동합니다.");
                    break;
                case "2":
                    Debug.Log("2 스테이지로 이동합니다.");
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("나갔습니다.");
        StopCoroutine("changing");
        StartCoroutine("changing_small");
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
        
        while (checkTime <= 4f)
        {
            yield return new WaitForSecondsRealtime(0.02f);
            checkTime += 0.1f;
            changed();
            PlayerPrefs.SetFloat("checktime", checkTime);
        }
        
        if (checkTime > 4f)
        {
            yield break;
        }
    }

    IEnumerator changing_small()
    {
        float checkTime = PlayerPrefs.GetFloat("checktime", 0f);
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
