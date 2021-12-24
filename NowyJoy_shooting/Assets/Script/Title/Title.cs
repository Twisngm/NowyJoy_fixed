using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public Image fill;
    public GameObject logo;
    public GameObject TitleWindow;
    public float currentValue, maxValue;
    Vector3 logopoint = new Vector3(0, 0, 1);
    private bool isFull = false;
    Rigidbody2D rb_logo;
    Vector2 logopos = new Vector2(0, 2);
    public GameObject GM;

    public bool isSceneChanged = false;


    private void FixedUpdate()
    {
        if (isFull)
        {
            SoundManager.Instance.ChangeBGM();
            //logomove(); - 관상용
            ChangeScene();
            //Invoke("ChangeScene", 2f);
        }
    }


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            rb_logo = logo.GetComponent<Rigidbody2D>();
            fill.fillAmount = Normalise();
        }
        if (SceneManager.GetActiveScene().name == "stage1")
        {
        }
    }
    private void Start()
    {
        //GM.SetActive(true); - gm 없음
    }

    public void Add(float val)
    {
        currentValue += val;

        if (currentValue > maxValue)
        {
            currentValue = maxValue;
            isFull = true;
        }
        fill.fillAmount = Normalise();
    }


    private float Normalise()
    {
        return (float)currentValue / maxValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TitlePlayer"))
        {
            StartCoroutine("addgauge");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine("addgauge");
    }

    IEnumerator addgauge()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.001f);

            Add(0.5f);
        }
    }
    public void logomove()
    {
        logo.transform.Translate(logopos * 5);
        Destroy(logo, 4f);
    }

    public void HideWindow()
    {
        TitleWindow.SetActive(false);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("StageSelect");
     //   SceneManager.LoadScene("Stage"+GameManager.GM_Instance.CurrentStage);
    }
}