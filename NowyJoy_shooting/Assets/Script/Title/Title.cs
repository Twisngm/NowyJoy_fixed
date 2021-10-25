using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum FadeState { FadeIn = 0, FadeOut, FadeInOut, FadeLoop}
public class Title : MonoBehaviour
{
    public Image fill;
    public GameObject logo;
    public GameObject TitleWindow;
    public int currentValue, maxValue;
    Vector3 logopoint = new Vector3(0,0,1);
    private bool isFull = false;
    Rigidbody2D rb_logo;
    Vector2 logopos = new Vector2(0, 2);
    public GameObject GM;
    
    // private float F_time = 1f;
    // private float time = 0f;

    // 페이드 인, 아웃 부분
    [Range(0.01f,10f)]
    public float fadeTime;
    public Image image;
    public Image image2;
    private FadeState fadeState;
    public AnimationCurve fadeCurve;
    public AnimationCurve fadeCurve2;

    public bool isSceneChanged = false;
    

    private void FixedUpdate()
    {
        if (isFull)
        {
            SoundManager.Instance.ChangeBGM();
            logomove();
            Invoke("ChangeScene", 2f);
            //Invoke("FadeIn", 2f);
            FadeOut();
        }
    }

   
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            rb_logo = logo.GetComponent<Rigidbody2D>();
            fill.fillAmount = Normalise();
            image2.gameObject.SetActive(true);
            image.gameObject.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            image.gameObject.SetActive(true);
            image2.gameObject.SetActive(false);
           
            FadeIn();
            
        }
    }
    private void Start()
    {
        image = image.gameObject.GetComponent<Image>();
        image2 = image2.gameObject.GetComponent<Image>();
        GM.SetActive(true);
    }

    public void Add(int val)
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
            yield return new WaitForSecondsRealtime(0.1f);
            
            Add(2);
        }
    }
    public void logomove()
    {
        logo.transform.Translate(logopos*5);
        Destroy(logo, 4f);
    }


    //페이드 인
    public void FadeOut()
    {
        StartCoroutine(FadeOut(0,1)); // 화면이 점점 어두워짐
        
        
    }
    public void FadeIn()
    {
        StartCoroutine(FadeIn(1, 0)); // 화면이 점점 밝아짐
    }

    IEnumerator FadeOut(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;
                Color color = image2.color;
                color.a = Mathf.Lerp(start, end, fadeCurve2.Evaluate(percent));
                image2.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
    }

    //페이드 인,아웃
    IEnumerator FadeIn(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;
            Color color = image.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            image.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
    }

    //public void OnFade(FadeState state)
    //{
    //    fadeState = state;

    //    switch (fadeState)
    //    {
    //        case FadeState.FadeIn:
    //            StartCoroutine(Fade(1, 0));
    //            break;
    //        case FadeState.FadeOut:
    //            StartCoroutine(Fade(0, 1));
    //            break;
    //        case FadeState.FadeInOut:
    //        case FadeState.FadeLoop:
    //            StartCoroutine(FadeInOut());
    //            break;
    //    }
    //}
    //private IEnumerator FadeInOut()
    //{
    //    while (true)
    //    {
    //        yield return StartCoroutine(Fade(0, 1));

    //        yield return StartCoroutine(Fade(1, 0));

    //        if (fadeState == FadeState.FadeInOut)
    //        {
    //            break;
    //        }
    //    }
    //}

    public void HideWindow()
    {
        TitleWindow.SetActive(false);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
