using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public Image fadeObject;

    [Range(0.01f, 10f)]
    public float fadeTime = 1f;
    public Image testimage;
    private FadeState fadeState;
    public AnimationCurve fadeCurve;

    private static SceneChangeManager instance;

    public static SceneChangeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneChangeManager>();
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    

    public void FadeIn() // 화면이 보인다.
    {
        StartCoroutine(FadeImage(true));
    }

    public void FadeOut() // 화면이 까매진다.
    {
        StartCoroutine(FadeImage(false));
    }
    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "stage1")
        {
            FadeImage(true);
            //Invoke("FadeIn", 0.1f);
        }
        if (SceneManager.GetActiveScene().name == "ModeSelect")
        {
            Debug.Log("모드 선택 창입니다.");
            Invoke("FadeIn", 0.5f);
        }
        if (SceneManager.GetActiveScene().name == "StageSelect")
        {
            FadeIn();
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards // 페이드 인
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                fadeObject.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }

        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                fadeObject.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }




    public void FadeOutTest()
    {
        Debug.Log("화면이 어두워집니다.");
        StartCoroutine(FadeTest(0, 1)); // 화면이 점점 어두워짐
    }

    public void FadeInTest()
    {
        Debug.Log("화면이 밝아집니다.");
        StartCoroutine(FadeTest(1, 0)); // 화면이 점점 밝아짐
    }



    IEnumerator FadeTest(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;
            Color color = testimage.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            testimage.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
    }
}
